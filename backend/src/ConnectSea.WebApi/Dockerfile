FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ConnectSea.WebApi/ConnectSea.WebApi.csproj", "src/ConnectSea.WebApi/"]
COPY ["src/ConnectSea.Domain/ConnectSea.Domain.csproj", "src/ConnectSea.Domain/"]
COPY ["src/ConnectSea.Infrastructure.Data/ConnectSea.Infrastructure.Data.csproj", "src/ConnectSea.Infrastructure.Data/"]
RUN dotnet restore "src/ConnectSea.WebApi/ConnectSea.WebApi.csproj"
COPY . .
WORKDIR "/src/src/ConnectSea.WebApi"
RUN dotnet build "./ConnectSea.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ConnectSea.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConnectSea.WebApi.dll"]
