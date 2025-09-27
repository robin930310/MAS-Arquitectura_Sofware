using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Abstractions;

/// <summary>
/// Implementación concreta de notificación para confirmaciones
/// </summary>
public class NotificacionConfirmacion : Notificacion
{
    private readonly string _mensaje;
    private readonly string _accionConfirmar;
    
    /// <summary>
    /// Constructor para crear una notificación de confirmación
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje de confirmación</param>
    /// <param name="accionConfirmar">La acción que se está confirmando</param>
    /// <exception cref="ArgumentNullException">Se lanza cuando algún parámetro es null o vacío</exception>
    public NotificacionConfirmacion(INotificador notificador, string mensaje, string accionConfirmar) 
        : base(notificador)
    {
        if (string.IsNullOrWhiteSpace(mensaje))
            throw new ArgumentException("El mensaje no puede ser null o vacío", nameof(mensaje));
            
        if (string.IsNullOrWhiteSpace(accionConfirmar))
            throw new ArgumentException("La acción a confirmar no puede ser null o vacía", nameof(accionConfirmar));
            
        _mensaje = mensaje;
        _accionConfirmar = accionConfirmar;
    }
    
    /// <summary>
    /// Muestra la notificación de confirmación
    /// </summary>
    public override void Mostrar()
    {
        _notificador.MostrarNotificacion(_mensaje, "CONFIRMACIÓN");
        Console.WriteLine($"Acción a confirmar: {_accionConfirmar}");
    }
    
    /// <summary>
    /// Envía la notificación de confirmación
    /// </summary>
    public override void Enviar()
    {
        Console.WriteLine($"Solicitando confirmación: {_mensaje}");
        Mostrar();
    }
    
    /// <summary>
    /// Obtiene el mensaje de la confirmación
    /// </summary>
    public string Mensaje => _mensaje;
    
    /// <summary>
    /// Obtiene la acción que se está confirmando
    /// </summary>
    public string AccionConfirmar => _accionConfirmar;
}
