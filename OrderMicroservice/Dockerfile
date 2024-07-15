FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderMicroservice/OrderServiceAPI.csproj", "OrderMicroservice/"]
COPY ["OrderMicroservice/OrderAPI.Infrastructure/OrderAPI.Infrastructure.csproj", "OrderMicroservice/OrderAPI.Infrastructure/"]
COPY ["OrderMicroservice/OrderAPI.ApplicationCore/OrderAPI.ApplicationCore.csproj", "OrderMicroservice/OrderAPI.ApplicationCore/"]
RUN dotnet restore "OrderMicroservice/OrderServiceAPI.csproj"
COPY . .
WORKDIR "/src/OrderMicroservice"
RUN dotnet build "OrderServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OrderServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

ENV EShopDbConnection="Server=tcp:eshopdb99.database.windows.net,1433;Initial Catalog=EShopDb;User ID=lelongdinh2015;Password=Kakashi2001@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderServiceAPI.dll"]
