FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Directory.Build.props ./
COPY src/ConsolidatedMasoneilanContact/ConsolidatedMasoneilanContact.csproj ./src/ConsolidatedMasoneilanContact/
RUN dotnet restore ./src/ConsolidatedMasoneilanContact/ConsolidatedMasoneilanContact.csproj

COPY src/ConsolidatedMasoneilanContact ./src/ConsolidatedMasoneilanContact
RUN dotnet publish ./src/ConsolidatedMasoneilanContact/ConsolidatedMasoneilanContact.csproj \
    --configuration Release \
    --no-restore \
    --output /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
COPY --from=build /app/publish .
EXPOSE 10000
CMD ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-10000} dotnet ConsolidatedMasoneilanContact.dll"]
