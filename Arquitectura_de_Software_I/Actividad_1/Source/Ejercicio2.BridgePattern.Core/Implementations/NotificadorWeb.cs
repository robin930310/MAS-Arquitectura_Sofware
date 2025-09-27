using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Implementations;

/// <summary>
/// Implementación del notificador para plataforma Web
/// </summary>
public class NotificadorWeb : INotificador
{
    /// <summary>
    /// Muestra una notificación en la plataforma web
    /// </summary>
    /// <param name="mensaje">El mensaje a mostrar</param>
    /// <param name="tipo">El tipo de notificación</param>
    public void MostrarNotificacion(string mensaje, string tipo)
    {
        Console.WriteLine($"🌐 [WEB] {tipo}: {mensaje}");
        
        // En una implementación real, aquí se integraría con JavaScript
        // para mostrar notificaciones del navegador usando la Notification API
        SimularNotificacionWeb(tipo, mensaje);
    }
    
    /// <summary>
    /// Reproduce un sonido de alerta en web
    /// </summary>
    public void SonarAlerta()
    {
        Console.WriteLine("🔊 [WEB] Reproduciendo sonido de alerta (Web Audio API)");
        
        // En una implementación real, se usaría Web Audio API
        SimularSonidoWeb();
    }
    
    /// <summary>
    /// Intenta vibrar en web (limitado por el navegador)
    /// </summary>
    public void Vibrar()
    {
        Console.WriteLine("📱 [WEB] Intento de vibración (Vibration API - limitado por navegador)");
        
        // En una implementación real, se usaría Vibration API
        // que solo funciona en algunos navegadores móviles
    }
    
    /// <summary>
    /// Obtiene el nombre de la plataforma
    /// </summary>
    public string NombrePlataforma => "Web";
    
    /// <summary>
    /// Simula la visualización de notificación web
    /// </summary>
    private static void SimularNotificacionWeb(string tipo, string mensaje)
    {
        var color = tipo switch
        {
            "MENSAJE" => ConsoleColor.Blue,
            "ALERTA" => ConsoleColor.Red,
            "ADVERTENCIA" => ConsoleColor.Yellow,
            "CONFIRMACIÓN" => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
        
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine($"    ┌─ Notificación Web ──────────────────┐");
        Console.WriteLine($"    │ {tipo.PadRight(35)} │");
        Console.WriteLine($"    │ {mensaje.PadRight(35)} │");
        Console.WriteLine($"    └─────────────────────────────────────┘");
        Console.ForegroundColor = originalColor;
    }
    
    /// <summary>
    /// Simula la reproducción de sonido web
    /// </summary>
    private static void SimularSonidoWeb()
    {
        // Simular diferentes tonos según el tipo
        for (int i = 0; i < 3; i++)
        {
            Console.Beep(800 + (i * 200), 200);
            Thread.Sleep(50);
        }
    }
}
