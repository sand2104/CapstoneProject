# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the AppServiceLayer project file and restore dependencies
COPY ["AppServiceLayer/AppServiceLayer.csproj", "AppServiceLayer/"]
RUN dotnet restore "AppServiceLayer/AppServiceLayer.csproj"

# Copy the BlogTracker.dll from the BlogTracker project to AppServiceLayer
# Copy the BlogTracker.dll from the specified local path to AppServiceLayer
COPY ["AppServiceLayer/bin/Release/net6.0/BlogTracker.dll", "AppServiceLayer/"]


# Copy the entire source code
COPY . .
WORKDIR "/src/AppServiceLayer"
RUN dotnet build "AppServiceLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppServiceLayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Copy the published application from the 'publish' stage
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppServiceLayer.dll"]
