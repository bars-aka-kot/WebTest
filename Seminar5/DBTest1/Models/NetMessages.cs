using System.Text.Json;

namespace DBTest1.Models
{
    public enum TypeSend
    {
        MassSend,
        OneSend,
        DefaultSend
    }
    public enum Commands
    {
        Register,
        Message,
        Confirmation
    }
    public class NetMessage
    {
        public Commands Command { get; set; }
        public string? Text { get; set; }
        public DateTime DateTime { get; set; }
        public string? NickNameFrom { get; set; }
        public string? NickNameTo { get; set; }

        public string SerialazeMessageToJSON() => JsonSerializer.Serialize(this);

        public static NetMessage? DeserializeMessgeFromJSON(string message) => JsonSerializer.Deserialize<NetMessages>(message);

        public void PrintGetMessageFrom()
        {
            Console.WriteLine(ToString());

        }

        public override string ToString()
        {
            return $"{DateTime} Получено сообщение {Text} от {NickNameFrom}  ";
        }
    }
}
