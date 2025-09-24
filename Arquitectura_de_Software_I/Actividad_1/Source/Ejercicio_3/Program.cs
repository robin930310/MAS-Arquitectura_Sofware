using Ejercicio_3.Entities;
using Ejercicio_3.Mediator;
using Ejercicio_3.Services;

class Program
{
    static void Main()
    {
        // Dependencias concretas se crean aquí, en el "composition root"
        IMessageNotifier notifier = new ConsoleMessageNotifier();

        IChannel general = new ChatRoom("General", notifier);
        IChannel trabajo = new ChatRoom("Trabajo", notifier);

        // Crear usuarios (Users no conocen la implementación de canal)
        var laura = new User(1, "Laura");
        var roger = new User(2, "Roger");
        var robinson = new User(3, "Robinson");

        // Unir usuarios a canales
        laura.JoinChannel(general);
        roger.JoinChannel(general);
        robinson.JoinChannel(general);

        laura.JoinChannel(trabajo);
        roger.JoinChannel(trabajo);

        var users = new List<User> { laura, roger, robinson };
        var rooms = new List<IChannel> { general, trabajo };

        // Conversación de prueba
        laura.Send("Hola a todos!", general);
        roger.Send("Hola Laura, ¿cómo estás?", general);
        robinson.Send("¡Hola chicos! Todo bien por aquí.", general);

        laura.Send("Hola Roger, listo para trabajar?", trabajo);
        roger.Send("Sí, todo preparado.", trabajo);

        // CLI interactiva
        User currentUser = laura;
        IChannel currentRoom = general;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===== Chat CLI (Mediator + SOLID) =====");
            Console.ResetColor();
            Console.WriteLine($"Usuario: {currentUser.Name}");
            Console.WriteLine($"Sala: {currentRoom.Name}");
            Console.WriteLine("---------------------------------------");

            notifier.ShowHistory(currentRoom, currentUser);

            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Cambiar de usuario");
            Console.WriteLine("2. Cambiar de sala");
            Console.WriteLine("3. Enviar mensaje");
            Console.WriteLine("4. Salir");
            Console.Write("=> Elige opción: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("\nElige usuario:");
                    for (int i = 0; i < users.Count; i++)
                        Console.WriteLine($"{i + 1}. {users[i].Name}");
                    if (int.TryParse(Console.ReadLine(), out int userIndex) &&
                        userIndex > 0 && userIndex <= users.Count)
                    {
                        currentUser = users[userIndex - 1];
                    }
                    break;

                case "2":
                    Console.WriteLine("\nElige sala:");
                    for (int i = 0; i < rooms.Count; i++)
                        Console.WriteLine($"{i + 1}. {rooms[i].Name}");
                    if (int.TryParse(Console.ReadLine(), out int roomIndex) &&
                        roomIndex > 0 && roomIndex <= rooms.Count)
                    {
                        currentRoom = rooms[roomIndex - 1];
                    }
                    break;

                case "3":
                    Console.Write("\nEscribe tu mensaje: ");
                    var msg = Console.ReadLine() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(msg))
                        currentUser.Send(msg, currentRoom);
                    break;

                case "4":
                    return;
            }
        }
    }
}
