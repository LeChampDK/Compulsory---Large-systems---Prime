#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PrimeAPI-1/PrimeAPI-1.csproj", "PrimeAPI-1/"]
RUN dotnet restore "PrimeAPI-1/PrimeAPI-1.csproj"
COPY . .
WORKDIR "/src/PrimeAPI-1"
RUN dotnet build "PrimeAPI-1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PrimeAPI-1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrimeAPI-1.dll"]