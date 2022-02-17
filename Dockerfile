# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ../app/src ./
RUN dotnet publish WebAPI/WebAPI.csproj -c Release -o out

# Labels
LABEL version="1.0.0" description="API Integration TCC" maintainer="Nathaly Mesquita<nnathalygm@gmail.com>"

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/src/out .
ENTRYPOINT ["dotnet", "API.Integration.TCC.WebAPI.dll"]
