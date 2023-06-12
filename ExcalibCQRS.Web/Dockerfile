FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ExcalibCQRS.Web/ExcalibCQRS.Web.csproj", "ExcalibCQRS.Web/"]
RUN dotnet restore "ExcalibCQRS.Web/ExcalibCQRS.Web.csproj"
COPY . .
WORKDIR "/src/ExcalibCQRS.Web"
RUN dotnet build "ExcalibCQRS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExcalibCQRS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExcalibCQRS.Web.dll"]
