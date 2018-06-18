FROM microsoft/aspnetcore:2.0

WORKDIR /app

COPY ./output/* ./

ENTRYPOINT [ "dotnet", "PipelineSample.WebApi.dll" ]
