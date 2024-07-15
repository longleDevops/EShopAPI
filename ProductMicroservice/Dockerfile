FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

ENV EShopDbConnection="Server=tcp:eshopdb99.database.windows.net,1433;Initial Catalog=EShopDb;User ID=lelongdinh2015;Password=Kakashi2001@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/"]
COPY ["ProductMicroservice/ProductAPI.Infrastructure/ProductAPI.Infrastructure.csproj", "ProductMicroservice/ProductAPI.Infrastructure/"]
COPY ["ProductMicroservice/ProductAPI.ApplicationCore/ProductAPI.ApplicationCore.csproj", "ProductMicroservice/ProductAPI.ApplicationCore/"]
RUN dotnet restore "ProductMicroservice/ProductMicroservice.csproj"
COPY . .
WORKDIR "/src/ProductMicroservice"
RUN dotnet build "ProductMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]
