#!/bin/bash
#
# build.sh(1)
#

[[ -n $DEBUG ]] && set -x
set -eu -o pipefail

# build parameters
readonly REGION=${AWS_DEFAULT_REGION:-"eu-central-1"}
readonly IMAGE_NAME='samples-pipeline-dotnet'
readonly BUILD_NUMBER=${1:-"N/A"}

restore_dependencies() {
    echo "Restoring dependencies"
    dotnet restore PipelineSample.sln
}

run_tests() {
    echo "Running tests .."
    dotnet build -c Release PipelineSample.sln
    dotnet test --logger:"trx;LogFileName=testresults.trx" PipelineSample.WebApi.Tests/PipelineSample.WebApi.Tests.csproj
}

build_container_image() {
    echo "Building container image .."
    
    docker build -t ${IMAGE_NAME} .
}

push_container_image() {
    echo "Login to docker..."
    $(aws ecr get-login --no-include-email)

    account_id=$(aws sts get-caller-identity --output text --query 'Account')
    image_name="${account_id}.dkr.ecr.${REGION}.amazonaws.com/ded/${IMAGE_NAME}:${BUILD_NUMBER}"

    echo "Tagging container image..."
    docker tag ${IMAGE_NAME}:latest ${image_name}

    echo "Pushing container image to ECR..."
    docker push ${image_name}
}

cd ./src

restore_dependencies
run_tests

cd ..

build_container_image

if [[ "${BUILD_NUMBER}" != "N/A" ]]; then
    push_container_image
fi
