using Ejercicio_3.Entities;

namespace Ejercicio_3.Mediator;

public interface IChannel
{
    string Name { get; }
    void Register(User user);
    void Send(Message message, User sender);

    IReadOnlyList<User> Users { get; }
    IReadOnlyList<Message> History { get; }
}
