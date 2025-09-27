using Ejercicio2.BridgePattern.Core.Interfaces;
using Ejercicio2.BridgePattern.Core.Enums;

namespace Ejercicio2.BridgePattern.Core.Abstractions;

/// <summary>
/// Implementación concreta de notificación para alertas
/// </summary>
public class NotificacionAlerta : Notificacion
{
    private readonly string _mensaje;
    private readonly NivelCriticidad _nivelCriticidad;
    
    /// <summary>
    /// Constructor para crear una notificación de alerta
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje de la alerta</param>
    /// <param name="nivelCriticidad">El nivel de criticidad de la alerta</param>
    /// <exception cref="ArgumentNullException">Se lanza cuando el mensaje es null o vacío</exception>
    public NotificacionAlerta(INotificador notificador, string mensaje, NivelCriticidad nivelCriticidad = NivelCriticidad.Media) 
        : base(notificador)
    {
        if (string.IsNullOrWhiteSpace(mensaje))
            throw new ArgumentException("El mensaje no puede ser null o vacío", nameof(mensaje));
            
        _mensaje = mensaje;
        _nivelCriticidad = nivelCriticidad;
    }
    
    /// <summary>
    /// Muestra la notificación de alerta
    /// </summary>
    public override void Mostrar()
    {
        _notificador.MostrarNotificacion(_mensaje, $"ALERTA ({_nivelCriticidad})");
        
        // Solo reproducir sonido para alertas de nivel medio o superior
        if (_nivelCriticidad >= NivelCriticidad.Media)
        {
            _notificador.SonarAlerta();
        }
    }
    
    /// <summary>
    /// Envía la notificación de alerta
    /// </summary>
    public override void Enviar()
    {
        Console.WriteLine($"Enviando alerta de nivel {_nivelCriticidad}: {_mensaje}");
        Mostrar();
    }
    
    /// <summary>
    /// Obtiene el mensaje de la alerta
    /// </summary>
    public string Mensaje => _mensaje;
    
    /// <summary>
    /// Obtiene el nivel de criticidad de la alerta
    /// </summary>
    public NivelCriticidad NivelCriticidad => _nivelCriticidad;
}
