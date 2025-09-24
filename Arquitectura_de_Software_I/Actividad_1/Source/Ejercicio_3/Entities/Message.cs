namespace Ejercicio_3.Entities;

public class Message
{
    public int SenderId { get; }
    public string SenderName { get; }
    public string Content { get; }
    public DateTime Timestamp { get; }
    public HashSet<int> ReadBy { get; }

    public Message(int senderId, string senderName, string content)
    {
        SenderId = senderId;
        SenderName = senderName;
        Content = content;
        Timestamp = DateTime.Now;
        ReadBy = new HashSet<int>();
    }

    public void MarkAsRead(int userId) => ReadBy.Add(userId);
    public bool IsReadBy(int userId) => ReadBy.Contains(userId);
}
