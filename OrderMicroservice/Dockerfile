#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0.7 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0.7 AS build
WORKDIR /src
COPY ["OrderMicroservice/OrderMicroserviceAPI.csproj", "OrderMicroservice/"]
COPY ["OrderMicroservice/OrderAPI.Infrastructure/OrderAPI.Infrastructure.csproj", "OrderMicroservice/OrderAPI.Infrastructure/"]
COPY ["OrderMicroservice/OrderAPI.ApplicationCore/OrderAPI.ApplicationCore.csproj", "OrderMicroservice/OrderAPI.ApplicationCore/"]
RUN dotnet restore "OrderMicroservice/OrderMicroserviceAPI.csproj"
COPY . .
WORKDIR "/src/OrderMicroservice"
RUN dotnet build "OrderMicroserviceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderMicroserviceAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderMicroserviceAPI.dll"]
