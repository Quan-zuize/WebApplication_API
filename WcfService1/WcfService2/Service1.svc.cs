using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Texting db = new Texting();
        public List<Chat> GetAllChat()
        {
            //List<Chat> chatLst = new List<Chat>();
            //var c = from a in db.Chats select a;
            //foreach(var item in c)
            //{
            //    Chat chat = new Chat();
            //    chat.Id = item.Id;
            //    chat.Content = item.Content;
            //    chat.Username = item.Username;
            //    chat.SentTime = item.SentTime;
            //    chatLst.Add(chat);
            //}
            //return chatLst;
            return db.Chats.ToList();
        }

        public bool Login(string Username, string Password)
        {
            var getUsr = from u in db.Users
                         where u.Username == Username && u.Password == Password
                         select u;
            var res = getUsr.Any() && getUsr!=null ? true : false;
            return res;
        }

        public string Register(string Username, string Password)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)) return "Tên đăng nhập và mật khẩu không được để trống";

            var getUsr = from u in db.Users where u.Username == Username select u;
            if (getUsr.Any() && getUsr != null)
            {
                return "Tên đăng nhập đã tồn tại";
            }
            db.Users.Add(new User() { Username = Username, Password = Password });
            db.SaveChanges();
            return "Đăng kí thành công";
        }

        public string SendChat(string Content, string Username)
        {
            if (string.IsNullOrWhiteSpace(Content) || string.IsNullOrWhiteSpace(Username)) return "Đoạn chat rỗng!";

            db.Chats.Add(new Chat() { Content = Content, Username = Username, SentTime = DateTime.Now });
            db.SaveChanges();
            return "Chat sent!";
        }
    }
}
