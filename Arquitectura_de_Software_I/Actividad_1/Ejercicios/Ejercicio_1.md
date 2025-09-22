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

---

# 🧩 Solución

## 🏷️ Tipo de patrón

**Creacional**  
Este patrón se centra en **cómo se crean los objetos**, especialmente cuando son complejos y tienen muchos atributos opcionales. Permite separar la construcción de la lógica del objeto y facilita la flexibilidad y mantenimiento del código.

## 🧠 Patrón de diseño

**Builder**

Se seleccionó este patrón porque se necesita crear el objeto `Automovil` que puede tener muchísimas configuraciones. Sin el patrón, necesitaríamos constructores gigantes o muchas subclases para cubrir todas las combinaciones posibles, lo que haría el código difícil de mantener.

### Qué aportan:

- **Builder:** Permite armar autos paso a paso, seleccionando solo las opciones deseadas sin tener que llenar todo desde el principio. Mantiene el objeto inmutable una vez creado, evitando errores.

- **Director:** Centraliza la construcción de autos según recetas prediseñadas (lujo, básico, deportivo), evitando duplicación de código y asegurando consistencia.

### Cómo se utilizó en el proyecto:

1. **AutomovilBuilder:** Permite construir un auto paso a paso, pudiendo modificar cualquiera de sus atributos opcionales.

**Ejemplo práctico:**  
Se toma un auto de lujo existente y se crea una “Edición Especial” cambiando solo algunas propiedades como color y modelo. Gracias a Builder, esto se hace fácilmente sin tocar la lógica del auto original ni repetir código.

## 🖼️ Diagrama de clases

![Diagrama de clases](../Diagramas/Clases__Ejercicio_1.drawio.svg)

## 💻 Código

- [Clase program](./../Source/Ejercicio_1/Program.cs)
- [Clase Director](./../Source/Ejercicio_1/Builders/Director.cs)
- [Interfaz IAutomovilBuilder](./../Source/Ejercicio_1/Builders/IAutomovilBuilder.cs)
- [Clase AutomovilBuilder](./../Source/Ejercicio_1/Builders/AutomovilBuilder.cs)
- [Clase Automovil](./../Source/Ejercicio_1/Models/Automovil.cs)
