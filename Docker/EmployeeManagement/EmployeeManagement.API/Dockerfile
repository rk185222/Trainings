#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./EmployeeManagement.API/EmployeeManagement.API.csproj"
RUN dotnet build "./EmployeeManagement.API/EmployeeManagement.API.csproj" -c Release -o /app/build
RUN dotnet publish "./EmployeeManagement.API/EmployeeManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "EmployeeManagement.API.dll"]

