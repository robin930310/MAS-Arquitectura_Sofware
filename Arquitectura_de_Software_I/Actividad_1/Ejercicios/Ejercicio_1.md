# 🚗 Descripción del Escenario

Imagina que estás desarrollando una aplicación para una compañía automotriz que permite a los clientes personalizar y ordenar un automóvil. 🏭📱

Un objeto **Automóvil** puede tener muchas configuraciones opcionales:

- ⚙️ Tipo de motor
- 🎨 Color
- 🚙️ Llantas
- 🔊 Sistema de sonido
- 🛋️ Interiores
- 🌞 Techo solar
- 🗺️ Navegación GPS
- ➕ Etc...

## ⚠️ Problema

Crear un objeto Automóvil con múltiples configuraciones puede llevar a constructores con muchos parámetros (el infame _`"constructor telescópico"`_) o a múltiples constructores sobrecargados, lo que dificulta el mantenimiento y legibilidad del código. 🧩

## 💡 Beneficios esperados de la solución

- 📖 **Legibilidad y claridad:** Facilitar la creación de objetos complejos con muchos parámetros sin necesidad de múltiples constructores o valores por defecto.
- 🛡️ **Inmutabilidad:** Una vez creado el objeto, sus propiedades no se pueden modificar si el constructor lo define como inmutable.
- 🧩 **Flexibilidad:** Poder omitir atributos opcionales sin necesidad de crear subclases o múltiples constructores.
- 🧠 **Separación de construcción y representación:** Separar la lógica de construcción del objeto en sí, facilitando modificaciones futuras.

___

# 🧩 Solución

## 🏷️ Tipo de patrón

XXXXX

## 🧠 Patrón de diseño

XXXXX

## 🖼️ Diagrama de clases

![Diagrama de clases](../Diagramas/Clases__Ejercicio_1.drawio.svg)

## 💻 Código

```csharp
public class Program
{
    
}
```