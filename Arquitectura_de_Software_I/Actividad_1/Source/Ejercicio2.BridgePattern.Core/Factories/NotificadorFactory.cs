using Ejercicio2.BridgePattern.Core.Enums;
using Ejercicio2.BridgePattern.Core.Interfaces;
using Ejercicio2.BridgePattern.Core.Implementations;

namespace Ejercicio2.BridgePattern.Core.Factories;

/// <summary>
/// Factory para crear notificadores según la plataforma
/// </summary>
public static class NotificadorFactory
{
    /// <summary>
    /// Crea un notificador para la plataforma especificada
    /// </summary>
    /// <param name="plataforma">La plataforma para la cual crear el notificador</param>
    /// <param name="usarAsync">Si se debe usar la versión asíncrona (solo para Web)</param>
    /// <returns>Una instancia del notificador para la plataforma especificada</returns>
    /// <exception cref="ArgumentException">Se lanza cuando la plataforma no es soportada</exception>
    public static INotificador Crear(Plataforma plataforma, bool usarAsync = false)
    {
        return plataforma switch
        {
            Plataforma.Web => usarAsync ? new NotificadorWebAsync() : new NotificadorWeb(),
            Plataforma.Movil => new NotificadorMovil(),
            Plataforma.Escritorio => new NotificadorEscritorio(),
            _ => throw new ArgumentException($"Plataforma no soportada: {plataforma}")
        };
    }
    
    /// <summary>
    /// Crea un notificador desde un string (útil para configuración)
    /// </summary>
    /// <param name="plataformaStr">El string que representa la plataforma</param>
    /// <param name="usarAsync">Si se debe usar la versión asíncrona (solo para Web)</param>
    /// <returns>Una instancia del notificador para la plataforma especificada</returns>
    /// <exception cref="ArgumentException">Se lanza cuando el string no representa una plataforma válida</exception>
    public static INotificador Crear(string plataformaStr, bool usarAsync = false)
    {
        if (!Enum.TryParse<Plataforma>(plataformaStr, ignoreCase: true, out var plataforma))
        {
            throw new ArgumentException($"Plataforma no válida: {plataformaStr}");
        }
        
        return Crear(plataforma, usarAsync);
    }
    
    /// <summary>
    /// Obtiene todas las plataformas disponibles
    /// </summary>
    /// <returns>Un array con todas las plataformas disponibles</returns>
    public static Plataforma[] ObtenerPlataformasDisponibles()
    {
        return Enum.GetValues<Plataforma>();
    }
    
    /// <summary>
    /// Obtiene los nombres de todas las plataformas disponibles
    /// </summary>
    /// <returns>Un array con los nombres de todas las plataformas disponibles</returns>
    public static string[] ObtenerNombresPlataformasDisponibles()
    {
        return Enum.GetNames<Plataforma>();
    }
}
