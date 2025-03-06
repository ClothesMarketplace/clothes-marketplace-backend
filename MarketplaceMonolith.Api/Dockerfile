FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

WORKDIR /app/MarketplaceMonolith.Api

RUN dotnet restore MarketplaceMonolith.Api.sln  

RUN dotnet build -c Release --no-restore

RUN dotnet publish MarketplaceMonolith.Api.csproj -c Release -o /app/publish --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "MarketplaceMonolith.Api.dll"]
