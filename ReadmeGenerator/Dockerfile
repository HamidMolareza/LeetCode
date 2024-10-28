FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base

# Install git in the base image (if not installed already)
RUN apt-get update && \
    apt-get install -y git && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReadmeGenerator/ReadmeGenerator.csproj", "ReadmeGenerator/"]
RUN dotnet restore "ReadmeGenerator/ReadmeGenerator.csproj"
COPY . .
RUN dotnet build -c $BUILD_CONFIGURATION
RUN dotnet test

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ReadmeGenerator/ReadmeGenerator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReadmeGenerator.dll"]