FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /src
EXPOSE 80
#EXPOSE 443
ENV ASPNETCORE_URLS=https://*:80

COPY /src/*.csproj .
RUN dotnet restore
COPY /src .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT ["dotnet", "BellaAPI.dll"]
