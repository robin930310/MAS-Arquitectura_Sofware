using Ejercicio2.BridgePattern.Core.Abstractions;
using Ejercicio2.BridgePattern.Core.Configuration;
using Ejercicio2.BridgePattern.Core.Enums;
using Ejercicio2.BridgePattern.Core.Factories;
using Ejercicio2.BridgePattern.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace Ejercicio2.BridgePattern.Core.Services;

/// <summary>
/// Servicio de notificaciones con configuración avanzada
/// </summary>
public class NotificacionServiceConfigurado
{
    private readonly INotificador _notificador;
    private readonly NotificacionConfig _config;
    
    /// <summary>
    /// Constructor del servicio de notificaciones configurado
    /// </summary>
    /// <param name="notificador">El notificador a utilizar</param>
    /// <param name="config">La configuración del servicio</param>
    public NotificacionServiceConfigurado(INotificador notificador, IOptions<NotificacionConfig> config)
    {
        _notificador = notificador ?? throw new ArgumentNullException(nameof(notificador));
        _config = config.Value ?? throw new ArgumentNullException(nameof(config));
        
        if (_config.MostrarDebug)
        {
            Console.WriteLine($"[DEBUG] NotificacionServiceConfigurado inicializado para plataforma: {_notificador.NombrePlataforma}");
        }
    }
    
    /// <summary>
    /// Envía un mensaje con configuración aplicada
    /// </summary>
    /// <param name="contenido">El contenido del mensaje</param>
    public async Task EnviarMensajeAsync(string contenido)
    {
        if (_config.MostrarDebug)
        {
            Console.WriteLine($"[DEBUG] Enviando mensaje: {contenido}");
        }
        
        var notificacion = new NotificacionMensaje(_notificador, contenido);
        notificacion.Enviar();
        
        await Task.Delay(100); // Simular procesamiento asíncrono
    }
    
    /// <summary>
    /// Envía una alerta con configuración aplicada
    /// </summary>
    /// <param name="mensaje">El mensaje de la alerta</param>
    /// <param name="nivel">El nivel de criticidad de la alerta</param>
    public async Task EnviarAlertaAsync(string mensaje, NivelCriticidad nivel = NivelCriticidad.Media)
    {
        if (_config.MostrarDebug)
        {
            Console.WriteLine($"[DEBUG] Enviando alerta de nivel {nivel}: {mensaje}");
        }
        
        var notificacion = new NotificacionAlerta(_notificador, mensaje, nivel);
        notificacion.Enviar();
        
        // Aplicar configuración de sonido
        if (_config.SonarAlertas && DebeReproducirSonido(nivel))
        {
            _notificador.SonarAlerta();
        }
        
        // Aplicar configuración de vibración
        if (_config.VibrarEnMovil && _notificador.NombrePlataforma == "Móvil")
        {
            _notificador.Vibrar();
        }
        
        await Task.Delay(200); // Simular procesamiento asíncrono
    }
    
    /// <summary>
    /// Envía una advertencia con configuración aplicada
    /// </summary>
    /// <param name="mensaje">El mensaje de la advertencia</param>
    /// <param name="consejo">Consejo opcional relacionado con la advertencia</param>
    public async Task EnviarAdvertenciaAsync(string mensaje, string? consejo = null)
    {
        if (_config.MostrarDebug)
        {
            Console.WriteLine($"[DEBUG] Enviando advertencia: {mensaje}");
        }
        
        var notificacion = new NotificacionAdvertencia(_notificador, mensaje, consejo);
        notificacion.Enviar();
        
        await Task.Delay(150); // Simular procesamiento asíncrono
    }
    
    /// <summary>
    /// Envía una confirmación con configuración aplicada
    /// </summary>
    /// <param name="mensaje">El mensaje de confirmación</param>
    /// <param name="accion">La acción que se está confirmando</param>
    public async Task EnviarConfirmacionAsync(string mensaje, string accion)
    {
        if (_config.MostrarDebug)
        {
            Console.WriteLine($"[DEBUG] Enviando confirmación para acción: {accion}");
        }
        
        var notificacion = new NotificacionConfirmacion(_notificador, mensaje, accion);
        notificacion.Enviar();
        
        await Task.Delay(100); // Simular procesamiento asíncrono
    }
    
    /// <summary>
    /// Envía una notificación usando el factory con configuración aplicada
    /// </summary>
    /// <param name="tipo">El tipo de notificación</param>
    /// <param name="mensaje">El mensaje de la notificación</param>
    /// <param name="parametroExtra">Parámetro extra opcional</param>
    public async Task EnviarNotificacionAsync(TipoNotificacion tipo, string mensaje, object? parametroExtra = null)
    {
        if (_config.MostrarDebug)
        {
            Console.WriteLine($"[DEBUG] Enviando notificación de tipo {tipo}: {mensaje}");
        }
        
        var notificacion = NotificacionFactory.Crear(tipo, _notificador, mensaje, parametroExtra);
        notificacion.Enviar();
        
        // Aplicar configuraciones específicas según el tipo
        await AplicarConfiguracionesPorTipo(tipo, parametroExtra);
        
        await Task.Delay(100); // Simular procesamiento asíncrono
    }
    
    /// <summary>
    /// Obtiene información sobre la plataforma actual
    /// </summary>
    public string PlataformaActual => _notificador.NombrePlataforma;
    
    /// <summary>
    /// Obtiene la configuración actual
    /// </summary>
    public NotificacionConfig Configuracion => _config;
    
    /// <summary>
    /// Determina si se debe reproducir sonido según el nivel de criticidad
    /// </summary>
    /// <param name="nivel">El nivel de criticidad</param>
    /// <returns>True si se debe reproducir sonido</returns>
    private bool DebeReproducirSonido(NivelCriticidad nivel)
    {
        var nivelMinimo = _config.NivelMinimoSonido.ToLower() switch
        {
            "baja" => NivelCriticidad.Baja,
            "media" => NivelCriticidad.Media,
            "alta" => NivelCriticidad.Alta,
            "critica" => NivelCriticidad.Critica,
            _ => NivelCriticidad.Media
        };
        
        return nivel >= nivelMinimo;
    }
    
    /// <summary>
    /// Aplica configuraciones específicas según el tipo de notificación
    /// </summary>
    /// <param name="tipo">El tipo de notificación</param>
    /// <param name="parametroExtra">Parámetro extra</param>
    private async Task AplicarConfiguracionesPorTipo(TipoNotificacion tipo, object? parametroExtra)
    {
        switch (tipo)
        {
            case TipoNotificacion.Alerta:
                if (parametroExtra is NivelCriticidad nivel && _config.SonarAlertas && DebeReproducirSonido(nivel))
                {
                    _notificador.SonarAlerta();
                }
                break;
                
            case TipoNotificacion.Mensaje:
                // Para mensajes, no aplicar configuraciones especiales
                break;
                
            case TipoNotificacion.Advertencia:
                // Para advertencias, solo vibrar si es móvil
                if (_config.VibrarEnMovil && _notificador.NombrePlataforma == "Móvil")
                {
                    _notificador.Vibrar();
                }
                break;
                
            case TipoNotificacion.Confirmacion:
                // Para confirmaciones, no aplicar configuraciones especiales
                break;
        }
        
        await Task.CompletedTask;
    }
}
