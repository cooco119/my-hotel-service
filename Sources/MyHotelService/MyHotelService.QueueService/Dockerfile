# FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
# WORKDIR /app

FROM microsoft/dotnet:2.2-sdk
WORKDIR /src
COPY ["MyHotelService.Common/MyHotelService.Common.csproj", "MyHotelService.Common/"]
RUN dotnet restore "MyHotelService.Common/MyHotelService.Common.csproj"
COPY ["MyHotelService.QueueService/MyHotelService.QueueService.csproj", "MyHotelService.QueueService/"]
RUN dotnet restore "MyHotelService.QueueService/MyHotelService.QueueService.csproj"
COPY . .
WORKDIR "/src/MyHotelService.QueueService"
RUN dotnet build "MyHotelService.QueueService.csproj" -c Release -o /app
EXPOSE 5002
RUN dotnet publish "MyHotelService.QueueService.csproj" -c Release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "MyHotelService.QueueService.dll"]