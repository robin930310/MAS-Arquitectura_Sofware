using Ejercicio2.BridgePattern.Core.Configuration;
using Ejercicio2.BridgePattern.Core.Enums;
using Ejercicio2.BridgePattern.Core.Factories;
using Ejercicio2.BridgePattern.Core.Interfaces;
using Ejercicio2.BridgePattern.Core.Implementations;
using Ejercicio2.BridgePattern.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Ejercicio2.BridgePattern.Core.Extensions;

/// <summary>
/// Extensiones para configurar el sistema de notificaciones con Dependency Injection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Agrega el sistema de notificaciones al contenedor de servicios
    /// </summary>
    /// <param name="services">La colección de servicios</param>
    /// <param name="configuration">La configuración de la aplicación</param>
    /// <returns>La colección de servicios para encadenamiento</returns>
    public static IServiceCollection AgregarSistemaNotificaciones(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Registrar la configuración
        services.Configure<NotificacionConfig>(configuration.GetSection("Notificaciones"));
        
        // Registrar el notificador según la configuración
        services.AddScoped<INotificador>(provider =>
        {
            var config = configuration.GetSection("Notificaciones").Get<NotificacionConfig>();
            var plataforma = config?.Plataforma ?? "Web";
            var usarAsync = config?.UsarAsyncEnWeb ?? false;
            
            return NotificadorFactory.Crear(plataforma, usarAsync);
        });
        
        // Registrar los servicios
        services.AddScoped<NotificacionService>();
        services.AddScoped<NotificacionServiceConfigurado>();
        
        return services;
    }
    
    /// <summary>
    /// Agrega el sistema de notificaciones con un notificador específico
    /// </summary>
    /// <param name="services">La colección de servicios</param>
    /// <param name="plataforma">La plataforma a utilizar</param>
    /// <param name="usarAsync">Si se debe usar la versión asíncrona (solo para Web)</param>
    /// <returns>La colección de servicios para encadenamiento</returns>
    public static IServiceCollection AgregarSistemaNotificaciones(
        this IServiceCollection services, 
        Plataforma plataforma, 
        bool usarAsync = false)
    {
        // Registrar el notificador específico
        services.AddScoped<INotificador>(_ => NotificadorFactory.Crear(plataforma, usarAsync));
        
        // Registrar los servicios
        services.AddScoped<NotificacionService>();
        
        return services;
    }
    
    /// <summary>
    /// Agrega el sistema de notificaciones con configuración personalizada
    /// </summary>
    /// <param name="services">La colección de servicios</param>
    /// <param name="configurar">Función para configurar las opciones</param>
    /// <returns>La colección de servicios para encadenamiento</returns>
    public static IServiceCollection AgregarSistemaNotificaciones(
        this IServiceCollection services, 
        Action<NotificacionConfig> configurar)
    {
        // Registrar la configuración personalizada
        services.Configure(configurar);
        
        // Registrar el notificador por defecto
        services.AddScoped<INotificador, NotificadorWeb>();
        
        // Registrar los servicios
        services.AddScoped<NotificacionService>();
        services.AddScoped<NotificacionServiceConfigurado>();
        
        return services;
    }
    
    /// <summary>
    /// Agrega múltiples notificadores para diferentes plataformas
    /// </summary>
    /// <param name="services">La colección de servicios</param>
    /// <returns>La colección de servicios para encadenamiento</returns>
    public static IServiceCollection AgregarNotificadoresMultiplataforma(this IServiceCollection services)
    {
        // Registrar todos los notificadores disponibles
        services.AddScoped<NotificadorWeb>();
        services.AddScoped<NotificadorWebAsync>();
        services.AddScoped<NotificadorMovil>();
        services.AddScoped<NotificadorEscritorio>();
        
        // Registrar factory para crear notificadores dinámicamente
        services.AddScoped<Func<Plataforma, bool, INotificador>>(provider => 
            (plataforma, usarAsync) => NotificadorFactory.Crear(plataforma, usarAsync));
        
        return services;
    }
}
