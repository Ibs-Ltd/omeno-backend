#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Asp.Omeno.Service.Api/Asp.Omeno.Service.Api.csproj", "src/Asp.Omeno.Service.Api/"]
COPY ["src/Asp.Omeno.Service.Persistence/Asp.Omeno.Service.Persistence.csproj", "src/Asp.Omeno.Service.Persistence/"]
COPY ["src/Asp.Omeno.Service.Application/Asp.Omeno.Service.Application.csproj", "src/Asp.Omeno.Service.Application/"]
COPY ["src/Asp.Omeno.Service.Common/Asp.Omeno.Service.Common.csproj", "src/Asp.Omeno.Service.Common/"]
COPY ["src/Asp.Omeno.Service.Domain/Asp.Omeno.Service.Domain.csproj", "src/Asp.Omeno.Service.Domain/"]
RUN dotnet restore "src/Asp.Omeno.Service.Api/Asp.Omeno.Service.Api.csproj"
COPY . .
WORKDIR "/src/src/Asp.Omeno.Service.Api"
RUN dotnet build "Asp.Omeno.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asp.Omeno.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asp.Omeno.Service.Api.dll"]