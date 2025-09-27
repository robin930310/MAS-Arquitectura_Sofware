using Ejercicio3.Attributes;

namespace Ejercicio3.Mediator.Models;

/// <summary>
/// Representa un usuario en el sistema de chat con capacidades avanzadas
/// usando atributos y reflexión para integración con el mediador.
/// </summary>
[MediatorParticipant("ChatUser")]
public class User
{
    /// <summary>
    /// Mediador de chat utilizado para enviar y recibir mensajes.
    /// </summary>
    private readonly IChatMediator _mediator;

    /// <summary>
    /// Apodo del usuario en el chat.
    /// </summary>
    [MediatorProperty("NickName", true)]
    public string NickName { get; set; }

    /// <summary>
    /// Indica si el usuario está en línea.
    /// </summary>
    [MediatorProperty("IsOnline")]
    public bool IsOnline { get; set; }

    /// <summary>
    /// Última actividad del usuario en el chat.
    /// </summary>
    [MediatorProperty("LastActivity")]
    public DateTime LastActivity { get; set; }

    /// <summary>
    /// ID único del usuario en el sistema.
    /// </summary>
    [MediatorProperty("UserId")]
    public Guid UserId { get; private set; }

    /// <summary>
    /// Contador de mensajes enviados por el usuario.
    /// </summary>
    [MediatorProperty("MessagesSent")]
    public int MessagesSent { get; private set; }

    /// <summary>
    /// Contador de mensajes recibidos por el usuario.
    /// </summary>
    [MediatorProperty("MessagesReceived")]
    public int MessagesReceived { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase User con el mediador especificado.
    /// </summary>
    /// <param name="_mediator">Instancia del mediador de chat.</param>
    public User(IChatMediator _mediator)
    {
        this._mediator = _mediator;
        UserId = Guid.NewGuid();
        IsOnline = true;
        LastActivity = DateTime.Now;
        MessagesSent = 0;
        MessagesReceived = 0;
    }

    /// <summary>
    /// Envía un mensaje a otro usuario a través del mediador.
    /// </summary>
    /// <param name="to">Destinatario del mensaje.</param>
    /// <param name="message">Contenido del mensaje.</param>
    public void SendMessage(string to, string message)
    {
        if (!IsOnline)
        {
            Console.WriteLine($"[WARNING] Usuario {NickName} está offline y no puede enviar mensajes.");
            return;
        }

        _mediator.SendMessage(NickName, to, message);
        MessagesSent++;
        LastActivity = DateTime.Now;

        Console.WriteLine($"[USER] {NickName} envió mensaje a {to}");
    }

    /// <summary>
    /// Recibe un mensaje de otro usuario y lo muestra en la interfaz de chat.
    /// </summary>
    /// <param name="from">Remitente del mensaje.</param>
    /// <param name="message">Contenido del mensaje.</param>
    public void ReceiveMessage(string from, string message)
    {
        MessagesReceived++;
        LastActivity = DateTime.Now;

        Layout.Layout.Instance.AddUserMessage(NickName, $"📩[dodgerblue2]{from}[/]:\n   {message}");

        Console.WriteLine($"[USER] {NickName} recibió mensaje de {from}");
    }

    /// <summary>
    /// Cambia el estado online/offline del usuario.
    /// </summary>
    /// <param name="isOnline">Nuevo estado online.</param>
    public void SetOnlineStatus(bool isOnline)
    {
        IsOnline = isOnline;
        LastActivity = DateTime.Now;

        var status = isOnline ? "conectado" : "desconectado";
        Console.WriteLine($"[USER] {NickName} se ha {status}");
    }

    /// <summary>
    /// Obtiene estadísticas del usuario.
    /// </summary>
    /// <returns>Diccionario con estadísticas del usuario.</returns>
    public Dictionary<string, object> GetUserStatistics()
    {
        return new Dictionary<string, object>
        {
            ["NickName"] = NickName,
            ["UserId"] = UserId.ToString(),
            ["IsOnline"] = IsOnline,
            ["LastActivity"] = LastActivity.ToString("HH:mm:ss"),
            ["MessagesSent"] = MessagesSent,
            ["MessagesReceived"] = MessagesReceived,
            ["TotalMessages"] = MessagesSent + MessagesReceived
        };
    }

    /// <summary>
    /// Reinicia los contadores de mensajes del usuario.
    /// </summary>
    public void ResetMessageCounters()
    {
        MessagesSent = 0;
        MessagesReceived = 0;
        Console.WriteLine($"[USER] Contadores de mensajes reiniciados para {NickName}");
    }
}
