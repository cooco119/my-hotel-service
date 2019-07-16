FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MyHotelService.Common/MyHotelService.Common.csproj", "MyHotelService.Common/"]
RUN dotnet restore "MyHotelService.Common/MyHotelService.Common.csproj"
COPY ["MyHotelService.HotelService/MyHotelService.HotelService.csproj", "MyHotelService.HotelService/"]
RUN dotnet restore "MyHotelService.HotelService/MyHotelService.HotelService.csproj"
COPY . .
WORKDIR "/src/MyHotelService.HotelService"
RUN dotnet build "MyHotelService.HotelService.csproj" -c Release -o /app
EXPOSE 5002
RUN dotnet publish "MyHotelService.HotelService.csproj" -c Release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "MyHotelService.HotelService.dll"]