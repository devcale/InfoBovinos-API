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
	 
## Uso del API

### Crear Animal
Ruta: `POST /api/animales`
Para crear un animal, realizar una petición con un *body* similar al siguiente:
```json
{
  "nombre": "Via Lactea",
  "fechaNacimiento": "2012-11-17T17:40:48.000Z",
  "sexo": "Hembra",
  "precio": 1500,
  "estado": "Activo",
  "comentarios": "Via Láctea, la vaca más estelar de la granja. Su leche es la favorita de las constelaciones y sus sueños son tan grandes como el universo.",
  "razaId": 5
}
```
***CONSIDERACIONES IMPORTANTES***: 
- Asegurarse de que el Id de la raza apunte a una raza existente.
- El precio del animal debe ser mayor a 0
- El nombre de cada animal debe ser único

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/a25d9ca8-24f2-4c78-b2a2-4a4cc7a1619b)

### Obtener Animal por ID
Ruta: `GET /api/animales/{idAnimal}`

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/f48b730c-aa8a-4cab-ad05-1d054a801810)

### Obtener todos los Animales
Ruta: `GET /api/animales`

Para esta petición se utiliza paginación del lado del servidor, por lo que será necesario especificar el número de la página requerida y la cantidad de entidades que se desea obtener por página.

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/bfc4e9a4-a228-4966-b455-466fb705eeba)


### Editar Animal
Ruta: `PUT /api/animales/{idAnimal}`

Se debe tener en cuenta las mismas consideraciones que al momento de crear el animal.

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/941b88cb-638b-49e7-84e1-3bdac72e4043)


### Eliminar Animal
Ruta: `DELETE /api/animales/{idAnimal}`

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/9a3b5e82-518b-4adb-8fce-f725a4ae7724)


### Obtener número de Animales activos por Raza
Ruta: `GET /api/conteo-animal/activos-por-raza`

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/5d89d295-9145-45a4-a647-a5ba4e795441)


### Crear Raza
Ruta: `POST /api/razas`
Para crear una raza, realizar una petición con un *body* similar al siguiente:
```json
{
  "nombre": "Estelar",
}
```
***CONSIDERACIONES IMPORTANTES***: 
- Se debe crear una raza con un nombre distinto al de las razas ya existentes.

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/68d5a4e5-84df-40c4-a1f8-ff8ef57846bc)



### Obtener Raza por ID
Ruta: `GET /api/razas/{idRaza}`

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/6701d048-019d-465e-96c0-e28be05c6c33)


### Obtener todas las Razas
Ruta: `GET /api/razas`

Para esta petición se utiliza paginación del lado del servidor, por lo que será necesario especificar el número de la página requerida y la cantidad de entidades que se desea obtener por página.

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/c0bc2dd3-da71-4983-8c8c-8a5e83bc3c02)

### Editar Raza
Ruta: `PUT /api/razas/{idRaza}`


Se debe tener en cuenta las mismas consideraciones que al momento de crear la raza.

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/60c374e0-040e-4590-977c-5aa2f5560dfc)


### Eliminar Raza
Ruta: `DELETE /api/razas/{idRaza}`

*Demo de la petición:*
![imagen](https://github.com/devcale/InfoBovinos-API/assets/65783607/5f496911-8557-4b37-98c6-6a95988f3c63)



