using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_MVC_Chat_API.Controllers
{
    public class UsersVController : Controller
    {
        // GET: UsersV
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersV/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersV/Create
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

        // GET: UsersV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersV/Edit/5
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

        // GET: UsersV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersV/Delete/5
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
    }
}
