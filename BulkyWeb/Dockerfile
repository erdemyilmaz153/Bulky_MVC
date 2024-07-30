FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BulkyWeb/BulkyWeb.csproj", "BulkyWeb/"]
RUN dotnet restore "BulkyWeb/BulkyWeb.csproj"
COPY . .
WORKDIR "/src/BulkyWeb"
RUN dotnet build "BulkyWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BulkyWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BulkyWeb.dll"]


 
