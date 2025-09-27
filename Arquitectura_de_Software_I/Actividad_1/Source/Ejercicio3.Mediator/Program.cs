using Ejercicio3.Mediator;
using Ejercicio3.Mediator.Mediator;
using Ejercicio3.Mediator.Models;
using Spectre.Console;

internal class Program
{
    private static List<User> _users;
    private static ReflectiveChatMediator _chatMediator;
    private static Bogus.Faker<User> _userFaker = new Bogus.Faker<User>()
                                          .RuleFor(u => u.NickName, f => f.Person.FirstName);

    private static void Main(string[] args)
    {
        // Instanciar el mediador reflexivo
        _chatMediator = new ReflectiveChatMediator();
        IChatMediator chat = _chatMediator;

        // Configuracion de creacion de usuarios
        // cada usuario creado recibe el mediador
        _userFaker.CustomInstantiator(f => new User(chat));

        // Generar usuarios
        _users = GenerateUsers();

        // Agregar usuarios al mediador
        _users.ForEach(chat.AddUser);

        while (true)
        {
            EjemploPatron();
            MostrarEstadisticas();
            Ejercicio3.Layout.Layout.Instance.Render();
        }
    }

    /// <summary>
    /// Ejemplo del patrón Mediator
    /// </summary>
    public static void EjemploPatron()
    {
        // Obtener datos del formulario del chat
        Tuple<string, string, string> chatForm = Ejercicio3.Layout.Layout.Instance.ChatForm();

        string messageFrom = chatForm.Item1;
        string messageTo = chatForm.Item2;
        string message = chatForm.Item3;

        // El usuario envia el mensaje
        _users.Find(x => x.NickName == messageFrom)
             .SendMessage(messageTo, message);
    }

    /// <summary>
    /// Genera una lista de usuarios con nombres aleatorios
    /// </summary>
    public static List<User> GenerateUsers()
    {
        int countUsers = Ejercicio3.Layout.Layout.Instance.SelectCountUsers();

        List<User> users = _userFaker.Generate(countUsers);
        Ejercicio3.Layout.Layout.Instance.SetChatPanels(users.Select(x => x.NickName));

        return users;
    }

    /// <summary>
    /// Muestra estadísticas del chat usando las capacidades reflexivas del mediador.
    /// </summary>
    public static void MostrarEstadisticas()
    {
        if (_chatMediator == null) return;

        var chatStats = _chatMediator.GetChatStatistics();
        var participantsInfo = _chatMediator.GetParticipantsInfo();

        Console.WriteLine("\n=== ESTADÍSTICAS DEL CHAT ===");
        Console.WriteLine($"Total de usuarios: {chatStats["TotalUsers"]}");
        Console.WriteLine($"Handlers registrados: {chatStats["TotalHandlers"]}");
        Console.WriteLine($"Última actividad: {chatStats["LastActivity"]}");

        Console.WriteLine("\n=== ESTADÍSTICAS POR USUARIO ===");
        foreach (var user in _users)
        {
            var userStats = user.GetUserStatistics();
            Console.WriteLine($"Usuario: {userStats["NickName"]}");
            Console.WriteLine($"  - Online: {userStats["IsOnline"]}");
            Console.WriteLine($"  - Mensajes enviados: {userStats["MessagesSent"]}");
            Console.WriteLine($"  - Mensajes recibidos: {userStats["MessagesReceived"]}");
            Console.WriteLine($"  - Última actividad: {userStats["LastActivity"]}");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Demuestra las capacidades avanzadas del mediador reflexivo.
    /// </summary>
    public static void DemostrarCapacidadesAvanzadas()
    {
        Console.WriteLine("\n=== DEMOSTRACIÓN DE CAPACIDADES AVANZADAS ===");

        // Cambiar estado de un usuario
        if (_users.Count > 0)
        {
            var user = _users.First();
            user.SetOnlineStatus(false);

            // Intentar enviar mensaje a usuario offline
            user.SendMessage("Todos", "Mensaje desde usuario offline");

            // Volver a conectar
            user.SetOnlineStatus(true);
        }

        // Reiniciar contadores de mensajes
        foreach (var user in _users)
        {
            user.ResetMessageCounters();
        }
    }
}
