using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ServiceReference1;
    
namespace WebApplication1.Controllers
{
    public class CinemaController : Controller
    {
        readonly Service1Client data = new Service1Client();     
        // GET: Cinema
        public ActionResult Index(string search)
        {
            List<Movie> movies = new List<Movie>();
            var list = data.GetAll();
            foreach(var item in list)
            {
                Movie m = new Movie
                {
                    MovieId = item.MovieId,
                    Title = item.Title,
                    ReleaseDate = item.ReleaseDate,
                    RunningTime = item.RunningTime,
                    GenreId = item.GenreId,
                    BoxOffice = item.BoxOffice
                };
                movies.Add(m);
            }
            if(!string.IsNullOrWhiteSpace(search))
            {
                var listsearch = data.Search(search);
                if (listsearch.Length != 0) movies.Clear();
                foreach (var item in listsearch)
                {
                    Movie m = new Movie
                    {
                        MovieId = item.MovieId,
                        Title = item.Title,
                        ReleaseDate = item.ReleaseDate,
                        RunningTime = item.RunningTime,
                        GenreId = item.GenreId,
                        BoxOffice = item.BoxOffice
                    };
                    movies.Add(m);
                }
            }
            return View(movies);
        }

        // GET: Cinema/Details/5
        public ActionResult Details(int id)
        {
            var film = data.GetById(id);
            return View(film);
        }

        // GET: Cinema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinema/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                data.Add(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinema/Edit/5
        public ActionResult Edit(int id)
        {
            var m = data.GetById(id);
            return View(m);
        }

        // POST: Cinema/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                data.Edit(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinema/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                data.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }           
        }

        // POST: Cinema/Delete/5
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
