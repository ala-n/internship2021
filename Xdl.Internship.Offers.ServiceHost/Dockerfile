#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Xdl.Internship.Offers.ServiceHost/Xdl.Internship.Offers.ServiceHost.csproj", "Xdl.Internship.Offers.ServiceHost/"]
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