using Ejercicio3.Mediator.Models;

namespace Ejercicio3.Mediator;

/// <summary>
/// Implementa el patrón Mediator para gestionar la comunicación entre usuarios en el chat.
/// </summary>
internal class ChatMediator : IChatMediator
{
    private readonly IDictionary<string, User> _users;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ChatMediator"/>.
    /// </summary>
    public ChatMediator()
    {
        _users = new Dictionary<string, User>();
    }

    /// <summary>
    /// Agrega un usuario al chat.
    /// </summary>
    /// <param name="user">El usuario a agregar.</param>
    public void AddUser(User user)
    {
        _users.Add(user.NickName, user);
    }

    /// <summary>
    /// Envía un mensaje de un usuario a otro o a todos los usuarios.
    /// </summary>
    /// <param name="from">El remitente del mensaje.</param>
    /// <param name="to">El destinatario del mensaje ("Todos" para enviar a todos).</param>
    /// <param name="message">El contenido del mensaje.</param>
    public void SendMessage(string from, string to, string message)
    {
        if ("Todos".Equals(to))
        {
            foreach (KeyValuePair<string, User> user in _users)
            {
                if (!from.Equals(user.Key))
                {
                    user.Value.ReceiveMessage(from, message);
                }
            }
        }
        else
        {
            _users.FirstOrDefault(u => to.Equals(u.Key)).Value?.ReceiveMessage(from, message);
        }
    }
}
