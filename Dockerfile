# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj and restore dependencies
COPY *.sln ./
COPY MyWebApiCoreService/*.csproj ./MyWebApiCoreService/
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/MyWebApiCoreService
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/MyWebApiCoreService/out ./

# Expose port (update if your API uses a different port)
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "MyWebApiCoreService.dll"]
