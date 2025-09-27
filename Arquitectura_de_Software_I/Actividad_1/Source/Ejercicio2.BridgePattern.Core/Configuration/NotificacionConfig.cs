namespace Ejercicio2.BridgePattern.Core.Configuration;

/// <summary>
/// Configuración para el sistema de notificaciones
/// </summary>
public class NotificacionConfig
{
    /// <summary>
    /// La plataforma por defecto para mostrar notificaciones
    /// </summary>
    public string Plataforma { get; set; } = "Web";
    
    /// <summary>
    /// Indica si se deben reproducir sonidos de alerta
    /// </summary>
    public bool SonarAlertas { get; set; } = true;
    
    /// <summary>
    /// Indica si se debe vibrar en dispositivos móviles
    /// </summary>
    public bool VibrarEnMovil { get; set; } = true;
    
    /// <summary>
    /// Timeout en segundos para las notificaciones
    /// </summary>
    public int TimeoutSegundos { get; set; } = 30;
    
    /// <summary>
    /// Indica si se debe usar la versión asíncrona para web
    /// </summary>
    public bool UsarAsyncEnWeb { get; set; } = false;
    
    /// <summary>
    /// Nivel mínimo de criticidad para reproducir sonidos
    /// </summary>
    public string NivelMinimoSonido { get; set; } = "Media";
    
    /// <summary>
    /// Indica si se deben mostrar notificaciones de debug
    /// </summary>
    public bool MostrarDebug { get; set; } = false;
}
