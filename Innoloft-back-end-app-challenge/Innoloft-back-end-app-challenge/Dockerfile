FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /Innoloft-back-end-app-challenge/Innoloft-back-end-app-challenge
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Innoloft-back-end-app-challenge/Innoloft-back-end-app-challenge
#COPY ["Innoloft-back-end-app-challenge.csproj", "./"]
#RUN dotnet restore "Innoloft-back-end-app-challenge.csproj"
COPY . .
WORKDIR "Innoloft-back-end-app-challenge/."
RUN dotnet build "Innoloft-back-end-app-challenge.csproj" -c Release -o /Innoloft-back-end-app-challenge/build
FROM build AS publish
RUN dotnet publish "Innoloft-back-end-app-challenge.csproj" -c Release -o /Innoloft-back-end-app-challenge/publish
FROM base AS final
WORKDIR /Innoloft-back-end-app-challenge
COPY --from=publish /Innoloft-back-end-app-challenge/publish /app
ENTRYPOINT ["dotnet", "/app/Innoloft-back-end-app-challenge.dll"]