# Build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src

COPY ./**/*.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out


# Run
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS run

EXPOSE 80

WORKDIR /app

COPY --from=build /src/out .

ENTRYPOINT ["dotnet", "FeedMe.Api.dll"]