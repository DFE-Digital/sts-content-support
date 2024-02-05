FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /
# Copy everything
COPY src/ src/
# Restore as distinct layers
#RUN dotnet restore
# Build and publish a release
RUN dotnet publish "src/App/DotNet.Docker.csproj" -c Release -o /out/publish
RUN rm -rf /src


# Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:8.0
FROM base AS final
WORKDIR /src
RUN useradd -m dotnet
COPY --from=build /out/publish .
RUN chown dotnet:dotnet /src .
USER dotnet
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]