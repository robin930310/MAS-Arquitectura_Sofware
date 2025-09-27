namespace Ejercicio2.BridgePattern.Core.Interfaces;

/// <summary>
/// Interfaz asíncrona que define el contrato para mostrar notificaciones en diferentes plataformas
/// </summary>
public interface INotificadorAsync
{
    /// <summary>
    /// Muestra una notificación en la plataforma específica de forma asíncrona
    /// </summary>
    /// <param name="mensaje">El mensaje a mostrar</param>
    /// <param name="tipo">El tipo de notificación</param>
    /// <returns>Una tarea que representa la operación asíncrona</returns>
    Task MostrarNotificacionAsync(string mensaje, string tipo);
    
    /// <summary>
    /// Reproduce un sonido de alerta de forma asíncrona
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona</returns>
    Task SonarAlertaAsync();
    
    /// <summary>
    /// Hace vibrar el dispositivo de forma asíncrona (si es soportado)
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona</returns>
    Task VibrarAsync();
    
    /// <summary>
    /// Obtiene el nombre de la plataforma
    /// </summary>
    string NombrePlataforma { get; }
}
