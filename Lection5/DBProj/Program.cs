using DBProj.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace DBProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestDBContext>()
                .UseNpgsql("Host=localhost; Username=postgres; Password=example; Database=TestBase").UseLazyLoadingProxies();
            using (var ctx = new TestDBContext(optionsBuilder.Options))
            {
                //var user = new User();
                //user.Name = "Nick";
                //user.Messages = new HashSet<Message>();
                //user.Messages.Add(new Message { MessageContent = "Hello!"});
                //user.Messages.Add(new Message { MessageContent = "I'm Nick!" });
                //ctx.Add(user);

                //ctx.SaveChanges();

                var users = ctx.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Имя {user.Name}");
                    Console.WriteLine("________Сообщения:");

                    var messages = user.Messages;
                    foreach (var message in messages)
                    {
                        Console.WriteLine($"___________: {message.MessageContent}");
                    }
                }
            }
            using (var ctx = new TestDBContext(optionsBuilder.Options))
            {

                var user = ctx.Users.FirstOrDefault(x => x.Name == "Nick");
                if (user != null)
                {
                    user.Name = "Николай";
                }
                ctx.SaveChanges();
            }
        }
    }
}