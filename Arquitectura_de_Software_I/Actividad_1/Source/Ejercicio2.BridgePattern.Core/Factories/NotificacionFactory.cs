using Ejercicio2.BridgePattern.Core.Abstractions;
using Ejercicio2.BridgePattern.Core.Enums;
using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Factories;

/// <summary>
/// Factory para crear notificaciones usando el patrón Factory
/// </summary>
public static class NotificacionFactory
{
    /// <summary>
    /// Crea una notificación del tipo especificado
    /// </summary>
    /// <param name="tipo">El tipo de notificación a crear</param>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje de la notificación</param>
    /// <param name="parametroExtra">Parámetro extra opcional (ej: acción para confirmación, nivel para alerta)</param>
    /// <returns>Una instancia de la notificación creada</returns>
    /// <exception cref="ArgumentException">Se lanza cuando el tipo de notificación no es soportado</exception>
    public static Notificacion Crear(TipoNotificacion tipo, INotificador notificador, string mensaje, object? parametroExtra = null)
    {
        return tipo switch
        {
            TipoNotificacion.Mensaje => new NotificacionMensaje(notificador, mensaje),
            TipoNotificacion.Alerta => CrearAlerta(notificador, mensaje, parametroExtra),
            TipoNotificacion.Advertencia => CrearAdvertencia(notificador, mensaje, parametroExtra),
            TipoNotificacion.Confirmacion => CrearConfirmacion(notificador, mensaje, parametroExtra),
            _ => throw new ArgumentException($"Tipo de notificación no soportado: {tipo}")
        };
    }
    
    /// <summary>
    /// Crea una notificación de alerta
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje de la alerta</param>
    /// <param name="parametroExtra">El nivel de criticidad (NivelCriticidad) o null para usar el valor por defecto</param>
    /// <returns>Una instancia de NotificacionAlerta</returns>
    private static NotificacionAlerta CrearAlerta(INotificador notificador, string mensaje, object? parametroExtra)
    {
        var nivel = parametroExtra switch
        {
            NivelCriticidad nivelCriticidad => nivelCriticidad,
            null => NivelCriticidad.Media,
            _ => throw new ArgumentException($"Parámetro extra inválido para alerta. Esperado: NivelCriticidad, Obtenido: {parametroExtra?.GetType().Name}")
        };
        
        return new NotificacionAlerta(notificador, mensaje, nivel);
    }
    
    /// <summary>
    /// Crea una notificación de advertencia
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje de la advertencia</param>
    /// <param name="parametroExtra">El consejo (string) o null</param>
    /// <returns>Una instancia de NotificacionAdvertencia</returns>
    private static NotificacionAdvertencia CrearAdvertencia(INotificador notificador, string mensaje, object? parametroExtra)
    {
        var consejo = parametroExtra switch
        {
            string consejoStr => consejoStr,
            null => null,
            _ => throw new ArgumentException($"Parámetro extra inválido para advertencia. Esperado: string, Obtenido: {parametroExtra?.GetType().Name}")
        };
        
        return new NotificacionAdvertencia(notificador, mensaje, consejo);
    }
    
    /// <summary>
    /// Crea una notificación de confirmación
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="mensaje">El mensaje de confirmación</param>
    /// <param name="parametroExtra">La acción a confirmar (string)</param>
    /// <returns>Una instancia de NotificacionConfirmacion</returns>
    /// <exception cref="ArgumentException">Se lanza cuando no se proporciona la acción a confirmar</exception>
    private static NotificacionConfirmacion CrearConfirmacion(INotificador notificador, string mensaje, object? parametroExtra)
    {
        var accion = parametroExtra switch
        {
            string accionStr => accionStr,
            null => throw new ArgumentException("Se requiere especificar la acción a confirmar"),
            _ => throw new ArgumentException($"Parámetro extra inválido para confirmación. Esperado: string, Obtenido: {parametroExtra?.GetType().Name}")
        };
        
        return new NotificacionConfirmacion(notificador, mensaje, accion);
    }
}
