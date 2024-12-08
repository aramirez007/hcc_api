# Usa la imagen base de .NET SDK para la construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS aux
# Cambiar el nombre del directorio de trabajo para evitar espacios
WORKDIR /app/HCC_API_ADRIAN_RAMIREZ_SALAZAR

EXPOSE 80
EXPOSE 5001

# Copiar solo el archivo .csproj primero para optimizar la caché
COPY ./*.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y publicar
COPY . . 
RUN dotnet publish -c Release -o /app/HCC_API_ADRIAN_RAMIREZ_SALAZAR/Docker_HCCAPI

# Usar una imagen base más ligera para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app/HCC_API_ADRIAN_RAMIREZ_SALAZAR
# Copiar los archivos publicados desde la etapa anterior
COPY --from=aux /app/HCC_API_ADRIAN_RAMIREZ_SALAZAR/Docker_HCCAPI . 

# Configurar el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "HCC_API_ADRIAN_RAMIREZ_SALAZAR.dll"]
