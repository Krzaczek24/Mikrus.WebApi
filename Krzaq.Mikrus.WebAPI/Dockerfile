ARG DOTNET=10.0
FROM mcr.microsoft.com/dotnet/sdk:$DOTNET AS build
WORKDIR /src

COPY ./Krzaq.Mikrus.WebAPI/* WebAPI/
RUN dotnet restore
RUN dotnet build -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish --no-build --no-restore /p:UseAppHost=false

ARG DOTNET=10.0
FROM mcr.microsoft.com/dotnet/aspnet:$DOTNET AS final
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=publish /app/publish ./

ENTRYPOINT ["dotnet", "Krzaq.Mikrus.WebAPI.dll"]