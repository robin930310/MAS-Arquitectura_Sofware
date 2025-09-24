using Ejercicio_3.Mediator;

namespace Ejercicio_3.Entities;

public class User
{
    public int Id { get; }
    public string Name { get; }
    private readonly List<IChannel> _channels = new();

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void JoinChannel(IChannel channel)
    {
        if (!_channels.Contains(channel))
        {
            _channels.Add(channel);
            channel.Register(this);
        }
    }

    public void Send(string content, IChannel channel)
    {
        if (!_channels.Contains(channel))
        {
            Console.WriteLine($"{Name} no está en la sala {channel.Name}!");
            return;
        }

        var message = new Message(Id, Name, content);
        channel.Send(message, this);
    }

    public void Receive(Message message)
    {
        message.MarkAsRead(Id);
    }
}
