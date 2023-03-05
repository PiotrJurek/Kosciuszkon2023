FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LifeCrawler/LifeCrawler.csproj", "LifeCrawler/"]
RUN dotnet restore "LifeCrawler/LifeCrawler.csproj"
COPY . .
WORKDIR "/src/LifeCrawler"
RUN dotnet build "LifeCrawler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LifeCrawler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LifeCrawler.dll"]
