#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV USING_DOCKER=true

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DbBenchmark/DbBenchmark.csproj", "DbBenchmark/"]
COPY . .
RUN dotnet restore "DbBenchmark/DbBenchmark.csproj"
WORKDIR "/src/DbBenchmark"
RUN dotnet build "DbBenchmark.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DbBenchmark.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DbBenchmark.dll"]