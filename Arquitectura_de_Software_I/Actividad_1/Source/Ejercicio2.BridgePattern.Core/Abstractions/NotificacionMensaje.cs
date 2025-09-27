using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Abstractions;

/// <summary>
/// Implementación concreta de notificación para mensajes
/// </summary>
public class NotificacionMensaje : Notificacion
{
    private readonly string _mensaje;
    
    /// <summary>
    /// Constructor para crear una notificación de mensaje
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje a mostrar</param>
    /// <exception cref="ArgumentNullException">Se lanza cuando el mensaje es null o vacío</exception>
    public NotificacionMensaje(INotificador notificador, string mensaje) 
        : base(notificador)
    {
        if (string.IsNullOrWhiteSpace(mensaje))
            throw new ArgumentException("El mensaje no puede ser null o vacío", nameof(mensaje));
            
        _mensaje = mensaje;
    }
    
    /// <summary>
    /// Muestra la notificación de mensaje
    /// </summary>
    public override void Mostrar()
    {
        _notificador.MostrarNotificacion(_mensaje, "MENSAJE");
    }
    
    /// <summary>
    /// Envía la notificación de mensaje
    /// </summary>
    public override void Enviar()
    {
        Console.WriteLine($"Enviando mensaje: {_mensaje}");
        Mostrar();
    }
    
    /// <summary>
    /// Obtiene el mensaje de la notificación
    /// </summary>
    public string Mensaje => _mensaje;
}
