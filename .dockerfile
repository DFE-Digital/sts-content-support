FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /
EXPOSE 8080 

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /
COPY src/ src/
RUN dotnet publish "src/Dfe.ContentSupport.Web/Dfe.ContentSupport.Web.csproj" -c Release -o /out/publish
RUN rm -rf /src

FROM base AS final
WORKDIR /src
RUN useradd -m dotnet
COPY --from=build /out/publish .
RUN chown dotnet:dotnet /src .
USER dotnet
ENTRYPOINT ["dotnet", "Dfe.ContentSupport.Web.dll"]