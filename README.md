# Laboratorio 1 - Arquitectura de Software

A continuación, se incluyen las instrucciones de confguración, compilación y despliegue del proyecto.

Requisitos: 

- .Net Core con complementos de ASP.NET y Web, almacenamiento de datos y .Net framework

- Visual Studio 2022
- SQL Server Express 2019 


Instalar SQL Server con los valores por defecto, y proveer el modelo de datos proporcionado para el Laboratorio
Encontrará los Scripts en la carpeta DATABASE.
Ejecute primero el archivo DBCreation_DDL para crear el esquema y posteriormente el test_data para llenar la base de datos con datos de prueba.

El puerto a utilizar es el 5123

Abra el proyecto sobre la carpeta personapi-dotnet para poder ver todo el contenido.
Instale (si no tiene) los siguientes paquetes NuGet en dependencias:
-Microsoft.EntityFrameworkCore
-Microsoft.EntityFrameworkCore.SqlServer
-Microsoft.EntityFrameworkCore.Tools
-Swashbuckle.AspNetCore
-Swashbuckle.AspNetCore.Swagger
-Swashbuckle.AspNetCore.SwaggerGen
-Swashbuckle.AspNetCore.SwaggerUI
-Microsoft.AspNetCore.OpenApi
-Microsoft.VisualStudio.Web.CodeGeneration.Desig

Ejecute el proyecto y verá en la navbar cada uno de los componentes del proyecto.

Para ver los endpoints, ejecute la url http://localhost:5123/swagger/index.html