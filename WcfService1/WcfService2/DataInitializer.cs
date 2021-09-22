using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfService2
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<Texting>
    {
        protected override void Seed(Texting context)
        {
            context.Users.Add(new User() { Username = "Quan lxury", Password = "admin" });
            context.Users.Add(new User() { Username = "Quan ultra", Password = "user" });
            context.Users.Add(new User() { Username = "Quan vjp", Password = "user" });

            context.Chats.AddRange(new List<Chat>()
            {
                new Chat() {Id = 1, Content = "Doan ik", Username = "Quan vjp", SentTime = DateTime.Now},
                new Chat() {Id = 1, Content = "Zay ha", Username = "Quan ultra", SentTime = DateTime.Now.AddMinutes(1)},
                new Chat() {Id = 1, Content = "Dung roi", Username = "Quan lxury", SentTime = DateTime.Now.AddSeconds(20)}
        });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}