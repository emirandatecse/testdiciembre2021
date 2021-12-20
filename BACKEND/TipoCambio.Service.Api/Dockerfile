#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TipoCambio.Service.Api.csproj", "TipoCambio.Service.Api/"]
RUN dotnet restore "TipoCambio.Service.Api/TipoCambio.Service.Api.csproj"

WORKDIR "/src/TipoCambio.Service.Api"
COPY . .
RUN dotnet build "TipoCambio.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TipoCambio.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TipoCambio.Service.Api.dll"]