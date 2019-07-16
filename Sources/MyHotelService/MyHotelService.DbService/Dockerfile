# FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
# WORKDIR /app

FROM microsoft/dotnet:2.2-sdk
WORKDIR /src
COPY ["MyHotelService.Common/MyHotelService.Common.csproj", "MyHotelService.Common/"]
RUN dotnet restore "MyHotelService.Common/MyHotelService.Common.csproj"
COPY ["MyHotelService.DbService/MyHotelService.DbService.csproj", "MyHotelService.DbService/"]
RUN dotnet restore "MyHotelService.DbService/MyHotelService.DbService.csproj"
COPY . .
WORKDIR "/src/MyHotelService.DbService"
RUN dotnet build "MyHotelService.DbService.csproj" -c Release -o /app
EXPOSE 5001
RUN dotnet publish "MyHotelService.DbService.csproj" -c Release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "MyHotelService.DbService.dll"]