## See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
## This stage is used when running from VS in fast mode (Default for Debug configuration)
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#
## This stage is used to build the service project
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["src/ControleFluxoCaixa.API/ControleFluxoCaixa.API.csproj", "src/ControleFluxoCaixa.API/"]
#RUN dotnet restore "./src/ControleFluxoCaixa.API/ControleFluxoCaixa.API.csproj"
#COPY . .
#WORKDIR "/src/src/ControleFluxoCaixa.API"
#RUN dotnet build "./ControleFluxoCaixa.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## This stage is used to publish the service project to be copied to the final stage
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./ControleFluxoCaixa.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
## This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ControleFluxoCaixa.API.dll"]

# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ControleFluxoCaixa.Api/ControleFluxoCaixa.Api.csproj", "ControleFluxoCaixa.Api/"]
RUN dotnet restore "ControleFluxoCaixa.Api/ControleFluxoCaixa.Api.csproj"
COPY . .
WORKDIR "/src/ControleFluxoCaixa.Api"
RUN dotnet build "ControleFluxoCaixa.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControleFluxoCaixa.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControleFluxoCaixa.Api.dll"]
