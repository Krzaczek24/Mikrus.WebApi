ARG DOTNET_VERSION=10.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

COPY ./Krzaq.Mikrus.WebAPI/Krzaq.Mikrus.WebAPI.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build -c Release --no-restore -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish --no-build /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS final
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Krzaq.Mikrus.WebAPI.dll"]