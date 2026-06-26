FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["WomenClothingStore.Web/WomenClothingStore.Web.csproj", "WomenClothingStore.Web/"]
COPY ["WomenClothingStore.Domain/WomenClothingStore.Domain.csproj", "WomenClothingStore.Domain/"]
COPY ["WomenClothingStore.Infrastructure/WomenClothingStore.Infrastructure.csproj", "WomenClothingStore.Infrastructure/"]

RUN dotnet restore "WomenClothingStore.Web/WomenClothingStore.Web.csproj"

COPY . .

WORKDIR "/src/WomenClothingStore.Web"
RUN dotnet build "WomenClothingStore.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WomenClothingStore.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WomenClothingStore.Web.dll"]