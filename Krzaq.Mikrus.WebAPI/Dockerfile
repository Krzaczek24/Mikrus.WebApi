ARG DOTNET=10.0
FROM mcr.microsoft.com/dotnet/sdk:$DOTNET AS build
WORKDIR /src

COPY ./Krzaq.Mikrus.WebAPI/* WebAPI/
RUN dotnet restore WebAPI/Krzaq.Mikrus.WebAPI.csproj
RUN dotnet build WebAPI/Krzaq.Mikrus.WebAPI.csproj -c Release -o /app/build --no-restore

FROM build AS publish
WORKDIR /src
RUN ls -la ./WebAPI
RUN dotnet publish WebAPI/Krzaq.Mikrus.WebAPI.csproj -c Release -o /app/publish --no-build --no-restore /p:UseAppHost=false

ARG DOTNET=10.0
FROM mcr.microsoft.com/dotnet/aspnet:$DOTNET AS final
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=publish /app/publish ./

ENTRYPOINT ["dotnet", "Krzaq.Mikrus.WebAPI.dll"]