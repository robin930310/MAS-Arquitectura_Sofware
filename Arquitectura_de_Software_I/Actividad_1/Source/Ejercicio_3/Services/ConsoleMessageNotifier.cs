using Ejercicio_3.Entities;
using Ejercicio_3.Mediator;

namespace Ejercicio_3.Services;

public class ConsoleMessageNotifier : IMessageNotifier
{
    public void Notify(Message message, User sender, IChannel channel)
    {
        Console.Beep();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n[{channel.Name}] Nuevo mensaje");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($" {sender.Name}: {message.Content} ({message.Timestamp:HH:mm})");
        Console.ResetColor();
    }

    public void ShowHistory(IChannel channel, User viewer)
    {
        Console.WriteLine($"\nHistorial de [{channel.Name}]:\n");

        foreach (var msg in channel.History)
        {
            var status = msg.IsReadBy(viewer.Id) ? "" : "*";
            var color = msg.SenderId == viewer.Id ? ConsoleColor.Green : ConsoleColor.Yellow;

            Console.ForegroundColor = color;
            Console.WriteLine($"[{msg.Timestamp:HH:mm}] {msg.SenderName}: {msg.Content}  {status}");
            Console.ResetColor();

            msg.MarkAsRead(viewer.Id);
        }
    }
}
