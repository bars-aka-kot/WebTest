using DBprj2.Model;
using Microsoft.Extensions.Options;

namespace DBprj2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new TestBaseContext())
            {
                var users = ctx.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Имя {user.Name}");
                    Console.WriteLine("________Сообщения:");

                    var messages = user.Messages;
                    foreach (var message in messages)
                    {
                        Console.WriteLine($"___________: {message.Message1}");
                    }
                }
            }
        }
    }
}
