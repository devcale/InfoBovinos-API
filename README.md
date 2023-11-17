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
