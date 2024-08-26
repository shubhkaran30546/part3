# Use the official .NET image from the Docker Hub 
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base 
WORKDIR /app 
EXPOSE 80 
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build 
WORKDIR /src 
COPY ["part3.csproj", "./"] 
RUN dotnet restore "part3.csproj" 
COPY . . 
WORKDIR "/src/part3" 
RUN dotnet build "part3.csproj" -c Release -o /app/build 
FROM build AS publish 
RUN dotnet publish "part3.csproj" -c Release -o /app/publish 
FROM base AS final 
WORKDIR /app 
COPY --from=publish /app/publish . 
COPY wwwroot/images /app/wwwroot/images
ENTRYPOINT ["dotnet", "part3.dll"]
