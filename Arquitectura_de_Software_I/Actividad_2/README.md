# 🧩 Patrones y estilos arquitectónicos

Diseñar arquitecturas de software utilizando **estilos y patrones arquitectónicos reconocidos**, asegurando que las soluciones propuestas sean:

- 📈 Escalables
- 🧩 Mantenibles
- 📋 Alineadas con los requisitos técnicos y del negocio

## 📊 Indicadores de desempeño

Evaluar la **calidad de las arquitecturas de software** mediante la aplicación de técnicas de evaluación y aseguramiento de atributos de calidad, como:

- ⚡ Rendimiento
- 🔐 Seguridad
- 🛡️ Fiabilidad

Usando herramientas y metodologías avanzadas 🧪.

## 📝 Descripción

En grupos de 4 o 5 estudiantes deberán organizar una presentación en la cual aborden el patrón y/o estilo arquitectónico asignado durante la clase. 

Durante la investigación que realicen sobre el `patrón/estilo` deberán presentar una PPT que contenga:

- ✅ Ventajas
- ❎ Desventajas
- ❔ Cuando usarse y cuando no usar el patrón/estilo junto con la bibliografía.
 
Adicional a la PPT los estudiantes deberán presentar el `Demo` del tema asignado, mostrando su funcionamiento en tiempo real a los demás estudiantes del aula

___
___

## 🧪 Tema Asignado

**_Reglas de Diseño y Beneficios de la Arquitectura REST API_**


- [URL PRESENTACIÓN: [Ir]](https://gamma.app/docs/Reglas-de-Diseno-y-Beneficios-de-la-Arquitectura-REST-APIpptx-kw2dzuwps04om0p)
 
- [POC: [Ir]](http://restful.somee.com/swagger/index.html)
    - Que se presento en la POC
      - Metodos: 
        - GET -> Consultar
        - POST -> Crear
        - PUT -> Editar completo
        - DELETE -> Eliminar (esta en la V2)
      - API Version:
        - **V1:** Implementacion de los metodos `GET`, `POST`, `PUT`
        - **V2:** Se modifica el metodo `GET` para obtiener los registros con paginación (_metadata de paginación en los RESPONSE-HEADERS_)
        - **V2:** Se implemento el metodo `DELETE`
      - RateLimit
        - Retorna `StatusCode 429` cuando detecta `ManyRequests` (_enviar multiples peticiones GET seguidas_)
      - StatusCodes
        - **200:** Ok
        - **201:** Created
        - **204:** NotContent
        - **400:** BadRequest
        - **404:** NotFount
        - **429:** ManyRequest
      - Problem details
        - Todos los `Statuscode` `400 - 599`, responden con el estandar del `rfc9457` (https://www.rfc-editor.org/rfc/rfc9457.html)
      - Documentacion con OpenApi y visualizacion con Swagger
        - http://restful.somee.com/swagger/v1/swagger.json
        - http://restful.somee.com/swagger/v2/swagger.json

- [CODIGO FUENTE: [Ir]](./Source)