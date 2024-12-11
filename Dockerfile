# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project files
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Build the application
RUN dotnet publish -c Release -o /out

# Use a runtime-only image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /out ./

# Expose the port the app runs on
EXPOSE 8080
EXPOSE 8081

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "SampleAPI.dll"]
