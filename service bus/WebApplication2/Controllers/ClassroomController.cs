using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ClassroomController : Controller
    {
        ServiceReference1.MyServiceClient service = new ServiceReference1.MyServiceClient();
        // GET: Classroom
        public ActionResult Index()
        {
            List<SinhVien> lstRecord = new List<SinhVien>();
            var list = service.GetAllUser();

            foreach (var item in list)
            {
                SinhVien sv = new SinhVien();
                sv.Id = item.Id;
                sv.Name = item.Name;
                sv.Email = item.Email;
                sv.Phone = item.Phone;
                sv.Pass = item.Pass;
                sv.ClassID = item.ClassID;
                lstRecord.Add(sv);
            }
            return View(lstRecord);
        }

        // GET: Classroom/Details/5
        public ActionResult Details(int id)
        {
            var edSv = service.GetSvById(id);
            SinhVien sv = new SinhVien();
            sv.Name = edSv.Name;
            sv.Email = edSv.Email;
            sv.Phone = edSv.Phone;
            sv.Pass = edSv.Pass;
            sv.ClassID = edSv.ClassID;
            return View();
        }

        // GET: Classroom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classroom/Create
        [HttpPost]
        public ActionResult Create(SinhVien addSv)
        {
            try
            {
                // TODO: Add insert logic here
                SinhVien sv = new SinhVien();
                sv.Name = addSv.Name;
                sv.Email = addSv.Email;
                sv.Phone = addSv.Phone;
                sv.Pass = addSv.Pass;
                sv.ClassID = addSv.ClassID;
                service.AddSv(sv.Name, sv.Email, sv.Phone, sv.Pass, sv.ClassID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Classroom/Edit/5
        public ActionResult Edit(int id)
        {
            var edSv = service.GetSvById(id);
            SinhVien sv = new SinhVien();
            sv.Name = edSv.Name;
            sv.Email = edSv.Email;
            sv.Phone = edSv.Phone;
            sv.Pass = edSv.Pass;
            sv.ClassID = edSv.ClassID;
            return View();
        }

        //POST: Classroom/Edit/5
        [HttpPost]
        public ActionResult Edit(SinhVien editSv)
        {
            try
            {
                // TODO: Add update logic here
                SinhVien sv = new SinhVien();
                sv.Id = editSv.Id;
                sv.Name = editSv.Name;
                sv.Email = editSv.Email;
                sv.Phone = editSv.Phone;
                sv.Pass = editSv.Pass;
                sv.ClassID = editSv.ClassID;

                int svidx = service.UpdateSv(sv.Id, sv.Name, sv.Email, sv.Phone, sv.Pass, sv.ClassID);
                if (svidx > 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classroom/Delete/5
        public ActionResult Delete(int id)
        {
            int svidx = service.DeleteSvById(id);
            if(svidx > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Classroom/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
