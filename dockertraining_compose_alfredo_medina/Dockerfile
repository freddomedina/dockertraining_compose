#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["dockertraining_compose_alfredo_medina/dockertraining_compose_alfredo_medina.csproj", "dockertraining_compose_alfredo_medina/"]
RUN dotnet restore "dockertraining_compose_alfredo_medina/dockertraining_compose_alfredo_medina.csproj"
COPY . .
WORKDIR "/src/dockertraining_compose_alfredo_medina"
RUN dotnet build "dockertraining_compose_alfredo_medina.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dockertraining_compose_alfredo_medina.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dockertraining_compose_alfredo_medina.dll"]