# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# В зависимости от операционной системы хост-компьютеров, которые будут выполнять сборку контейнеров или запускать их, может потребоваться изменить образ, указанный в инструкции FROM.
# Дополнительные сведения см. на странице https://aka.ms/containercompat

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS with-node
WORKDIR /src
RUN curl https://nodejs.org/dist/v18.18.0/node-v18.18.0-win-x64.zip --output node.zip
RUN tar -xf node.zip
USER ContainerAdministrator
RUN setx /M path "%path%;C:\src\node-v18.18.0-win-x64"
USER ContainerUser
RUN npm install -g @angular/cli

FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["V2testTask.Server/V2testTask.Server.csproj", "V2testTask.Server/"]
COPY ["v2testtask.client/v2testtask.client.esproj", "v2testtask.client/"]
RUN dotnet restore "./V2testTask.Server/V2testTask.Server.csproj"
COPY . .
WORKDIR "/src/V2testTask.Server"
RUN dotnet build "./V2testTask.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./V2testTask.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "V2testTask.Server.dll"]
