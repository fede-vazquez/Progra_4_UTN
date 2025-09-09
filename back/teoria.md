# Onion Architecture

Separar la lógica de un sistema por capas, siguiendo el principio de Single Responsibility

### SSR (Server Side Rendering)

El servidor es el encargado ejecutar todo el JavaScript y devolver todo el HTML ya renderizado.
Ayuda mucho al SEO

### CSR (Client Side Rendering)

Páginas webs que tienen mucho JavaScript en la propia página, haciendo que el cliente sea quien renderice todo el HTML.

# MVC (Modelo Vista Controlador)

Ya que vamos a trabajar con React, no vamos a usar la capa de "vista" en nuestros proyectos.
Nosotros vamos a usar una pseudo arquitectura (Modelo Controlador).
Además tendremos una capa para el servidor.

## Camino que recorren las peticiones.

**Vista -(services)- Controlador - Modelo -(ORM)- base de datos**

cada "-" representa un ida y vuelta de peticiones.

**orm**: Object Relational Mapping

## Existen 2 formas de escribir la base de datos

### Code first

Escribimos la base de datos en base a una sintaxis de objetos.
Escribimos primero el código y luego creamos la base de datos.

### Database first

Lo contrario al punto anterior.

## Patrones

1. DTO (Data Transfer Protocol): Abstraer los datos que mandamos entre las diferentes capas a solo lo necesario.
2. DI (Dependency Injection): Es lo mismo que el principio SOLID.
3. Repository: Es como un polimorfismo, pero a mas alto nivel (tiene mucho que ver con interfaces).

### Handlers

# Que vamos a usar

Visual Studio y SQL server

## Decoradores en C#

```C#

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase

```

Un decorador aplica a una clase a propiedad adentro de una clase a un método adentro de una clase o a un parámetro dentro del método de una clase.

### Swagger

Es una biblioteca para documentar código.

Si da error de privacidad cuando lo ejecutemos, apretamos donde esté el error y tipeamos "thisisunsafe"
