FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
RUN dotnet dev-certs https --trust
COPY ["V2testTask.Server/V2testTask.Server.csproj", "V2testTask.Server/"]
RUN dotnet restore "V2testTask.Server/V2testTask.Server.csproj"
COPY . .
WORKDIR "/src/V2testTask.Server"
RUN dotnet build "V2testTask.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./V2testTask.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "V2testTask.Server.dll"]
EXPOSE 8080
