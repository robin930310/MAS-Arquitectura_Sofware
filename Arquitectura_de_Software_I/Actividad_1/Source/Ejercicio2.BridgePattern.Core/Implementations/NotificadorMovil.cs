using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Implementations;

/// <summary>
/// Implementación del notificador para plataforma Móvil
/// </summary>
public class NotificadorMovil : INotificador
{
    /// <summary>
    /// Muestra una notificación en la plataforma móvil
    /// </summary>
    /// <param name="mensaje">El mensaje a mostrar</param>
    /// <param name="tipo">El tipo de notificación</param>
    public void MostrarNotificacion(string mensaje, string tipo)
    {
        Console.WriteLine($"📱 [MÓVIL] {tipo}: {mensaje}");
        
        // En una implementación real, aquí se integraría con APIs nativas
        // como Android NotificationManager o iOS UserNotifications
        SimularNotificacionMovil(tipo, mensaje);
    }
    
    /// <summary>
    /// Reproduce un sonido de alerta en móvil
    /// </summary>
    public void SonarAlerta()
    {
        Console.WriteLine("🔊 [MÓVIL] Reproduciendo sonido de alerta (MediaPlayer)");
        
        // En una implementación real, se usarían APIs nativas
        SimularSonidoMovil();
    }
    
    /// <summary>
    /// Hace vibrar el dispositivo móvil
    /// </summary>
    public void Vibrar()
    {
        Console.WriteLine("📳 [MÓVIL] Vibrando dispositivo (Vibrator API)");
        
        // En una implementación real, se usaría Vibrator API
        SimularVibracionMovil();
    }
    
    /// <summary>
    /// Obtiene el nombre de la plataforma
    /// </summary>
    public string NombrePlataforma => "Móvil";
    
    /// <summary>
    /// Simula la visualización de notificación móvil
    /// </summary>
    private static void SimularNotificacionMovil(string tipo, string mensaje)
    {
        var icono = tipo switch
        {
            "MENSAJE" => "💬",
            "ALERTA" => "🚨",
            "ADVERTENCIA" => "⚠️",
            "CONFIRMACIÓN" => "✅",
            _ => "📢"
        };
        
        Console.WriteLine($"    {icono} ┌─ Notificación Push ────────────────┐");
        Console.WriteLine($"      │ {tipo.PadRight(32)} │");
        Console.WriteLine($"      │ {mensaje.PadRight(32)} │");
        Console.WriteLine($"      └─────────────────────────────────┘");
    }
    
    /// <summary>
    /// Simula la reproducción de sonido móvil
    /// </summary>
    private static void SimularSonidoMovil()
    {
        // Simular diferentes patrones de sonido móvil
        for (int i = 0; i < 2; i++)
        {
            Console.Beep(600, 300);
            Console.Beep(800, 300);
            Thread.Sleep(100);
        }
    }
    
    /// <summary>
    /// Simula la vibración móvil
    /// </summary>
    private static void SimularVibracionMovil()
    {
        // Simular patrón de vibración
        Console.WriteLine("    📳 Vibración corta...");
        Thread.Sleep(200);
        Console.WriteLine("    📳 Vibración larga...");
        Thread.Sleep(400);
        Console.WriteLine("    📳 Vibración corta...");
        Thread.Sleep(200);
    }
}
