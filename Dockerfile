FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build --configuration Release --no-restore
RUN dotnet test --no-restore --verbosity normal
RUN dotnet publish -c Release -o /src/app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /src/app .

RUN ls -lR

RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

CMD ["dotnet", "./MoonBase.MarketingSiteManager.dll"]
