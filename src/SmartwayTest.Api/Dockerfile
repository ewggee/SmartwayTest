#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SmartwayTest.Api/SmartwayTest.Api.csproj", "src/SmartwayTest.Api/"]
COPY ["src/SmartwayTest.Application/SmartwayTest.Application.csproj", "src/SmartwayTest.Application/"]
COPY ["src/SmartwayTest.Contracts/SmartwayTest.Contracts.csproj", "src/SmartwayTest.Contracts/"]
COPY ["src/SmartwayTest.Domain/SmartwayTest.Domain.csproj", "src/SmartwayTest.Domain/"]
COPY ["src/SmartwayTest.DataAccess/SmartwayTest.DataAccess.csproj", "src/SmartwayTest.DataAccess/"]
RUN dotnet restore "./src/SmartwayTest.Api/SmartwayTest.Api.csproj"
COPY . .
WORKDIR "/src/src/SmartwayTest.Api"
RUN dotnet build "./SmartwayTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartwayTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartwayTest.Api.dll"]