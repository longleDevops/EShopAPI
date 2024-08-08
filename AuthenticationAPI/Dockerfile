FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV EShopDbConnection="Server=tcp:eshopdb99.database.windows.net,1433;Initial Catalog=EShopDb;User ID=lelongdinh2015;Password=Kakashi2001@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;"

ENV JWT_ValidAudience="https://mango-rock-0b437651e.5.azurestaticapps.net/"
ENV JWT_ValidIssuer="http://localhost:5001"
ENV JWT_Secret="JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"
ENV JWT_TokenValidityInMinutes=20
ENV JWT_RefreshTokenValidityInDays=7

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AuthenticationAPI/AuthenticationAPI.csproj", "AuthenticationAPI/"]
COPY ["Authentication.Infrastructure/Authentication.Infrastructure.csproj", "Authentication.Infrastructure/"]
COPY ["Authentication.ApplicationCore/Authentication.ApplicationCore.csproj", "Authentication.ApplicationCore/"]
RUN dotnet restore "AuthenticationAPI/AuthenticationAPI.csproj"
COPY . .
WORKDIR "/src/AuthenticationAPI"
RUN dotnet build "AuthenticationAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AuthenticationAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationAPI.dll"]
