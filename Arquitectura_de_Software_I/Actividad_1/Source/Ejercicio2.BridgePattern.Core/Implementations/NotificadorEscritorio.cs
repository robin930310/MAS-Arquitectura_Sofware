using Ejercicio2.BridgePattern.Core.Interfaces;

namespace Ejercicio2.BridgePattern.Core.Implementations;

/// <summary>
/// Implementación del notificador para plataforma de Escritorio
/// </summary>
public class NotificadorEscritorio : INotificador
{
    /// <summary>
    /// Muestra una notificación en la plataforma de escritorio
    /// </summary>
    /// <param name="mensaje">El mensaje a mostrar</param>
    /// <param name="tipo">El tipo de notificación</param>
    public void MostrarNotificacion(string mensaje, string tipo)
    {
        Console.WriteLine($"🖥️ [ESCRITORIO] {tipo}: {mensaje}");
        
        // En una implementación real, aquí se integraría con
        // MessageBox (WinForms), System.Windows.MessageBox (WPF), o notificaciones del sistema
        SimularNotificacionEscritorio(tipo, mensaje);
    }
    
    /// <summary>
    /// Reproduce un sonido de alerta en escritorio
    /// </summary>
    public void SonarAlerta()
    {
        Console.WriteLine("🔊 [ESCRITORIO] Reproduciendo sonido de alerta (SystemSounds)");
        
        // En una implementación real, se usaría SystemSounds
        // Por ahora usamos el simulador
        SimularSonidoEscritorio();
    }
    
    /// <summary>
    /// No se puede vibrar en escritorio
    /// </summary>
    public void Vibrar()
    {
        Console.WriteLine("🖥️ [ESCRITORIO] Vibración no disponible en escritorio");
    }
    
    /// <summary>
    /// Obtiene el nombre de la plataforma
    /// </summary>
    public string NombrePlataforma => "Escritorio";
    
    /// <summary>
    /// Simula la visualización de notificación de escritorio
    /// </summary>
    private static void SimularNotificacionEscritorio(string tipo, string mensaje)
    {
        var color = tipo switch
        {
            "MENSAJE" => ConsoleColor.Cyan,
            "ALERTA" => ConsoleColor.Red,
            "ADVERTENCIA" => ConsoleColor.Yellow,
            "CONFIRMACIÓN" => ConsoleColor.Green,
            _ => ConsoleColor.Gray
        };
        
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine($"    ┌─ Ventana de Escritorio ────────────────┐");
        Console.WriteLine($"    │ {tipo.PadRight(35)} │");
        Console.WriteLine($"    │ {mensaje.PadRight(35)} │");
        Console.WriteLine($"    │ [OK] [Cancelar]                        │");
        Console.WriteLine($"    └────────────────────────────────────────┘");
        Console.ForegroundColor = originalColor;
    }
    
    /// <summary>
    /// Simula la reproducción de sonido de escritorio
    /// </summary>
    private static void SimularSonidoEscritorio()
    {
        // Simular sonido de escritorio con múltiples beeps
        for (int i = 0; i < 3; i++)
        {
            Console.Beep(1000, 150);
            Thread.Sleep(50);
        }
    }
}
