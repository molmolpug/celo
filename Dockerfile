FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env

COPY . /app
WORKDIR /app

RUN dotnet restore

workdir /app/Celo.Api

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app/Celo.Api/out ./

ENTRYPOINT ["dotnet", "Celo.Api.dll"]