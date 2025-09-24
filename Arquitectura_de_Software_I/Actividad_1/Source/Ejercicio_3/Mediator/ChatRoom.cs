using Ejercicio_3.Entities;
using Ejercicio_3.Services;

namespace Ejercicio_3.Mediator;

public class ChatRoom : IChannel
{
    private readonly List<User> _users = new();
    private readonly List<Message> _history = new();
    private readonly IMessageNotifier _notifier;

    public string Name { get; }

    public ChatRoom(string name, IMessageNotifier notifier)
    {
        Name = name;
        _notifier = notifier;
    }

    public void Register(User user)
    {
        if (!_users.Contains(user))
            _users.Add(user);
    }

    public void Send(Message message, User sender)
    {
        _history.Add(message);

        foreach (var user in _users)
        {
            if (user != sender)
                user.Receive(message);
        }

        _notifier.Notify(message, sender, this);
    }

    public IReadOnlyList<User> Users => _users.AsReadOnly();
    public IReadOnlyList<Message> History => _history.AsReadOnly();
}
