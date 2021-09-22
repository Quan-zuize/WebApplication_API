using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfService2;
using WebApplication2.ServiceReference1;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Session["LoginUser"].ToString())|| Session["LoginUser"]==null)
                return RedirectToAction("Login");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        Service1Client db = new Service1Client();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                if (db.Login(user.Username, user.Password))
                {
                    Session["LoginUser"] = user.Username;
                    return RedirectToAction("Chat");
                }
                TempData["AlertMessage"] = "Login not succesfully.";
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                if (db.Register(user.Username, user.Password).Equals("Đăng kí thành công"))
                {
                    Session["LoginUser"] = user.Username;
                    return RedirectToAction("Chat");
                }
                TempData["AlertMessage"] = "db.Register(user.Username, user.Password)";
            }
            return View();
        }

        public ActionResult AllChat()
        {
            return View(db.GetAllChat());
        }

        public ActionResult Chat(string content)
        {
            if (string.IsNullOrEmpty(Session["LoginUser"].ToString()))
                return RedirectToAction("Login");

            if (db.SendChat(content, Session["LoginUser"].ToString()).Equals("Chat sent!"))
            {
                return Content("Chat sent!");
            }
            return View();
        }
    }
}