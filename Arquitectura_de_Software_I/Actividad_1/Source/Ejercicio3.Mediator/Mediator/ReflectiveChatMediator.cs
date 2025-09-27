using Ejercicio3.Attributes;
using Ejercicio3.Mediator.Models;
using System.Reflection;

namespace Ejercicio3.Mediator.Mediator;
/// <summary>
/// Implementación avanzada del patrón Mediator que utiliza reflexión y atributos
/// para manejo dinámico de mensajes y participantes.
/// </summary>
public class ReflectiveChatMediator : IChatMediator
{
    private readonly IDictionary<string, User> _users;
    private readonly IDictionary<string, MethodInfo> _messageHandlers;
    private readonly IDictionary<string, object> _participants;

    /// <summary>
    /// Inicializa una nueva instancia del ReflectiveChatMediator.
    /// </summary>
    public ReflectiveChatMediator()
    {
        _users = new Dictionary<string, User>();
        _messageHandlers = new Dictionary<string, MethodInfo>();
        _participants = new Dictionary<string, object>();

        InitializeHandlers();
    }

    /// <summary>
    /// Inicializa los handlers de mensajes usando reflexión.
    /// </summary>
    private void InitializeHandlers()
    {
        var methods = GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.GetCustomAttribute<MediatorHandlerAttribute>() != null);

        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<MediatorHandlerAttribute>();
            if (attribute != null)
            {
                _messageHandlers[attribute.MessageType] = method;
            }
        }
    }

    /// <summary>
    /// Agrega un usuario al chat usando reflexión para configuración automática.
    /// </summary>
    /// <param name="user">El usuario a agregar.</param>
    public void AddUser(User user)
    {
        _users.Add(user.NickName, user);

        // Configurar propiedades del usuario usando reflexión
        ConfigureParticipantProperties(user);

        // Registrar como participante
        _participants[user.NickName] = user;

        Console.WriteLine($"[SYSTEM] Usuario '{user.NickName}' agregado al chat.");
    }

    /// <summary>
    /// Configura las propiedades de un participante usando reflexión.
    /// </summary>
    /// <param name="participant">Participante a configurar.</param>
    private void ConfigureParticipantProperties(object participant)
    {
        var properties = participant.GetType().GetProperties()
            .Where(p => p.GetCustomAttribute<MediatorPropertyAttribute>() != null);

        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<MediatorPropertyAttribute>();
            if (attribute != null && property.CanWrite)
            {
                // Configurar propiedades específicas del mediador
                var propertyName = string.IsNullOrEmpty(attribute.PropertyName)
                    ? property.Name
                    : attribute.PropertyName;

                switch (propertyName.ToLower())
                {
                    case "isonline":
                        property.SetValue(participant, true);
                        break;
                    case "lastactivity":
                        property.SetValue(participant, DateTime.Now);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Envía un mensaje usando el sistema de handlers con reflexión.
    /// </summary>
    /// <param name="from">El remitente del mensaje.</param>
    /// <param name="to">El destinatario del mensaje.</param>
    /// <param name="message">El contenido del mensaje.</param>
    public void SendMessage(string from, string to, string message)
    {
        // Determinar el tipo de mensaje
        var messageType = to.Equals("Todos", StringComparison.OrdinalIgnoreCase) ? "broadcast" : "direct";

        // Buscar handler apropiado
        if (_messageHandlers.ContainsKey(messageType))
        {
            var handler = _messageHandlers[messageType];
            var parameters = new object[] { from, to, message };

            try
            {
                handler.Invoke(this, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error al procesar mensaje: {ex.Message}");
            }
        }
        else
        {
            // Fallback al método original
            SendMessageFallback(from, to, message);
        }
    }

    /// <summary>
    /// Handler para mensajes de difusión (broadcast).
    /// </summary>
    [MediatorHandler("broadcast", "Maneja mensajes enviados a todos los usuarios")]
    private void HandleBroadcastMessage(string from, string to, string message)
    {
        Console.WriteLine($"[BROADCAST] {from} envió mensaje a todos: '{message}'");

        foreach (var user in _users.Values)
        {
            if (!from.Equals(user.NickName, StringComparison.OrdinalIgnoreCase))
            {
                user.ReceiveMessage(from, $"[TODOS] {message}");
            }
        }

        LogMessageActivity(from, to, message, "broadcast");
    }

    /// <summary>
    /// Handler para mensajes directos.
    /// </summary>
    [MediatorHandler("direct", "Maneja mensajes enviados a un usuario específico")]
    private void HandleDirectMessage(string from, string to, string message)
    {
        Console.WriteLine($"[DIRECT] {from} -> {to}: '{message}'");

        var targetUser = _users.Values.FirstOrDefault(u =>
            u.NickName.Equals(to, StringComparison.OrdinalIgnoreCase));

        if (targetUser != null)
        {
            targetUser.ReceiveMessage(from, message);
            LogMessageActivity(from, to, message, "direct");
        }
        else
        {
            Console.WriteLine($"[ERROR] Usuario '{to}' no encontrado.");
        }
    }

    /// <summary>
    /// Método de respaldo para enviar mensajes (implementación original).
    /// </summary>
    private void SendMessageFallback(string from, string to, string message)
    {
        if ("Todos".Equals(to, StringComparison.OrdinalIgnoreCase))
        {
            foreach (var user in _users.Values)
            {
                if (!from.Equals(user.NickName, StringComparison.OrdinalIgnoreCase))
                {
                    user.ReceiveMessage(from, message);
                }
            }
        }
        else
        {
            var targetUser = _users.Values.FirstOrDefault(u =>
                u.NickName.Equals(to, StringComparison.OrdinalIgnoreCase));
            targetUser?.ReceiveMessage(from, message);
        }
    }

    /// <summary>
    /// Registra la actividad del mensaje.
    /// </summary>
    private void LogMessageActivity(string from, string to, string message, string type)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss");
        var logMessage = $"[{timestamp}] {type.ToUpper()}: {from} -> {to}";

        // Aquí podrías agregar lógica para guardar logs en archivo o base de datos
        Console.WriteLine($"[LOG] {logMessage}");
    }

    /// <summary>
    /// Obtiene información de los participantes usando reflexión.
    /// </summary>
    /// <returns>Diccionario con información de los participantes.</returns>
    public Dictionary<string, object> GetParticipantsInfo()
    {
        var info = new Dictionary<string, object>();

        foreach (var participant in _participants)
        {
            var participantInfo = new Dictionary<string, object>();
            var properties = participant.Value.GetType().GetProperties()
                .Where(p => p.GetCustomAttribute<MediatorPropertyAttribute>() != null);

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<MediatorPropertyAttribute>();
                var key = string.IsNullOrEmpty(attribute.PropertyName)
                    ? property.Name
                    : attribute.PropertyName;

                participantInfo[key] = property.GetValue(participant.Value);
            }

            info[participant.Key] = participantInfo;
        }

        return info;
    }

    /// <summary>
    /// Obtiene estadísticas del chat usando reflexión.
    /// </summary>
    /// <returns>Estadísticas del chat.</returns>
    public Dictionary<string, object> GetChatStatistics()
    {
        return new Dictionary<string, object>
        {
            ["TotalUsers"] = _users.Count,
            ["TotalHandlers"] = _messageHandlers.Count,
            ["RegisteredParticipants"] = _participants.Keys.ToList(),
            ["AvailableMessageTypes"] = _messageHandlers.Keys.ToList(),
            ["LastActivity"] = DateTime.Now
        };
    }
}
