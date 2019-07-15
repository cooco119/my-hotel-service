FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ReservationService/ReservationService.csproj", "ReservationService/"]
RUN dotnet restore "ReservationService/ReservationService.csproj"
COPY . .
WORKDIR "/src/ReservationService"
RUN dotnet build "ReservationService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ReservationService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ReservationService.dll"]