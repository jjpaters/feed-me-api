# Build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src

COPY . .

RUN dotnet restore

RUN dotnet publish FeedMe.Api/FeedMe.Api.csproj -c Release -o out


# Run
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base

EXPOSE 80

WORKDIR /app

COPY --from=build /src/FeedMe.Api/out .

ENTRYPOINT ["dotnet", "app/FeedMe.Api.dll"]
