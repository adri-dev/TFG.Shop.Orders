#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TFG.Orders.Api/TFG.Orders.Api.csproj", "TFG.Orders.Api/"]
COPY ["src/TFG.Orders.Infrastructure/TFG.Orders.Infrastructure.csproj", "TFG.Orders.Infrastructure/"]
COPY ["src/TFG.Orders.Application/TFG.Orders.Application.csproj", "TFG.Orders.Application/"]
COPY ["src/TFG.Orders.Domain/TFG.Orders.Domain.csproj", "TFG.Orders.Domain/"]
RUN dotnet restore "TFG.Orders.Api/TFG.Orders.Api.csproj"
WORKDIR "/src/TFG.Orders.Api"
COPY . .
RUN dotnet build "TFG.Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TFG.Orders.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TFG.Orders.Api.dll"]