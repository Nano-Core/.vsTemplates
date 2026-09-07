ARG DOTNET_SDK_VERSION
ARG DOTNET_ASPNET_VERSION
ARG CONTAINER_REGISTRY_SOURCE_LABEL

FROM mcr.microsoft.com/dotnet/aspnet:$DOTNET_ASPNET_VERSION AS base

LABEL org.opencontainers.image.source=CONTAINER_REGISTRY_SOURCE_LABEL

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:$DOTNET_SDK_VERSION AS build

WORKDIR /src
COPY . .

RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENV COMPlus_EnableDiagnostics=0
ENV DOTNET_USE_POLLING_FILE_WATCHER=true

ENTRYPOINT ["dotnet", "NanoCore.Console.Minimal.dll"]
