FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
COPY ./src/Fibonacci.Api /src
WORKDIR /src
RUN dotnet restore
RUN dotnet publish -c Release -r alpine.3.12-x64 -p:PublishTrimmed=true -p:PublishReadyToRun=true -o /app

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine3.12
COPY --from=build /app /app
EXPOSE 80
ENTRYPOINT [ "/app/Fibonacci.Api" ]
