FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "Presentation/Practices.Presentation.csproj" -c Release -o /Practices

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /Practices
COPY --from=build /Practices ./
EXPOSE $PORT
ENTRYPOINT ["dotnet", "Practices.Presentation.dll"]