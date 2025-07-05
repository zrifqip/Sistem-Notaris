FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SistemNotaris.Api/SistemNotaris.Api.csproj", "src/SistemNotaris.Api/"]
COPY ["src/SistemNotaris.Application/SistemNotaris.Application.csproj", "src/SistemNotaris.Application/"]
COPY ["src/SistemNotaris.Domain/SistemNotaris.Domain.csproj", "src/SistemNotaris.Domain/"]
COPY ["src/SistemNotaris.Infrastructure/SistemNotaris.Infrastructure.csproj", "src/SistemNotaris.Infrastructure/"]
RUN dotnet restore "./src/SistemNotaris.Api/./SistemNotaris.Api.csproj"
COPY . .
WORKDIR "/src/src/SistemNotaris.Api"
RUN dotnet build "./SistemNotaris.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SistemNotaris.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "SistemNotaris.Api.dll"]