ARG DOTNET_VERSION=10.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /app

COPY Krzaq.Mikrus.WebAPI/Krzaq.Mikrus.WebAPI.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -p:PublishDir=./output

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app

COPY --from=build /app/output .

EXPOSE 80
ENTRYPOINT ["dotnet", "Krzaq.Mikrus.WebAPI.dll"]