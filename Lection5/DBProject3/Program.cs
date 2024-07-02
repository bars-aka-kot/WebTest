using DBProject3.Model;
using System.Diagnostics.Eventing.Reader;

namespace DBProject3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new TestBaseContext())
            {
                //var user1 = new User() { Name = "Саша", GenderId = Model.GenderId.Male };
                //var user2 = new User() { Name = "Маша", GenderId = Model.GenderId.Female };
            
                //ctx.Users.Add(user1);
                //ctx.Users.Add(user2);
                //ctx.SaveChanges();
            }



            using (var ctx = new TestBaseContext())
            {
                //var users = ctx.Users.ToList();
                //foreach (var user in users)
                //{
                //    Console.WriteLine($"Имя {user.Name}");
                //    Console.WriteLine("________Сообщения:");

                //    var messages = user.Messages;
                //    foreach (var message in messages)
                //    {
                //        Console.WriteLine($"___________: {message.Message1}");
                //    }
                //}

                using (var txn = ctx.Database.BeginTransaction())
                {
                    var user = new User { Name = "Олег", GenderId = Model.GenderId.Male  };
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                    Console.WriteLine($"Id = {user.Id}");
                    if (user.Id % 2 == 0)
                    {
                        user.Messages.Add(new Message { Message1 = "четный" });
                    }
                    else { user.Messages.Add(new Message { Message1 = "нечетный" }); }
                
                    ctx.SaveChanges();
                    txn.Commit();
                }


            }
        }
    }
}
