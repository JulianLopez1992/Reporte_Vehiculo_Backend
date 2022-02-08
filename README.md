# Reporte_Vehiculo_Backend
Tecnologías: .Net Core - C# - Entity Framework

# API Estaciones

Esta API se encarga de mostrar la información detallada de las Estaciones y el reporte ponderado de cada una de ellas en las diferentes fechas registradas.

Para la carga de la información de las estaciones (Documentación de API Conteo y Recaudo — documentación de API Conteo y Recaudo - v1.0.0) en la base de datos se desarrolló una ETL, la cual se encarga de consumir los siguientes EndPoints:
* Petición de conteo de vehículos por día 
* Petición de recaudo de vehiculos por día
Enviando por parámetros las fechas comprendidas desde el 2020 a la actual.

El API F2x consta de 4 Endpoints:
+ GetInfoVehiculos.
+ GetConteoVehiculos
+ GetRecaudoVehiculos
+ GetReporteVehiculos


# Ejecución
Una vez descargado la solución se deben restaurar los paquetes Nuget correspondientes a Entity Framework que son usados en el proyecto Repositorio:

Opción 1: Seleccionar proyecto Repositorio -> Dependencias -> Paquetes: Click derecho -> Actualizar.
Opción 2: Desde la terminal CLI ejecutar el comando: > Update-Package -Reinstall -ProjectName Repositorio

*Nota*: Se debe tener presente el puerto en el cual se ejecutará la API, para de ser necesario configurar el proyecto frontend.