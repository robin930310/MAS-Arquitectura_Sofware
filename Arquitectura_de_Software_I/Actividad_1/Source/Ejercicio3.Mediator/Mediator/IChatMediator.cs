using Ejercicio3.Mediator.Models;

namespace Ejercicio3.Mediator;

public interface IChatMediator
{
    /// <summary>
    /// Envía un mensaje de un usuario a otro o a todos los usuarios.
    /// </summary>
    /// <param name="from">El remitente del mensaje.</param>
    /// <param name="to">El destinatario del mensaje ("Todos" para enviar a todos).</param>
    /// <param name="message">El contenido del mensaje.</param>
    void SendMessage(string from, string to, string message);

    /// <summary>
    /// Agrega un usuario al chat.
    /// </summary>
    /// <param name="user">El usuario a agregar.</param>
    void AddUser(User user);
}

