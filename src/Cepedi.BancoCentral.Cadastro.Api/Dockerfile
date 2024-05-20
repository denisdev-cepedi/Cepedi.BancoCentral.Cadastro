#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Cepedi.BancoCentral.Cadastro.Api/Cepedi.BancoCentral.Cadastro.Api.csproj", "src/Cepedi.BancoCentral.Cadastro.Api/"]
COPY ["src/Cepedi.BancoCentral.Cadastro.Dominio/Cepedi.BancoCentral.Cadastro.Dominio.csproj", "src/Cepedi.BancoCentral.Cadastro.Dominio/"]
COPY ["src/Cepedi.BancoCentral.Cadastro.Dados/Cepedi.BancoCentral.Cadastro.Dados.csproj", "src/Cepedi.BancoCentral.Cadastro.Dados/"]
COPY ["src/Cepedi.BancoCentral.Cadastro.Compartilhado/Cepedi.BancoCentral.Cadastro.Compartilhado.csproj", "src/Cepedi.BancoCentral.Cadastro.Compartilhado/"]
COPY ["src/Cepedi.BancoCentral.Cadastro.IoC/Cepedi.BancoCentral.Cadastro.IoC.csproj", "src/Cepedi.BancoCentral.Cadastro.IoC/"]

RUN dotnet restore "./src/Cepedi.BancoCentral.Cadastro.Api/Cepedi.BancoCentral.Cadastro.Api.csproj"
COPY . .
WORKDIR "/src/src/Cepedi.BancoCentral.Cadastro.Api"
RUN dotnet build "./Cepedi.BancoCentral.Cadastro.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cepedi.BancoCentral.Cadastro.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cepedi.BancoCentral.Cadastro.Api.dll"]
