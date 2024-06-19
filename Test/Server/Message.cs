using System.Text.Json;

namespace Server
{
    public class Message
{
    public string? Text { get; set; }
    public DateTime DateTime { get; set; }
    public string? NickNameFrom { get; set; }
    public string? NickNameTo { get; set; }

    public string SerialazeMessageToJSON() => JsonSerializer.Serialize(this);

    public static Message? DeserializeMessgeFromJSON(string message) => JsonSerializer.Deserialize<Message>(message);

    public void PrintGetMessageFrom()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"{DateTime} \n Получено сообщение {Text} \n от {NickNameFrom}  ";
    }
}
}
