FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Web.Api/Web.Api.csproj", "Web.Api/"]
COPY ["Web.Core/Web.Core.csproj", "Web.Core/"]
COPY ["Web.Infrastructure/Web.Infrastructure.csproj", "Web.Infrastructure/"]
RUN dotnet restore "./Web.Api/./Web.Api.csproj"
COPY . .
WORKDIR "/src/Web.Api"
RUN dotnet build "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Api.dll"]