FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App
COPY . ./
RUN dotnet restore
RUN dotnet publish /App/NatureAPI/NatureAPI.csproj -c Release -o /App/build --no-self-contained -p:PublishTrimmed=false -p:DebugType=embedded

FROM mcr.microsoft.com/dotnet/aspnet:9.0
RUN apt-get update --fix-missing && apt-get -y install libgdiplus libc6-dev wget fontconfig
RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v
WORKDIR /App
COPY --from=build-env /App/build .
RUN chmod 755 /App/Rotativa/Linux/wkhtmltopdf
ENTRYPOINT ["dotnet", "NatureAPI.dll"]
