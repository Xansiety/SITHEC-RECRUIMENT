## SITHEC Prueba

## Nombre aplica:

> Luis Fernando Hernandez Jimenez


## Desarrollo


Desarrollo de back end en .NET CORE el cual debe de tener las siguientes características

- [x] API tipo GET que retorne un arreglo de objetos de tipo “HUMANO”, esta información será mock
- [x] API tipo POST que se envíen 3 argumentos para la realización de una operación matemática y retorne el resultado
- [x] API tipo GET que reciba 3 argumentos en Headers argumentos para la realización de una operación matemática y retorne el resultado
- [x] Creación de migración para una base de datos con tabla humanos
- [x] API tipo GET para traer toda la tabla de humanos
- [x] API tipo GET para traer un humano en especifico
- [x] API tipo POST para crear un humano
- [x] API tipo PUT para editar un humano


## Como correr el proyecto

> 1.- En appsetting.development.json -> Modificar la cadena de conexión.

> 2.- Ejecutar mediante la "Consola Del Administrador de Paquetes" el comando

En Visual studio

```sh
 Update-Database
```

o en Visual Studio code (tener instalado dotnet ef tool, se puede instalar con el comando: `dotnet tool install --global dotnet-ef`)

```sh
 dotnet ef database update
```

## Postman collection

Se añadio una colleccion de postman para realizar pruebas, a los endpoints del api; en el folder `Posman`
