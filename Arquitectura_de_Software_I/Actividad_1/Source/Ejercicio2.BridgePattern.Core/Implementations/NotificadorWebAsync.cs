using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Implementations;

/// <summary>
/// Implementación asíncrona del notificador para plataforma Web
/// </summary>
public class NotificadorWebAsync : INotificadorAsync, INotificador
{
    /// <summary>
    /// Muestra una notificación en la plataforma web de forma asíncrona
    /// </summary>
    /// <param name="mensaje">El mensaje a mostrar</param>
    /// <param name="tipo">El tipo de notificación</param>
    /// <returns>Una tarea que representa la operación asíncrona</returns>
    public async Task MostrarNotificacionAsync(string mensaje, string tipo)
    {
        Console.WriteLine($"🌐 [WEB ASYNC] {tipo}: {mensaje}");
        
        // Simular operación asíncrona (ej: llamada a API web)
        await Task.Delay(100);
        
        SimularNotificacionWebAsync(tipo, mensaje);
    }
    
    /// <summary>
    /// Reproduce un sonido de alerta en web de forma asíncrona
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona</returns>
    public async Task SonarAlertaAsync()
    {
        Console.WriteLine("🔊 [WEB ASYNC] Reproduciendo sonido de alerta (Web Audio API)");
        
        // Simular operación asíncrona
        await Task.Delay(50);
        
        SimularSonidoWebAsync();
    }
    
    /// <summary>
    /// Intenta vibrar en web de forma asíncrona
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona</returns>
    public async Task VibrarAsync()
    {
        Console.WriteLine("📱 [WEB ASYNC] Intento de vibración (Vibration API)");
        
        // Simular operación asíncrona
        await Task.Delay(25);
    }
    
    /// <summary>
    /// Obtiene el nombre de la plataforma
    /// </summary>
    public string NombrePlataforma => "Web Async";
    
    // Implementación síncrona para INotificador
    void INotificador.MostrarNotificacion(string mensaje, string tipo)
    {
        MostrarNotificacionAsync(mensaje, tipo).GetAwaiter().GetResult();
    }
    
    void INotificador.SonarAlerta()
    {
        SonarAlertaAsync().GetAwaiter().GetResult();
    }
    
    void INotificador.Vibrar()
    {
        VibrarAsync().GetAwaiter().GetResult();
    }
    
    /// <summary>
    /// Simula la visualización de notificación web asíncrona
    /// </summary>
    private static void SimularNotificacionWebAsync(string tipo, string mensaje)
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
        Console.WriteLine($"    ┌─ Notificación Web (Async) ────────────┐");
        Console.WriteLine($"    │ {tipo.PadRight(35)} │");
        Console.WriteLine($"    │ {mensaje.PadRight(35)} │");
        Console.WriteLine($"    │ ⚡ Procesado de forma asíncrona       │");
        Console.WriteLine($"    └─────────────────────────────────────┘");
        Console.ForegroundColor = originalColor;
    }
    
    /// <summary>
    /// Simula la reproducción de sonido web asíncrono
    /// </summary>
    private static void SimularSonidoWebAsync()
    {
        // Simular sonido asíncrono
        Task.Run(() =>
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(800 + (i * 200), 200);
                Thread.Sleep(50);
            }
        });
    }
}
