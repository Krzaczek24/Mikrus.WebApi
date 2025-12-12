ARG DOTNET
ARG PROJECT=Krzaq.Mikrus.WebAPI.csproj

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET} AS build
WORKDIR /src

COPY ./Krzaq.Mikrus.WebAPI/${PROJECT} ./
RUN ls -la
RUN dotnet restore ${PROJECT}

COPY . ./
WORKDIR /src
RUN ls -la
RUN dotnet build ${PROJECT} -c Release --no-restore -o /app/build

FROM build AS publish
RUN ls -la
RUN dotnet publish ${PROJECT} -c Release -o /app/publish --no-build /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET} AS final
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=publish /app/publish ./

ENTRYPOINT ["dotnet", "Krzaq.Mikrus.WebAPI.dll"]