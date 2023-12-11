#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShoppingListApp.API/ShoppingListApp.API.csproj", "ShoppingListApp.API/"]
COPY ["ShoppingListApp.Application/ShoppingListApp.Application.csproj", "ShoppingListApp.Application/"]
COPY ["ShoppingListApp.Domain/ShoppingListApp.Domain.csproj", "ShoppingListApp.Domain/"]
COPY ["ShoppingListApp.Infrastructure/ShoppingListApp.Infrastructure.csproj", "ShoppingListApp.Infrastructure/"]
RUN dotnet restore "./ShoppingListApp.API/./ShoppingListApp.API.csproj"
COPY . .
WORKDIR "/src/ShoppingListApp.API"
RUN dotnet build "./ShoppingListApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShoppingListApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingListApp.API.dll"]