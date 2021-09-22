using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApp_MVC_Chat_API.Models;

namespace WebApp_MVC_Chat_API.Controllers
{
    public class ChatsVController : Controller
    {
        public static int Count = 0;
      //  private string url = "http://localhost:11908/api/Customer/";
          private String url =  "http://localhost:60387/api/Chats";  //api/Chats
        //  http://localhost:60387/ChatsV/GetAllChats
        // GET: ChatsV //
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChatsV/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChatsV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatsV/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatsV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChatsV/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatsV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatsV/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetAllChats()
        {
            ChatsVController.Count++;
            HttpClient httpclient = new HttpClient();
            var model = JsonConvert.DeserializeObject<IEnumerable<Chat>>(httpclient.GetStringAsync(url).Result) ;
            String listChats = "";
            foreach( var lc  in model)
            {
                listChats += ""  +": " + lc.Name + ": " + lc.Content + "\n";
            }
            ViewBag.Chats =  "" + +ChatsVController.Count + ": "+ listChats;
            return View();
        }
    }
}
