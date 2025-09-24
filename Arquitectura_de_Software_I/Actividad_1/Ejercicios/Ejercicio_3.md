# 💬 Descripción del Escenario

Estás desarrollando una aplicación de **chat grupal**.  
Los usuarios pueden enviarse mensajes entre sí dentro de una sala de chat. 💻📱

Sin embargo, gestionar las interacciones directas entre cada usuario haría que cada uno deba conocer y comunicarse con todos los demás, lo que resulta en una **alta dependencia entre objetos**. 🧩🕸️

## ⚠️ Problema

Sin un **mediador**, cada usuario tendría que mantener referencias directas a todos los demás, lo que genera un sistema **difícil de escalar y mantener**. ⚡  
Si agregas o eliminas usuarios, debes actualizar muchas relaciones. 🔁

## 💡 Beneficios esperados de la solución

1. 🛠️ **Facilita el mantenimiento:** Agregar o eliminar usuarios no debe requerir modificar los demás.
2. 🗂️ **Mejor organización:** La lógica de comunicación debe estar centralizada, no dispersa en muchos objetos.
3. 📉 **Reduce la complejidad:** Evitar una red enmarañada de interacciones punto a punto.

---

# 🧩 Solución

## 🏷️ Tipo de patrón

**Comportamiento**  
Los patrones de comportamiento se enfocan en cómo se comunican y colaboran los objetos entre sí, no en cómo se crean o estructuran.
Es decir, te ayudan a organizar la lógica de interacción para que el sistema sea más limpio, flexible y fácil de mantener.

## 🧠 Patrón de diseño

**Mediator**
Mediator fue elegido porque en un chat grupal ningún usuario debería saber de todos los demás directamente.
Sin un mediador, cada usuario tendría que mantener referencias a todos los demás, lo que hace que:

- El código se vuelva enredado y difícil de escalar.
- Cada cambio (nuevo usuario, nueva sala) pueda romper la lógica de comunicación existente.
- El Mediator resuelve esto al centralizar la comunicación en un único objeto (el ChatRoom), que actúa como intermediario.

**Qué aporta Mediator:**

- Centraliza la comunicación: Todos los mensajes pasan por el mediador; los usuarios no necesitan referencias directas entre sí.
  Ejemplo: Laura envía un mensaje, el ChatRoom lo entrega a todos los miembros registrados. Ningún usuario necesita saber quién más está en la sala.

- Facilita la escalabilidad: Puedes agregar nuevos usuarios o salas sin modificar la lógica de los demás miembros.
  Ejemplo: Añadir un nuevo usuario no requiere que todos los demás se actualicen con referencias nuevas.

- Reduce la complejidad: Los usuarios solo interactúan con el mediador, no con todos los demás.
  Ejemplo: En lugar de que cada usuario guarde una lista de todos los contactos, solo conoce su sala de chat.

- Mantiene la flexibilidad: Se pueden crear múltiples salas o canales sin cambiar la implementación de los usuarios.
  Ejemplo: Laura puede pertenecer a varias salas (Trabajo, Amigos) y el mediador se encarga de que los mensajes lleguen correctamente a cada grupo.

## ✅ Integración con principios SOLID

El uso de Mediator permite respetar varios principios SOLID:

**S** – Single Responsibility Principle (SRP):
Cada clase tiene una única responsabilidad. - User: manejar la información y acciones de un usuario. - ChatRoom: manejar la distribución de mensajes.
No mezclamos la lógica de envío de mensajes con la de almacenamiento de usuarios.

**O** – Open/Closed Principle (OCP):
Podemos agregar nuevas salas o tipos de mediadores sin modificar las clases existentes.

**L** – Liskov Substitution Principle (LSP):
ChatRoom implementa IChannel, por lo que cualquier mediador alternativo puede reemplazarlo sin romper la comunicación.

**I** – Interface Segregation Principle (ISP):
IChannel define solo los métodos necesarios (Register y Send), evitando que los usuarios dependan de funcionalidades que no usan.

**D** – Dependency Inversion Principle (DIP):
Los usuarios dependen de interfaces (IChannel) y no de implementaciones concretas (ChatRoom). Esto hace que el sistema sea más flexible y fácil de probar.

**Otros patrones de comportamiento que podrían sonar, pero no encajan**

- Observer: Permite notificar a muchos observadores, pero cada usuario tendría que suscribirse a todos → difícil de manejar cuando hay muchos usuarios.

- Command: Encapsula acciones, útil para comandos o tareas, pero no para centralizar comunicación.

- Chain of Responsibility: Pasa solicitudes en cadena, perfecto para decisiones secuenciales, pero aquí queremos difusión inmediata a todos los usuarios.

## 🖼️ Diagrama de clases

![Diagrama de clases](../Diagramas/Clases__Ejercicio_3.drawio.svg)

## 💻 Código

**Cómo se utilizó en el proyecto**

- [`IChannel`](./../Source/Ejercicio_3/Mediator/IChannel.cs): Interfaz que define las operaciones básicas de registro y envío de mensajes.
- [`ChatRoom`](./../Source/Ejercicio_3/Mediator/ChatRoom.cs): Implementación concreta del mediador que registra usuarios y distribuye los mensajes.
- [`User`](./../Source/Ejercicio_3/Entities/User.cs): Cada usuario conoce solo al mediador y usa los métodos `Send` y `Receive`.
- [`Message`](./../Source/Ejercicio_3/Entities/Message.cs): Representa el contenido de un mensaje (remitente, texto, timestamp, leídos).
- [`IMessageNotifier`](./../Source/Ejercicio_3/Services/IMessageNotifier.cs) y [`ConsoleMessageNotifier`](./Services/ConsoleMessageNotifier.cs): Notificadores que muestran los mensajes en la consola.
- [`Program`](./../Source/Ejercicio_3/Program.cs): Punto de entrada que arma la aplicación, crea usuarios, salas y maneja la CLI.

## 📌 Conclusión

El patrón Mediator nos permitió:
✅ Quitar la maraña de conexiones entre usuarios.
✅ Centralizar la comunicación en un solo punto (ChatRoom).
✅ Preparar el sistema para crecer sin romper nada.
