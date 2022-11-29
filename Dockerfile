
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Api.Learning.Api/Api.Learning.Api.csproj", "Api.Learning.Api/"]
RUN dotnet restore "Api.Learning.Api/Api.Learning.Api.csproj"
COPY . .
WORKDIR "/src/Api.Learning.Api"
RUN dotnet build "Api.Learning.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Learning.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Learning.Api.dll"]
