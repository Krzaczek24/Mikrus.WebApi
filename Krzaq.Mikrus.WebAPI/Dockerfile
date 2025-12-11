ARG DOTNET_VERSION=10.0
ARG BUILD_CONFIGURATION=Release

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

RUN ls -alh

COPY Krzaq.Mikrus.WebApi/*.csproj .
RUN dotnet restore

RUN ls -alh

COPY Krzaq.Mikrus.WebApi/. .
RUN dotnet build --no-restore -c $BUILD_CONFIGURATION -o /build

RUN ls -alh

FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /publish /p:UseAppHost=false

RUN ls -alh

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}
EXPOSE 80
WORKDIR /publish

RUN ls -alh

COPY . .

RUN ls -alh

ENTRYPOINT ["dotnet", "Krzaq.Mikrus.WebApi.dll"]