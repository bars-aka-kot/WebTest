using System.Text.Json;

namespace Patterns
{
    public class Message
    {
        public Commands command { get; set; }
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
            return $"{DateTime} Получено сообщение {Text} от {NickNameFrom}  ";
        }
    }
}
