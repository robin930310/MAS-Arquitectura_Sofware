using Ejercicio2.BridgePattern.Core.Enums;
using Ejercicio2.BridgePattern.Core.Extensions;
using Ejercicio2.BridgePattern.Core.Interfaces;
using Ejercicio2.BridgePattern.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ejercicio2.BridgePattern.Demo;

/// <summary>
/// Demostración del sistema de notificaciones con configuración y Dependency Injection
/// </summary>
public class DemoConConfiguracion
{
    /// <summary>
    /// Ejecuta la demostración con configuración
    /// </summary>
    public static async Task EjecutarAsync()
    {
        Console.WriteLine("⚙️ DEMOSTRACIÓN 5: Sistema con Configuración y DI");
        Console.WriteLine("==================================================\n");
        
        Console.WriteLine("🔧 Configurando sistema con Dependency Injection...");
        
        // Crear el host builder
        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                // Agregar configuración desde archivo JSON
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                
                // Agregar configuración por defecto si el archivo no existe
                config.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["Notificaciones:Plataforma"] = "Web",
                    ["Notificaciones:Configuracion:SonarAlertas"] = "true",
                    ["Notificaciones:Configuracion:VibrarEnMovil"] = "true",
                    ["Notificaciones:Configuracion:TimeoutSegundos"] = "30",
                    ["Notificaciones:Configuracion:UsarAsyncEnWeb"] = "false",
                    ["Notificaciones:Configuracion:NivelMinimoSonido"] = "Media",
                    ["Notificaciones:Configuracion:MostrarDebug"] = "true"
                });
            })
            .ConfigureServices((context, services) =>
            {
                // Configurar el sistema de notificaciones
                services.AgregarSistemaNotificaciones(context.Configuration);
                
                // Agregar notificadores múltiples para demostración
                services.AgregarNotificadoresMultiplataforma();
            })
            .Build();
        
        try
        {
            Console.WriteLine("✅ Sistema configurado exitosamente\n");
            
            // Ejecutar diferentes demostraciones
            await DemostrarConServicioBasico(host.Services);
            await DemostrarConServicioConfigurado(host.Services);
            await DemostrarMultiplataforma(host.Services);
            
            Console.WriteLine("\n✅ Demostración con configuración completada exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error en demostración con configuración: {ex.Message}");
        }
        finally
        {
            await host.StopAsync();
        }
    }
    
    /// <summary>
    /// Demuestra el uso del servicio básico
    /// </summary>
    private static async Task DemostrarConServicioBasico(IServiceProvider services)
    {
        Console.WriteLine("📋 --- Servicio Básico ---");
        
        using var scope = services.CreateScope();
        var servicio = scope.ServiceProvider.GetRequiredService<NotificacionService>();
        
        Console.WriteLine($"Plataforma actual: {servicio.PlataformaActual}");
        
        servicio.EnviarMensaje("Mensaje desde servicio básico");
        servicio.EnviarAlerta("Alerta desde servicio básico", NivelCriticidad.Alta);
        servicio.EnviarAdvertencia("Advertencia desde servicio básico", "Revisar logs");
        servicio.EnviarConfirmacion("¿Continuar?", "Procesar datos");
        
        await Task.Delay(1000);
    }
    
    /// <summary>
    /// Demuestra el uso del servicio configurado
    /// </summary>
    private static async Task DemostrarConServicioConfigurado(IServiceProvider services)
    {
        Console.WriteLine("\n⚙️ --- Servicio Configurado ---");
        
        using var scope = services.CreateScope();
        var servicio = scope.ServiceProvider.GetRequiredService<NotificacionServiceConfigurado>();
        
        Console.WriteLine($"Plataforma actual: {servicio.PlataformaActual}");
        Console.WriteLine($"Configuración actual: SonarAlertas={servicio.Configuracion.SonarAlertas}, VibrarEnMovil={servicio.Configuracion.VibrarEnMovil}");
        
        await servicio.EnviarMensajeAsync("Mensaje asíncrono desde servicio configurado");
        await servicio.EnviarAlertaAsync("Alerta asíncrona desde servicio configurado", NivelCriticidad.Critica);
        await servicio.EnviarAdvertenciaAsync("Advertencia asíncrona desde servicio configurado", "Verificar configuración");
        await servicio.EnviarConfirmacionAsync("¿Continuar con proceso asíncrono?", "Procesar archivos");
        
        await Task.Delay(1000);
    }
    
    /// <summary>
    /// Demuestra el uso de múltiples plataformas
    /// </summary>
    private static async Task DemostrarMultiplataforma(IServiceProvider services)
    {
        Console.WriteLine("\n🔄 --- Múltiples Plataformas ---");
        
        using var scope = services.CreateScope();
        var factory = scope.ServiceProvider.GetRequiredService<Func<Plataforma, bool, INotificador>>();
        
        var plataformas = new[] { Plataforma.Web, Plataforma.Movil, Plataforma.Escritorio };
        
        foreach (var plataforma in plataformas)
        {
            Console.WriteLine($"\n--- Demostrando {plataforma} ---");
            
            var notificador = factory(plataforma, false);
            var servicio = new NotificacionService(notificador);
            
            Console.WriteLine($"Plataforma: {servicio.PlataformaActual}");
            servicio.EnviarMensaje($"Mensaje en {plataforma}");
            servicio.EnviarAlerta($"Alerta en {plataforma}", NivelCriticidad.Media);
            
            await Task.Delay(500);
        }
    }
}
