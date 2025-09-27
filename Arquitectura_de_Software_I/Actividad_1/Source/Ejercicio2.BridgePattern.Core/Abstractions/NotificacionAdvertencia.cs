using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Abstractions;

/// <summary>
/// Implementación concreta de notificación para advertencias
/// </summary>
public class NotificacionAdvertencia : Notificacion
{
    private readonly string _mensaje;
    private readonly string? _consejo;
    
    /// <summary>
    /// Constructor para crear una notificación de advertencia
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje de advertencia</param>
    /// <param name="consejo">Consejo opcional relacionado con la advertencia</param>
    /// <exception cref="ArgumentNullException">Se lanza cuando el mensaje es null o vacío</exception>
    public NotificacionAdvertencia(INotificador notificador, string mensaje, string? consejo = null) 
        : base(notificador)
    {
        if (string.IsNullOrWhiteSpace(mensaje))
            throw new ArgumentException("El mensaje no puede ser null o vacío", nameof(mensaje));
            
        _mensaje = mensaje;
        _consejo = consejo;
    }
    
    /// <summary>
    /// Muestra la notificación de advertencia
    /// </summary>
    public override void Mostrar()
    {
        _notificador.MostrarNotificacion(_mensaje, "ADVERTENCIA");
        
        if (!string.IsNullOrWhiteSpace(_consejo))
        {
            Console.WriteLine($"Consejo: {_consejo}");
        }
    }
    
    /// <summary>
    /// Envía la notificación de advertencia
    /// </summary>
    public override void Enviar()
    {
        Console.WriteLine($"Enviando advertencia: {_mensaje}");
        Mostrar();
    }
    
    /// <summary>
    /// Obtiene el mensaje de la advertencia
    /// </summary>
    public string Mensaje => _mensaje;
    
    /// <summary>
    /// Obtiene el consejo de la advertencia
    /// </summary>
    public string? Consejo => _consejo;
}
