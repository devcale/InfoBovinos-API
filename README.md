# Gestión de Información de Bovinos - API REST

Este proyecto consiste en el desarrollo de una API REST que gestiona la información de animales bovinos en una granja. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) tanto para los animales como para los tipos de razas a los que pertenecen. Además de esto, se puede obtener la cantidad de animales activos por raza que hay en la granja.

## Características Principales

-   **Animales:** Permite manejar la información detallada de cada bovino, incluyendo datos como su nombre, fecha de nacimiento, sexo, precio y estado (activo o inactivo).
-   **Razas:** Gestiona los diferentes tipos de razas a las que pueden pertenecer los bovinos, con funcionalidades similares a las de los bovinos.

## Funcionalidades Clave

-   **Obtención de Entidades:** Permite obtener información detallada de un bovino o raza por su identificador, así como obtener todas las entidades con paginación del lado del servidor.
-   **Creación, Edición y Eliminación:** Permite realizar operaciones para crear, editar y eliminar bovinos y razas de manera precisa y sencilla.
-   **Conteo de Bovinos Activos por Raza:** Ofrece un servicio que muestra el número de bovinos activos agrupados por su raza.

## Tecnologías Utilizadas

-   **ASP .NET 6:** Se utiliza ASP .NET 6 para el desarrollo de la API REST.
-   **SQLite:** Se optó por SQLite debido a su facilidad de implementación y portabilidad. Es una opción ligera que no requiere un servidor separado, lo que simplifica la configuración y el despliegue del proyecto. 
-   **Entity Framework:** Se eligió Entity Framework para la configuración y el manejo de entidades en la base de datos por su capacidad de abstracción, facilitando el manejo de la capa de acceso a datos y simplificando las operaciones CRUD.
- **LINQ (Language Integrated Query):** Fue utilizado para realizar consultas directamente en la colección de datos, lo que permite realizar operaciones de consulta de manera más legible y estructurada.
- **Fluent API:** El uso de Fluent API permite definir reglas específicas, restricciones y relaciones entre entidades de manera programática, otorgando un mayor control sobre la estructura de la base de datos.
-   **FluentValidation:** Se eligió FluentValidation para la validación de datos en la API debido a que proporciona una forma declarativa y altamente legible de definir reglas de validación para los modelos de datos, permitiendo una validación robusta y personalizable en la capa de presentación sin acoplarla al modelo subyacente.
- **Swagger:** Implementación de Swagger para la documentación interactiva y la visualización de la API, facilitando su comprensión y uso por parte de los desarrolladores.

## Instrucciones de Instalación

### Requisitos Previos

-   **IDE:** Tener instalado un IDE compatible con ASP.NET 6. Recomiendo utilizar [Visual Studio 2022](https://visualstudio.microsoft.com/es/free-developer-offers/).
-   **.NET SDK:** Asegurarse de tener instalado el SDK de .NET 6 o superior.

### Pasos para la Instalación del API

1.  **Clonar el Repositorio:**   
	 `git clone https://github.com/devcale/InfoBovinos-API.git` 
    
2.  **Acceder al Directorio del Proyecto Mediante Tu IDE:**
	Abre tu IDE de elección y accede al directorio del proyecto que acabas de clonar.
    
3.   **Instalar Dependencias:**
Utilizando una terminal, navega al directorio del proyecto que contiene el archivo `.csproj` y ejecuta el comando:     
`dotnet restore`

### Pasos para configurar la Base de Datos SQLite
1. **Creación de la Migración Inicial:**
En la terminal o en la consola de comandos, navega hasta el directorio raíz del proyecto donde se encuentra el archivo `.csproj` del proyecto.
    
	Ejecuta el siguiente comando para crear la migración inicial:   

	`dotnet ef migrations add InitialCreate` 

	Esto generará una migración inicial basada en el modelo de datos actual.

2. **Aplicación de las Migraciones:**
Luego de haber creado la migración inicial, ejecuta el siguiente comando para aplicarla y crear la estructura de la base de datos:
 
	`dotnet ef database update` 

	Esto aplicará todas las migraciones pendientes y creará la base de datos SQLite.

### Pasos para poblar la Base de Datos con el script SQL incluido
1. En la terminal o en la consola de comandos, accede al directorio `/Data`, en donde se encuentra el archivo
 `POBLAR DB.sql`.
 2. Ejecuta el script SQL en tu herramienta de gestión de bases de datos SQLite o a través de la línea de comandos SQLite:
  `sqlite3 bovinosdb.db < script.sql`
	 
