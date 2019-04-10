FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["GAB.LabDashboard.Web/GAB.LabDashboard.Web.csproj", "GAB.LabDashboard.Web/"]
RUN dotnet restore "GAB.LabDashboard.Web/GAB.LabDashboard.Web.csproj"
COPY . .
WORKDIR "/src/GAB.LabDashboard.Web"
RUN dotnet build "GAB.LabDashboard.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GAB.LabDashboard.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GAB.LabDashboard.Web.dll"]