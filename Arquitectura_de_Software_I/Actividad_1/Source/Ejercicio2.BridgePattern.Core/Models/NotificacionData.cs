using Ejercicio2.BridgePattern.Core.Enums;

namespace Ejercicio2.BridgePattern.Core.Models;

/// <summary>
/// Record que representa los datos de una notificación
/// </summary>
/// <param name="Mensaje">El mensaje de la notificación</param>
/// <param name="Tipo">El tipo de notificación</param>
/// <param name="Timestamp">La fecha y hora de creación</param>
public record NotificacionData(string Mensaje, TipoNotificacion Tipo, DateTime Timestamp)
{
    /// <summary>
    /// Crea una nueva instancia de NotificacionData con timestamp actual
    /// </summary>
    /// <param name="mensaje">El mensaje de la notificación</param>
    /// <param name="tipo">El tipo de notificación</param>
    /// <returns>Una nueva instancia de NotificacionData</returns>
    public static NotificacionData Crear(string mensaje, TipoNotificacion tipo) =>
        new(mensaje, tipo, DateTime.UtcNow);
    
    /// <summary>
    /// Obtiene una representación en string de la notificación
    /// </summary>
    /// <returns>String con los datos de la notificación</returns>
    public override string ToString() =>
        $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Tipo}: {Mensaje}";
}
