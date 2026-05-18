FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем файлы проектов с учетом папки src
COPY ["src/WomenClothingStore.Web/WomenClothingStore.Web.csproj", "src/WomenClothingStore.Web/"]
COPY ["src/WomenClothingStore.Domain/WomenClothingStore.Domain.csproj", "src/WomenClothingStore.Domain/"]
COPY ["src/WomenClothingStore.Infrastructure/WomenClothingStore.Infrastructure.csproj", "src/WomenClothingStore.Infrastructure/"]

# Восстанавливаем зависимости
RUN dotnet restore "src/WomenClothingStore.Web/WomenClothingStore.Web.csproj"

# Копируем все остальные исходники
COPY . .
WORKDIR "/src/src/WomenClothingStore.Web"
RUN dotnet build "WomenClothingStore.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WomenClothingStore.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WomenClothingStore.Web.dll"]