#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MAC_AddressLookup.API/MAC_AddressLookup.API.csproj", "MAC_AddressLookup.API/"]
RUN dotnet restore "MAC_AddressLookup.API/MAC_AddressLookup.API.csproj"
COPY . .
WORKDIR "/src/MAC_AddressLookup.API"
RUN dotnet build "MAC_AddressLookup.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MAC_AddressLookup.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MAC_AddressLookup.API.dll"]
