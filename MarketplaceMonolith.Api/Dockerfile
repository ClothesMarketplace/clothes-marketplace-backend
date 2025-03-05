# Використовуємо офіційний .NET SDK образ для збирання додатка
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копіюємо файли рішення та відновлюємо залежності
COPY *.sln ./
COPY MarketplaceMonolith.Api/*.csproj MarketplaceMonolith.Api/
COPY MarketplaceMonolith.Core/*.csproj MarketplaceMonolith.Core/
COPY MarketplaceMonolith.Infrastructure/*.csproj MarketplaceMonolith.Infrastructure/
COPY Marketplace.Shared/*.csproj Marketplace.Shared/

RUN dotnet restore

# Копіюємо весь код
COPY . ./

# Будуємо додаток
RUN dotnet publish MarketplaceMonolith.Api/MarketplaceMonolith.Api.csproj -c Release -o /publish

# Використовуємо легкий образ для виконання додатка
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Копіюємо опубліковані файли
COPY --from=build /publish .

# Вказуємо порт, який використовує API
EXPOSE 5000
EXPOSE 5001

# Запускаємо API
ENTRYPOINT ["dotnet", "MarketplaceMonolith.Api.dll"]
