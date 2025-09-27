using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Abstractions;

/// <summary>
/// Clase abstracta base que define la estructura común para todas las notificaciones
/// </summary>
public abstract class Notificacion
{
    protected readonly INotificador _notificador;
    
    /// <summary>
    /// Constructor base para las notificaciones
    /// </summary>
    /// <param name="notificador">El notificador que se utilizará para mostrar la notificación</param>
    /// <exception cref="ArgumentNullException">Se lanza cuando el notificador es null</exception>
    protected Notificacion(INotificador notificador)
    {
        _notificador = notificador ?? throw new ArgumentNullException(nameof(notificador));
    }
    
    /// <summary>
    /// Método abstracto para mostrar la notificación
    /// </summary>
    public abstract void Mostrar();
    
    /// <summary>
    /// Método abstracto para enviar la notificación
    /// </summary>
    public abstract void Enviar();
    
    /// <summary>
    /// Obtiene información sobre la plataforma actual
    /// </summary>
    public string PlataformaActual => _notificador.NombrePlataforma;
}
