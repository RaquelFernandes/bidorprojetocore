#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["bidorprojetocore.API/bidorprojetocore.API.csproj", "bidorprojetocore.API/"]
RUN dotnet restore "bidorprojetocore.API/bidorprojetocore.API.csproj"
COPY . .
WORKDIR "/src/bidorprojetocore.API"
RUN dotnet build "bidorprojetocore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bidorprojetocore.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bidorprojetocore.API.dll"]