FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DbService/DbService.csproj", "DbService/"]
RUN dotnet restore "DbService/DbService.csproj"
COPY . .
WORKDIR "/src/DbService"
RUN dotnet build "DbService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DbService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DbService.dll"]