using Ejercicio_3.Entities;
using Ejercicio_3.Mediator;

namespace Ejercicio_3.Services;

public interface IMessageNotifier
{
    void Notify(Message message, User sender, IChannel channel);
    void ShowHistory(IChannel channel, User viewer);
}
