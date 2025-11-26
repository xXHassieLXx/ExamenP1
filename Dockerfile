FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App
# Copy everything
COPY . ./

RUN ls
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN ls /App/NatureAPI
RUN dotnet publish /App/NatureAPI/NatureAPI.csproj -c Release -o /App/build


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim
RUN echo "deb http://snapshot.debian.org/debian bookworm main" > /etc/apt/sources.list && \
    apt-get update -qq && apt-get -y install --no-install-recommends libgdiplus libc6-dev || true
RUN apt-get update && apt-get install -y --no-install-recommends wget fontconfig || true

RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    (wget -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf || true) && \
    (wget -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf || true) && \
    (fc-cache -f -v || true)
WORKDIR /App
COPY --from=build-env /App/build .
#RUN chmod 755 /App/Rotativa/Linux/wkhtmltopdf
ENTRYPOINT ["dotnet", "NatureAPI.dll"]

 