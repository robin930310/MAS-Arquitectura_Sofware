# 📣 Descripción del Escenario

Estás desarrollando una aplicación que gestiona la visualización de notificaciones en diferentes plataformas (por ejemplo: 💻 escritorio, 📱 móvil, 🌐 web).  
Las notificaciones pueden ser de distintos tipos:

- 💌 Mensaje
- 🚨 Alerta
- ⚠️ Advertencia
- ✅ Confirmación

Cada tipo puede mostrarse de distintas formas según la plataforma.

## ⚠️ Problema

Si usas herencia tradicional, tendrías que crear clases como:

- 🧩 `NotificacionMensajeWeb`
- 🧩 `NotificacionAlertaWeb`
- 🧩 `NotificacionMensajeMovil`
- 🧩 `NotificacionAlertaMovil`
- 🧩 ...

Esto lleva rápidamente a una **explosión combinatoria de subclases** difíciles de mantener. 💥

## 💡 Beneficios esperados de la solución

- 🧠 **Separación de responsabilidades:** Separar la lógica de la notificación del medio por el que se presenta.
- 📈 **Escalabilidad:** Poder agregar nuevas plataformas o tipos de notificación sin modificar el resto del sistema.
- 📦 **Reducción de clases:** Evitar la multiplicación de clases para cada combinación.
- 🔁 **Flexibilidad en tiempo de ejecución:** Poder cambiar la plataforma dinámicamente si es necesario.

___

# 🧩 Solución

## 🏷️ Tipo de patrón

XXXXX

## 🧠 Patrón de diseño

XXXXX

## 🖼️ Diagrama de clases

![Diagrama de clases](../Diagramas/Clases__Ejercicio_2.drawio.svg)

## 💻 Código

```csharp
public class Program
{
    
}
```