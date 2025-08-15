# Multi-stage build for Blazor application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set working directory
WORKDIR /src

# Copy project files
COPY ["Blazor.csproj", "./"]
COPY ["Models/*.cs", "./Models/"]
COPY ["Service/*.cs", "./Service/"]
COPY ["Components/**/*.razor", "./Components/"]
COPY ["Components/**/*.razor.css", "./Components/"]
COPY ["wwwroot/**/*", "./wwwroot/"]
COPY ["Program.cs", "./"]
COPY ["Properties/launchSettings.json", "./Properties/"]

# Restore dependencies
RUN dotnet restore "Blazor.csproj"

# Build the application
RUN dotnet build "Blazor.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "Blazor.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Set working directory
WORKDIR /app

# Copy published application
COPY --from=build /app/publish .

# Expose port 8067
EXPOSE 8067

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8067
ENV ASPNETCORE_ENVIRONMENT=Production

# Start the application
ENTRYPOINT ["dotnet", "Blazor.dll"]
