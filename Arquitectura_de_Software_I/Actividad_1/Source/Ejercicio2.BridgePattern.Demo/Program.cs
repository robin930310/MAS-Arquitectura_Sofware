using Ejercicio2.BridgePattern.Core.Abstractions;
using Ejercicio2.BridgePattern.Core.Enums;
using Ejercicio2.BridgePattern.Core.Factories;
using Ejercicio2.BridgePattern.Core.Interfaces;
using Ejercicio2.BridgePattern.Core.Implementations;

namespace Ejercicio2.BridgePattern.Demo;

/// <summary>
/// Programa de demostración del Bridge Pattern aplicado a un sistema de notificaciones
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("🚀 ================================================");
        Console.WriteLine("🚀    DEMOSTRACIÓN DEL BRIDGE PATTERN");
        Console.WriteLine("🚀    Sistema de Notificaciones Multi-Plataforma");
        Console.WriteLine("🚀 ================================================\n");
        
        try
        {
            await EjecutarDemostracionCompleta();
            await EjecutarDemostracionAsincrona();
            EjecutarDemostracionFactory();
            EjecutarDemostracionFlexibilidad();
            await DemoConConfiguracion.EjecutarAsync();
            
            Console.WriteLine("\n✅ ================================================");
            Console.WriteLine("✅    DEMOSTRACIÓN COMPLETADA EXITOSAMENTE");
            Console.WriteLine("✅ ================================================");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error durante la demostración: {ex.Message}");
        }
        
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
    
    /// <summary>
    /// Ejecuta la demostración completa del Bridge Pattern
    /// </summary>
    static async Task EjecutarDemostracionCompleta()
    {
        Console.WriteLine("📋 DEMOSTRACIÓN 1: Bridge Pattern Básico");
        Console.WriteLine("==========================================\n");
        
        // Crear notificadores para diferentes plataformas
        var notificadorWeb = new NotificadorWeb();
        var notificadorMovil = new NotificadorMovil();
        var notificadorEscritorio = new NotificadorEscritorio();
        
        // Demostrar diferentes tipos de notificaciones en Web
        Console.WriteLine("🌐 --- Notificaciones Web ---");
        await DemostrarNotificacionesEnPlataforma(notificadorWeb, "Web");
        
        Console.WriteLine("\n📱 --- Notificaciones Móvil ---");
        await DemostrarNotificacionesEnPlataforma(notificadorMovil, "Móvil");
        
        Console.WriteLine("\n🖥️ --- Notificaciones Escritorio ---");
        await DemostrarNotificacionesEnPlataforma(notificadorEscritorio, "Escritorio");
    }
    
    /// <summary>
    /// Demuestra diferentes tipos de notificaciones en una plataforma específica
    /// </summary>
    static async Task DemostrarNotificacionesEnPlataforma(INotificador notificador, string nombrePlataforma)
    {
        // Mensaje
        var mensaje = new NotificacionMensaje(notificador, $"Nuevo mensaje recibido en {nombrePlataforma}");
        mensaje.Enviar();
        
        await Task.Delay(500);
        
        // Alerta
        var alerta = new NotificacionAlerta(notificador, $"Sistema en mantenimiento - {nombrePlataforma}", NivelCriticidad.Alta);
        alerta.Enviar();
        
        await Task.Delay(500);
        
        // Advertencia
        var advertencia = new NotificacionAdvertencia(notificador, 
            $"Espacio en disco bajo en {nombrePlataforma}", 
            "Libere espacio eliminando archivos temporales");
        advertencia.Enviar();
        
        await Task.Delay(500);
        
        // Confirmación
        var confirmacion = new NotificacionConfirmacion(notificador, 
            $"¿Desea cerrar la aplicación en {nombrePlataforma}?", 
            "Cerrar aplicación");
        confirmacion.Enviar();
        
        await Task.Delay(1000);
    }
    
    /// <summary>
    /// Ejecuta la demostración de notificaciones asíncronas
    /// </summary>
    static async Task EjecutarDemostracionAsincrona()
    {
        Console.WriteLine("\n⚡ DEMOSTRACIÓN 2: Notificaciones Asíncronas");
        Console.WriteLine("============================================\n");
        
        var notificadorAsync = new NotificadorWebAsync();
        
        Console.WriteLine("🌐 Procesando notificaciones de forma asíncrona...");
        
        // Crear múltiples notificaciones asíncronas
        var tareas = new List<Task>
        {
            notificadorAsync.MostrarNotificacionAsync("Mensaje 1", "MENSAJE"),
            notificadorAsync.MostrarNotificacionAsync("Alerta 1", "ALERTA"),
            notificadorAsync.SonarAlertaAsync(),
            notificadorAsync.MostrarNotificacionAsync("Mensaje 2", "MENSAJE"),
            notificadorAsync.VibrarAsync()
        };
        
        await Task.WhenAll(tareas);
        
        Console.WriteLine("\n✅ Todas las notificaciones asíncronas completadas");
    }
    
    /// <summary>
    /// Ejecuta la demostración del Factory Pattern
    /// </summary>
    static void EjecutarDemostracionFactory()
    {
        Console.WriteLine("\n🏭 DEMOSTRACIÓN 3: Factory Pattern");
        Console.WriteLine("==================================\n");
        
        var notificador = NotificadorFactory.Crear(Plataforma.Web);
        
        Console.WriteLine("Usando Factory para crear notificaciones:");
        
        // Crear diferentes tipos usando el factory
        var notificaciones = new[]
        {
            NotificacionFactory.Crear(TipoNotificacion.Mensaje, notificador, "Mensaje desde factory"),
            NotificacionFactory.Crear(TipoNotificacion.Alerta, notificador, "Alerta desde factory", NivelCriticidad.Critica),
            NotificacionFactory.Crear(TipoNotificacion.Advertencia, notificador, "Advertencia desde factory", "Revisar configuración"),
            NotificacionFactory.Crear(TipoNotificacion.Confirmacion, notificador, "¿Continuar?", "Procesar datos")
        };
        
        foreach (var notificacion in notificaciones)
        {
            notificacion.Enviar();
            Thread.Sleep(300);
        }
        
        Console.WriteLine("\n📋 Plataformas disponibles:");
        foreach (var plataforma in NotificadorFactory.ObtenerNombresPlataformasDisponibles())
        {
            Console.WriteLine($"  - {plataforma}");
        }
    }
    
    /// <summary>
    /// Ejecuta la demostración de flexibilidad del Bridge Pattern
    /// </summary>
    static void EjecutarDemostracionFlexibilidad()
    {
        Console.WriteLine("\n🔄 DEMOSTRACIÓN 4: Flexibilidad del Bridge Pattern");
        Console.WriteLine("=================================================\n");
        
        // Crear una notificación
        var notificadorWeb = new NotificadorWeb();
        var notificacion = new NotificacionMensaje(notificadorWeb, "Mensaje flexible");
        
        Console.WriteLine($"Notificación creada para plataforma: {notificacion.PlataformaActual}");
        notificacion.Enviar();
        
        // Cambiar dinámicamente a móvil (simulando cambio de contexto)
        Console.WriteLine("\n🔄 Cambiando contexto a móvil...");
        var notificadorMovil = new NotificadorMovil();
        var notificacionMovil = new NotificacionMensaje(notificadorMovil, "Mensaje flexible");
        
        Console.WriteLine($"Notificación ahora en plataforma: {notificacionMovil.PlataformaActual}");
        notificacionMovil.Enviar();
        
        // Demostrar escalabilidad: agregar nueva plataforma fácilmente
        Console.WriteLine("\n➕ Demostrando escalabilidad:");
        Console.WriteLine("Para agregar una nueva plataforma, solo necesitamos:");
        Console.WriteLine("1. Crear una nueva implementación de INotificador");
        Console.WriteLine("2. Agregar el enum Plataforma");
        Console.WriteLine("3. Actualizar NotificadorFactory");
        Console.WriteLine("4. ¡Listo! Todas las notificaciones funcionarán automáticamente");
    }
}
