#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Xdl.Internship.Offers.ServiceHost/Xdl.Internship.Offers.ServiceHost.csproj", "Xdl.Internship.Offers.ServiceHost/"]
COPY ["Xdl.Internship.Offers.Handlers/Xdl.Internship.Offers.Handlers.csproj", "Xdl.Internship.Offers.Handlers/"]
COPY ["Xdl.Internship.Offers.DataAccess/Xdl.Internship.Offers.DataAccess.csproj", "Xdl.Internship.Offers.DataAccess/"]
COPY ["Xdl.Internship.Offers.SDK/Xdl.Internship.Offers.SDK.csproj", "Xdl.Internship.Offers.SDK/"]
COPY ["Xdl.Internship.Offers.Models/Xdl.Internship.Offers.Models.csproj", "Xdl.Internship.Offers.Models/"]

COPY Xdl.Internship.Offers.ServiceHost/NuGet.Config /

RUN dotnet restore "Xdl.Internship.Offers.ServiceHost/Xdl.Internship.Offers.ServiceHost.csproj"
COPY . .
WORKDIR "/src/Xdl.Internship.Offers.ServiceHost"
RUN dotnet build "Xdl.Internship.Offers.ServiceHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xdl.Internship.Offers.ServiceHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xdl.Internship.Offers.ServiceHost.dll"]