FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY MarketplaceMonolith/MarketplaceMonolith.Api/MarketplaceMonolith.Api.sln ./

RUN dotnet restore MarketplaceMonolith.Api/MarketplaceMonolith.Api.sln

COPY MarketplaceMonolith.Api/*.csproj MarketplaceMonolith.Api/
COPY MarketplaceMonolith.Core/*.csproj MarketplaceMonolith.Core/
COPY MarketplaceMonolith.Infrastructure/*.csproj MarketplaceMonolith.Infrastructure/
COPY Marketplace.Shared/*.csproj Marketplace.Shared/

RUN dotnet restore

COPY . .

RUN dotnet build -c Release --no-restore

RUN dotnet publish MarketplaceMonolith.Api/MarketplaceMonolith.Api.csproj -c Release -o /app/publish --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "MarketplaceMonolith.Api.dll"]
