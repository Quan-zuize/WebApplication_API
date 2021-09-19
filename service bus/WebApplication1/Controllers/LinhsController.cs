using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LinhsController : Controller
    {
        private DuLieuCuaLinh db = new DuLieuCuaLinh();

        // GET: Linhs
        public ActionResult Index()
        {
            return View(db.Linhs.ToList());
        }

        // GET: Linhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linhs linhs = db.Linhs.Find(id);
            if (linhs == null)
            {
                return HttpNotFound();
            }
            return View(linhs);
        }

        // GET: Linhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Linhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,LinhsComment,feelings")] Linhs linhs)
        {
            if (ModelState.IsValid)
            {
                db.Linhs.Add(linhs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(linhs);
        }

        // GET: Linhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linhs linhs = db.Linhs.Find(id);
            if (linhs == null)
            {
                return HttpNotFound();
            }
            return View(linhs);
        }

        // POST: Linhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,LinhsComment,feelings")] Linhs linhs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(linhs);
        }

        // GET: Linhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linhs linhs = db.Linhs.Find(id);
            if (linhs == null)
            {
                return HttpNotFound();
            }
            return View(linhs);
        }

        // POST: Linhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Linhs linhs = db.Linhs.Find(id);
            db.Linhs.Remove(linhs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
