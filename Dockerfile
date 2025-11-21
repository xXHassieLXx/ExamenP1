FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App

# Copiar todo el código
COPY . ./

# QUITAR: Estos RUN ls no son necesarios en producción
# RUN ls
# RUN ls /App/NatureAPI

# Restaurar dependencias
RUN dotnet restore

# CAMBIAR: Agregar propiedades para evitar conflictos de appsettings
RUN dotnet publish /App/NatureAPI/NatureAPI.csproj -c Release -o /App/build -p:PublishCopyInputFilesToOutputDirectory=false


# Construir imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# OPTIMIZAR: Consolidar comandos apt-get
RUN apt-get update -qq && \
    apt-get -y install libgdiplus libc6-dev wget fontconfig && \
    rm -rf /var/lib/apt/lists/*

# Descargar fuentes Poppins
RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v

WORKDIR /App

# Copiar binarios compilados
COPY --from=build-env /App/build .

# Permisos de ejecución
RUN chmod 755 /App/Rotativa/Linux/wkhtmltopdf

ENTRYPOINT ["dotnet", "NatureAPI.dll"]
