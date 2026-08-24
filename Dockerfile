FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["SimpleCalculator.csproj", "./"]
RUN dotnet restore "SimpleCalculator.csproj"

COPY . .
RUN dotnet publish "SimpleCalculator.csproj" --configuration Release --no-restore --output /app/publish

FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SimpleCalculator.dll"]
