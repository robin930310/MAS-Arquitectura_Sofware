# Patrón Mediator: Sistema de Chat Grupal

**Universidad | Arquitectura de Software | Taller de Patrones de Diseño – Ejercicio 3**

---

## 📑 Tabla de Contenidos

1. [Introducción](#1-introduccion)
2. [Análisis del Escenario](#2-analisis-del-escenario)
3. [Justificación del Patrón Mediator](#3-justificacion-del-patron-mediator)
4. [Implementación de la Solución](#4-implementacion-de-la-solucion)
5. [Arquitectura del Sistema](#5-arquitectura-del-sistema)
6. [Beneficios Obtenidos](#6-beneficios-obtenidos)
7. [Características Avanzadas](#7-caracteristicas-avanzadas)
8. [Conclusiones](#8-conclusiones)

---

## 1. Introducción

Este documento presenta el análisis, diseño e implementación de un sistema de **chat grupal** utilizando el **Patrón Mediator**.

**Objetivo Principal:**  
Demostrar la aplicación práctica del Patrón Mediator para reducir la dependencia y acoplamiento en sistemas de comunicación multi-objeto.

---

## 2. Análisis del Escenario

### ⚠️ Problema Original

En sistemas de chat tradicionales:

- Cada usuario debe conocer a todos los demás participantes.
- Agregar o eliminar usuarios requiere modificar múltiples clases.
- La lógica de comunicación está dispersa en cada usuario.
- Mantenimiento complejo: cambios en comunicación afectan múltiples componentes.

### 💡 Complejidad sin Mediator

```
Usuario A ↔ Usuario B ↔ Usuario C ↔ Usuario D
Complejidad: O(n²) dependencias
```

---

## 3. Justificación del Patrón Mediator

### 3.1 Comparación con otros patrones

| Patrón   | Ventajas                                                                              | Desventajas para este escenario        |
| -------- | ------------------------------------------------------------------------------------- | -------------------------------------- |
| Observer | Desacoplamiento parcial                                                               | No centraliza la comunicación          |
| Command  | Encapsula operaciones                                                                 | No resuelve comunicación entre objetos |
| Facade   | Simplifica interfaz                                                                   | No maneja interacciones complejas      |
| Mediator | ✅ Centraliza comunicación <br> ✅ Reduce acoplamiento <br> ✅ Facilita escalabilidad | Complejidad inicial                    |

### 3.2 Razones de elección

- **Centralización:** Lógica de comunicación en un solo lugar.
- **Desacoplamiento:** Usuarios solo conocen al mediador.
- **Escalabilidad:** Agregar/eliminar usuarios es trivial.
- **Mantenibilidad:** Cambios en comunicación se hacen en un solo punto.

---

## 4. Implementación de la Solución

### 4.1 Estructura de Clases

```csharp
// Interfaz del Mediador
public interface IChatMediator {
    void SendMessage(string from, string to, string message);
    void AddUser(User user);
}

// Implementación Básica
internal class ChatMediator : IChatMediator {
    private readonly IDictionary<string, User> _users;
    // Lógica de comunicación
}

// Implementación Avanzada con Reflexión
public class ReflectiveChatMediator : IChatMediator {
    private readonly IDictionary<string, User> _users;
    private readonly IDictionary<string, MethodInfo> _messageHandlers;
    private readonly IDictionary<string, object> _participants;
    // Capacidad reflexiva
}
```

### 4.2 Participantes del Patrón

- **Mediator (IChatMediator):** Define la interfaz de comunicación.
- **ConcreteMediator (ChatMediator / ReflectiveChatMediator):** Implementa la lógica.
- **Colleague (User):** Representa los usuarios del chat.
- **ConcreteColleague (User):** Implementación específica de usuario.

---

## 5. Arquitectura del Sistema

### 5.1 Flujo de Comunicación

```
Usuario 1 → Mediador → Usuario 2
Usuario 1 → Mediador → Usuario 3
Usuario 1 → Mediador → Usuario 4
Complejidad: O(n) dependencias
```

### 5.2 Componentes Principales

**ReflectiveChatMediator**

- Reflexión para configuración automática
- Handlers dinámicos ([MediatorHandler])
- Estadísticas automáticas
- Logging de actividades

**User**

```csharp
[MediatorParticipant("ChatUser")]
public class User {
    [MediatorProperty("NickName", true)]
    public string NickName { get; set; }
    [MediatorProperty("IsOnline")]
    public bool IsOnline { get; set; }
    // Métodos de comunicación a través del mediador
}
```

---

## 🖼️ Diagrama de clases

- ✅ [`diagrama-clases`](./../../Diagramas/Clases_Ejercicio_3.svg)

---

## 💻 Código

Índice de las clases principales:

- [Atributos del Mediador](./../../Source/Ejercicio3.Mediator/Attributes/MediatorAttribute.cs)
  - `MediatorHandlerAttribute.cs`
  - `MediatorParticipantAttribute.cs`
  - `MediatorPropertyAttribute.cs`
- [Layout del Chat](./../../Source/Ejercicio3.Mediator/Console/Layout.cs)
- [Interfaces del Mediador](./../../Source/Ejercicio3.Mediator/Mediator/IChatMediator.cs)
- [Implementaciones del Mediador ChatMediator](./../../Source/Ejercicio3.Mediator/Mediator/ChatMediator.cs)
- [Implementaciones del Mediador ReflectiveChatMediator](./../../Source/Ejercicio3.Mediator/Mediator/ReflectiveChatMediator.cs)
- [Modelo User](./../../Source/Ejercicio3.Mediator/Models/User.cs)
- [Programa Principal](./../../Source/Ejercicio3.Mediator/Program.cs)

---

## 6. Beneficios Obtenidos

### 6.1 Beneficios Cumplidos

- ✅ **Facilita mantenimiento:** cambios centralizados.
- ✅ **Mejor organización:** lógica de comunicación centralizada.
- ✅ **Reduce complejidad:** Usuario ↔ Mediador ↔ Usuario.

### 6.2 Comparativa

| Aspecto       | Sin Mediator | Con Mediator |
| ------------- | ------------ | ------------ |
| Acoplamiento  | Alto (O(n²)) | Bajo (O(n))  |
| Mantenimiento | Difícil      | Fácil        |
| Escalabilidad | Limitada     | Excelente    |
| Testabilidad  | Compleja     | Simple       |

---

## 7. Características Avanzadas

- **Reflexión:** Configuración automática de propiedades.
- **Handlers dinámicos:** Procesamiento de mensajes basado en atributos.
- **Estadísticas y monitoreo:** Seguimiento de usuarios y actividades.

```csharp
[MediatorHandler("broadcast")]
private void HandleBroadcastMessage(string from, string to, string message) { ... }
```

---

## 8. Conclusiones

El Patrón Mediator resultó ser la solución óptima porque:

1. Elimina dependencias directas entre usuarios.
2. Centraliza la lógica de comunicación.
3. Facilita escalabilidad y mantenimiento.
4. Permite extensibilidad sin afectar usuarios existentes.

**Innovaciones Implementadas:**

- Mediador reflexivo, handlers dinámicos, estadísticas integradas, gestión avanzada de estado.

**Impacto en la calidad del código:**

- Acoplamiento: reducido
- Cohesión: aumentada
- Mantenibilidad: mejorada
- Escalabilidad: excelente
- Testabilidad: alta
