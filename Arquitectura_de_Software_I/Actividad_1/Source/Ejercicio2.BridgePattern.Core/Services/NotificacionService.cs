using Ejercicio2.BridgePattern.Core.Abstractions;
using Ejercicio2.BridgePattern.Core.Enums;
using Ejercicio2.BridgePattern.Core.Factories;
using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Services;

/// <summary>
/// Servicio de notificaciones que encapsula la lógica de negocio
/// </summary>
public class NotificacionService
{
    private readonly INotificador _notificador;
    
    /// <summary>
    /// Constructor del servicio de notificaciones
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    public NotificacionService(INotificador notificador)
    {
        _notificador = notificador ?? throw new ArgumentNullException(nameof(notificador));
    }
    
    /// <summary>
    /// Envía un mensaje
    /// </summary>
    /// <param name="contenido">El contenido del mensaje</param>
    public void EnviarMensaje(string contenido)
    {
        var notificacion = new NotificacionMensaje(_notificador, contenido);
        notificacion.Enviar();
    }
    
    /// <summary>
    /// Envía una alerta
    /// </summary>
    /// <param name="mensaje">El mensaje de la alerta</param>
    /// <param name="nivel">El nivel de criticidad de la alerta</param>
    public void EnviarAlerta(string mensaje, NivelCriticidad nivel = NivelCriticidad.Media)
    {
        var notificacion = new NotificacionAlerta(_notificador, mensaje, nivel);
        notificacion.Enviar();
    }
    
    /// <summary>
    /// Envía una advertencia
    /// </summary>
    /// <param name="mensaje">El mensaje de la advertencia</param>
    /// <param name="consejo">Consejo opcional relacionado con la advertencia</param>
    public void EnviarAdvertencia(string mensaje, string? consejo = null)
    {
        var notificacion = new NotificacionAdvertencia(_notificador, mensaje, consejo);
        notificacion.Enviar();
    }
    
    /// <summary>
    /// Envía una confirmación
    /// </summary>
    /// <param name="mensaje">El mensaje de confirmación</param>
    /// <param name="accion">La acción que se está confirmando</param>
    public void EnviarConfirmacion(string mensaje, string accion)
    {
        var notificacion = new NotificacionConfirmacion(_notificador, mensaje, accion);
        notificacion.Enviar();
    }
    
    /// <summary>
    /// Envía una notificación usando el factory
    /// </summary>
    /// <param name="tipo">El tipo de notificación</param>
    /// <param name="mensaje">El mensaje de la notificación</param>
    /// <param name="parametroExtra">Parámetro extra opcional</param>
    public void EnviarNotificacion(TipoNotificacion tipo, string mensaje, object? parametroExtra = null)
    {
        var notificacion = NotificacionFactory.Crear(tipo, _notificador, mensaje, parametroExtra);
        notificacion.Enviar();
    }
    
    /// <summary>
    /// Obtiene información sobre la plataforma actual
    /// </summary>
    public string PlataformaActual => _notificador.NombrePlataforma;
}
