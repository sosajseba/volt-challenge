# VoltChallenge

Este proyecto procesa datos de consumo eléctrico y producción solar, calculando el consumo total compensado y generando un reporte en formato JSON.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Archivos de Entrada

Asegurate de tener los siguientes archivos JSON en en la raíz del proyecto:

- `miami_household_consumption_with_timestamps.json`
- `miami_solar_output_with_timestamps.json`

La estructura de la carpeta debe ser la siguiente:

```
volt-challenge/
│
├── ...
├── miami_household_consumption_with_timestamps.json
└── miami_solar_output_with_timestamps.json
```

## Configuración de Docker Compose

El archivo `docker-compose.yml` está configurado para mapear los archivos JSON desde la raíz y generar el reporte en la carpeta `reports`.

Si necesitas cambiar los nombres de los archivos, podes editar las siguientes líneas en `docker-compose.yml`:

```yaml
version: '3.8'

services:
  tu-app:
    build: 
      context: .
      dockerfile: Dockerfile
    environment:
      - HOUSEHOLD_FILE_PATH=miami_household_consumption_with_timestamps.json # Nombre de archivo de consumo del hogar
      - SOLAR_FILE_PATH=miami_solar_output_with_timestamps.json # Nombre de archivo de panel solar
      - REPORT_FILE_PATH=/app/reports/total_consumption_report.json # Nombre de archivo de salida
    volumes:
      - ./reports:/app/reports
```

## Ejecución del Proyecto

1. Navegá a la raíz del proyecto donde está ubicado `docker-compose.yml`.
2. Ejecutá el siguiente comando para construir y ejecutar el contenedor:

```bash
docker-compose up
```

3. El reporte se generará en la carpeta `reports` en la raíz del proyecto con el nombre `total_consumption_report.json`.

## Reporte Generado

El reporte generado en `reports/total_consumption_report.json` contendrá una lista de objetos `ReportItem`, cada uno con el timestamp, el consumo total compensado (en kW) y el ahorro (en dólares).

## Notas Adicionales

- Asegurate de que Docker esté corriendo en tu sistema antes de ejecutar `docker-compose up`.