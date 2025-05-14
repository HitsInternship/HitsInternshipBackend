# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_ENVIRONMENT=Development

# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HitsInternship.Api/HitsInternship.Api.csproj", "HitsInternship.Api/"]
COPY ["CompanyModule.Controllers/CompanyModule.Controllers.csproj", "CompanyModule.Controllers/"]
COPY ["CompanyModule.Application/CompanyModule.Application.csproj", "CompanyModule.Application/"]
COPY ["CompanyModule.Contracts/CompanyModule.Contracts.csproj", "CompanyModule.Contracts/"]
COPY ["CompanyModule.Domain/CompanyModule.Domain.csproj", "CompanyModule.Domain/"]
COPY ["Shared.Domain/Shared.Domain.csproj", "Shared.Domain/"]
COPY ["UserModule.Domain/UserModule.Domain.csproj", "UserModule.Domain/"]
COPY ["Shared.Contracts/Shared.Contracts.csproj", "Shared.Contracts/"]
COPY ["UserModule.Contracts/UserModule.Contracts.csproj", "UserModule.Contracts/"]
COPY ["Shared.Extensions/Shared.Extensions.csproj", "Shared.Extensions/"]
COPY ["Shared.Persistence/Shared.Persistence.csproj", "Shared.Persistence/"]
COPY ["DocumentModule.Contracts/DocumentModule.Contracts.csproj", "DocumentModule.Contracts/"]
COPY ["DocumentModule.Domain/DocumentModule.Domain.csproj", "DocumentModule.Domain/"]
COPY ["CompanyModule.Infrastructure/CompanyModule.Infrastructure.csproj", "CompanyModule.Infrastructure/"]
COPY ["CompanyModule.Persistence/CompanyModule.Persistence.csproj", "CompanyModule.Persistence/"]
COPY ["DeanModule.Controllers/DeanModule.Controllers.csproj", "DeanModule.Controllers/"]
COPY ["DeanModule.Application/DeanModule.Application.csproj", "DeanModule.Application/"]
COPY ["DeanModule.Contracts/DeanModule.Contracts.csproj", "DeanModule.Contracts/"]
COPY ["DeanModule.Domain/DeanModule.Domain.csproj", "DeanModule.Domain/"]
COPY ["DeanModule.Infrastructure/DeanModule.Infrastructure.csproj", "DeanModule.Infrastructure/"]
COPY ["DeanModule.Persistence/DeanModule.Persistence.csproj", "DeanModule.Persistence/"]
COPY ["DocumentModule.Controllers/DocumentModule.Controllers.csproj", "DocumentModule.Controllers/"]
COPY ["DocumentModule.Application/DocumentModule.Application.csproj", "DocumentModule.Application/"]
COPY ["DocumentModule.Persistence/DocumentModule.Persistence.csproj", "DocumentModule.Persistence/"]
COPY ["DocumentModule.Infrastructure/DocumentModule.Infrastructure.csproj", "DocumentModule.Infrastructure/"]
COPY ["UserModule.Controllers/UserModule.Controllers.csproj", "UserModule.Controllers/"]
COPY ["UserModule.Application/UserModule.Application.csproj", "UserModule.Application/"]
COPY ["UserModule.Persistence/UserModule.Persistence.csproj", "UserModule.Persistence/"]
COPY ["UserModule.Infrastructure/UserModule.Infrastructure.csproj", "UserModule.Infrastructure/"]
RUN dotnet restore "./HitsInternship.Api/HitsInternship.Api.csproj"
COPY . .
WORKDIR "/src/HitsInternship.Api"
RUN dotnet build "./HitsInternship.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HitsInternship.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HitsInternship.Api.dll"]