FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApi.App/WebApi.App.csproj", "WebApi.App/"]
RUN dotnet restore "WebApi.App/WebApi.App.csproj"
COPY . .
WORKDIR "/src/WebApi.App"
RUN dotnet build "WebApi.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.App.dll"]
