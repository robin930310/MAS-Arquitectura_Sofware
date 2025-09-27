namespace Ejercicio2.BridgePattern.Core.Interfaces;

/// <summary>
/// Interfaz que define el contrato para mostrar notificaciones en diferentes plataformas
/// </summary>
public interface INotificador
{
    /// <summary>
    /// Muestra una notificación en la plataforma específica
    /// </summary>
    /// <param name="mensaje">El mensaje a mostrar</param>
    /// <param name="tipo">El tipo de notificación</param>
    void MostrarNotificacion(string mensaje, string tipo);
    
    /// <summary>
    /// Reproduce un sonido de alerta
    /// </summary>
    void SonarAlerta();
    
    /// <summary>
    /// Hace vibrar el dispositivo (si es soportado)
    /// </summary>
    void Vibrar();
    
    /// <summary>
    /// Obtiene el nombre de la plataforma
    /// </summary>
    string NombrePlataforma { get; }
}
