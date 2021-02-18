#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Xdl.Internship.Notifications.ServiceHost/Xdl.Internship.Notifications.ServiceHost.csproj", "Xdl.Internship.Notifications.ServiceHost/"]
RUN dotnet restore "Xdl.Internship.Notifications.ServiceHost/Xdl.Internship.Notifications.ServiceHost.csproj"
COPY . .
WORKDIR "/src/Xdl.Internship.Notifications.ServiceHost"
RUN dotnet build "Xdl.Internship.Notifications.ServiceHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xdl.Internship.Notifications.ServiceHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xdl.Internship.Notifications.ServiceHost.dll"]