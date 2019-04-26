FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/MarvelHeroes.Server/MarvelHeroes.Server.csproj", "src/MarvelHeroes.Server/"]
RUN dotnet restore "src/MarvelHeroes.Server/MarvelHeroes.Server.csproj"
COPY . .
WORKDIR "/src/src/MarvelHeroes.Server"
RUN dotnet build "MarvelHeroes.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MarvelHeroes.Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MarvelHeroes.Server.dll"]