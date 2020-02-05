FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Prometheus.WebApi/Prometheus.WebApi.csproj", "Prometheus.WebApi/"]
RUN dotnet restore "Prometheus.WebApi/Prometheus.WebApi.csproj"
COPY . .
WORKDIR "Prometheus.WebApi"
RUN dotnet build "Prometheus.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prometheus.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prometheus.WebApi.dll"]
