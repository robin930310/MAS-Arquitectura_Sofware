# Bridge Pattern - Sistema de Notificaciones Multi-Plataforma

## 📋 Descripción

Este proyecto implementa el **Bridge Pattern** aplicado a un sistema de notificaciones que puede funcionar en múltiples plataformas (Web, Móvil, Escritorio). El patrón Bridge separa la abstracción (tipos de notificaciones) de su implementación (plataformas), permitiendo que ambas evolucionen independientemente.

## 🏗️ Arquitectura del Proyecto

```
BridgePattern/
├── src/
│   ├── BridgePattern.Core/           # Biblioteca principal
│   │   ├── Abstractions/            # Clases abstractas (tipos de notificación)
│   │   ├── Enums/                   # Enumeraciones
│   │   ├── Factories/               # Patrón Factory
│   │   ├── Implementations/         # Implementaciones concretas (plataformas)
│   │   ├── Interfaces/              # Contratos
│   │   ├── Models/                  # Modelos de datos
│   │   ├── Services/                # Servicios de negocio
│   │   ├── Configuration/           # Configuración
│   │   └── Extensions/              # Extensiones de DI
│   └── BridgePattern.Demo/          # Aplicación de demostración
└── README.md
```

## 🎯 Problema Resuelto

Sin el Bridge Pattern, tendríamos que crear clases como:
- `NotificacionMensajeWeb`
- `NotificacionAlertaWeb`
- `NotificacionMensajeMovil`
- `NotificacionAlertaMovil`
- Y muchas más combinaciones...

Esto lleva a una **explosión combinatoria** de subclases difíciles de mantener.

## ✅ Solución con Bridge Pattern

El Bridge Pattern separa:
- **Abstracción**: Tipos de notificación (`NotificacionMensaje`, `NotificacionAlerta`, etc.)
- **Implementación**: Plataformas (`NotificadorWeb`, `NotificadorMovil`, `NotificadorEscritorio`)

## 🚀 Características

### ✨ Tipos de Notificación
- **Mensaje**: Notificaciones informativas
- **Alerta**: Notificaciones urgentes con niveles de criticidad
- **Advertencia**: Notificaciones de precaución con consejos
- **Confirmación**: Notificaciones que requieren confirmación del usuario

### 🌐 Plataformas Soportadas
- **Web**: Notificaciones del navegador con Web APIs
- **Móvil**: Notificaciones push con vibración y sonido
- **Escritorio**: Notificaciones del sistema con SystemSounds

### 🔧 Características Técnicas
- **Async/Await**: Soporte completo para operaciones asíncronas
- **Factory Pattern**: Creación dinámica de notificaciones y notificadores
- **Dependency Injection**: Integración completa con .NET DI Container
- **Configuration**: Configuración flexible via `appsettings.json`
- **Enums**: Tipos fuertemente tipados para mejor mantenibilidad
- **Records**: Datos inmutables para notificaciones

## 📦 Instalación y Uso

### Prerrequisitos
- .NET 8.0 SDK
- Visual Studio 2022 o VS Code

### Compilación
```bash
# Restaurar dependencias
dotnet restore

# Compilar solución
dotnet build

# Ejecutar demostración
dotnet run --project src/BridgePattern.Demo
```

### Uso Básico

```csharp
// Crear un notificador
var notificador = new NotificadorWeb();

// Crear una notificación
var notificacion = new NotificacionMensaje(notificador, "Hola mundo!");

// Enviar la notificación
notificacion.Enviar();
```

### Uso con Factory

```csharp
// Crear notificador usando factory
var notificador = NotificadorFactory.Crear(Plataforma.Web);

// Crear notificación usando factory
var notificacion = NotificacionFactory.Crear(
    TipoNotificacion.Alerta, 
    notificador, 
    "Sistema en mantenimiento", 
    NivelCriticidad.Alta
);

notificacion.Enviar();
```

### Uso con Dependency Injection

```csharp
// En Program.cs
var builder = WebApplication.CreateBuilder(args);

// Configurar sistema de notificaciones
builder.Services.AgregarSistemaNotificaciones(builder.Configuration);

var app = builder.Build();

// En un servicio
public class MiServicio
{
    private readonly NotificacionService _notificacionService;
    
    public MiServicio(NotificacionService notificacionService)
    {
        _notificacionService = notificacionService;
    }
    
    public void ProcesarAlgo()
    {
        _notificacionService.EnviarAlerta("Algo importante pasó!", NivelCriticidad.Alta);
    }
}
```

## ⚙️ Configuración

### appsettings.json
```json
{
  "Notificaciones": {
    "Plataforma": "Web",
    "Configuracion": {
      "SonarAlertas": true,
      "VibrarEnMovil": true,
      "TimeoutSegundos": 30,
      "UsarAsyncEnWeb": false,
      "NivelMinimoSonido": "Media",
      "MostrarDebug": true
    }
  }
}
```

## 🧪 Demostraciones Incluidas

El proyecto incluye 5 demostraciones completas:

1. **Bridge Pattern Básico**: Demuestra la separación entre abstracción e implementación
2. **Notificaciones Asíncronas**: Muestra el soporte para operaciones async/await
3. **Factory Pattern**: Demuestra la creación dinámica de objetos
4. **Flexibilidad**: Muestra cómo cambiar plataformas dinámicamente
5. **Configuración y DI**: Demuestra la integración con .NET DI Container

## 🔄 Extensibilidad

### Agregar Nueva Plataforma
1. Crear nueva implementación de `INotificador`
2. Agregar enum a `Plataforma`
3. Actualizar `NotificadorFactory`
4. ¡Listo! Todas las notificaciones funcionarán automáticamente

### Agregar Nuevo Tipo de Notificación
1. Crear nueva clase que herede de `Notificacion`
2. Agregar enum a `TipoNotificacion`
3. Actualizar `NotificacionFactory`
4. ¡Listo! Funcionará en todas las plataformas

## 📊 Beneficios del Diseño

- **Escalabilidad**: Fácil agregar nuevas plataformas o tipos
- **Mantenibilidad**: Separación clara de responsabilidades
- **Flexibilidad**: Cambio dinámico de plataformas
- **Testabilidad**: Fácil crear mocks y tests unitarios
- **Principio Abierto/Cerrado**: Abierto para extensión, cerrado para modificación

## 🧪 Testing

```bash
# Ejecutar tests (cuando estén implementados)
dotnet test
```

## 📚 Patrones de Diseño Utilizados

- **Bridge Pattern**: Separación de abstracción e implementación
- **Factory Pattern**: Creación de objetos
- **Dependency Injection**: Inversión de control
- **Strategy Pattern**: Diferentes algoritmos por plataforma

## 🤝 Contribuciones

Las contribuciones son bienvenidas! Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 👥 Autores

- **Desarrollador Principal** - Implementación del Bridge Pattern

## 🙏 Agradecimientos

- Patrones de diseño de la Gang of Four
- .NET Community por las mejores prácticas
- Refactoring.Guru por las excelentes explicaciones de patrones
