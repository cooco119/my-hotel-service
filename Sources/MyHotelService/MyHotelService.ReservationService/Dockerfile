# FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
# WORKDIR /app

FROM microsoft/dotnet:2.2-sdk
WORKDIR /src
COPY ["MyHotelService.Common/MyHotelService.Common.csproj", "MyHotelService.Common/"]
RUN dotnet restore "MyHotelService.Common/MyHotelService.Common.csproj"
COPY ["MyHotelService.ReservationService/MyHotelService.ReservationService.csproj", "MyHotelService.ReservationService/"]
RUN dotnet restore "MyHotelService.ReservationService/MyHotelService.ReservationService.csproj"
COPY . .
WORKDIR "/src/MyHotelService.ReservationService"
RUN dotnet build "MyHotelService.ReservationService.csproj" -c Release -o /app
EXPOSE 5000
RUN dotnet publish "MyHotelService.ReservationService.csproj" -c Release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "MyHotelService.ReservationService.dll"]