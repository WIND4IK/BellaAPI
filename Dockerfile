FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /source
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

COPY /source/*.csproj .
RUN dotnet restore
COPY /source .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT ["dotnet", "BellaAPI.dll"]
