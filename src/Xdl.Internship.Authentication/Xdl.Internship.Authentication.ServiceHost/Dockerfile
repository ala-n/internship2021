#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Xdl.Internship.Authentication.ServiceHost/Xdl.Internship.Authentication.ServiceHost.csproj", "Xdl.Internship.Authentication.ServiceHost/"]
COPY ["Xdl.Internship.Authentication.Handlers/Xdl.Internship.Authentication.Handlers.csproj", "Xdl.Internship.Authentication.Handlers/"]
COPY ["Xdl.Internship.Authentication.DataAccess/Xdl.Internship.Authentication.DataAccess.csproj", "Xdl.Internship.Authentication.DataAccess/"]
COPY ["Xdl.Internship.Authentication.DTOs/Xdl.Internship.Authentication.DTOs.csproj", "Xdl.Internship.Authentication.DTOs/"]
COPY ["Xdl.Internship.Authentication.Models/Xdl.Internship.Authentication.Models.csproj", "Xdl.Internship.Authentication.Models/"]

COPY Xdl.Internship.Authentication.ServiceHost/NuGet.Config /

RUN dotnet restore "Xdl.Internship.Authentication.ServiceHost/Xdl.Internship.Authentication.ServiceHost.csproj" 
COPY . .
WORKDIR "/src/Xdl.Internship.Authentication.ServiceHost"
RUN dotnet build "Xdl.Internship.Authentication.ServiceHost.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Xdl.Internship.Authentication.ServiceHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xdl.Internship.Authentication.ServiceHost.dll"]
