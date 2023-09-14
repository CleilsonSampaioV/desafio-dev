FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FinancialStore.API/FinancialStore.API.csproj", "src/FinancialStore.API/"]
COPY ["src/FinancialStore.Core/FinancialStore.Core.csproj", "src/FinancialStore.Core/"]
COPY ["src/FinancialStore.Contracts/FinancialStore.Contracts.csproj", "src/FinancialStore.Contracts/"]
COPY ["src/FinancialStore.Infra/FinancialStore.Infra.csproj", "src/FinancialStore.Infra/"]
COPY ["src/FinancialStore.Migrations/FinancialStore.Migrations.csproj", "src/FinancialStore.Migrations/"]
RUN dotnet restore "src/FinancialStore.API/FinancialStore.API.csproj"
COPY . .
WORKDIR "/src/src/FinancialStore.API"
RUN dotnet build "FinancialStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancialStore.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialStore.API.dll"]