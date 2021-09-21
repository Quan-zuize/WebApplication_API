using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Cinema db = new Cinema();

        public void Add(Movie m)
        {
            db.Movies.Add(m);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            Movie m = db.Movies.Find(Id);
            db.Movies.Remove(m);
            db.SaveChanges();
        }

        public void Edit(Movie m)
        {
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            List<Movie> movieLst = new List<Movie>();
            var movie = from m in db.Movies
                        select m;
            foreach (var item in movie)
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
                movieLst.Add(m);
            }
            return movieLst;
        }

        public Movie GetById(int Id)
        {
            var getMv = from k in db.Movies where k.MovieId == Id select k;
            Movie m = new Movie();
            foreach(var item in getMv)
            {
                m.MovieId = item.MovieId;
                m.Title = item.Title;
                m.ReleaseDate = item.ReleaseDate;
                m.RunningTime = item.RunningTime;
                m.GenreId = item.GenreId;
                m.BoxOffice = item.BoxOffice;
            }
            return m;
        }

        public List<Movie> Search(string Search)
        {
            List<Movie> movieLst = new List<Movie>();
            var getMv = from k in db.Movies where k.Title.Contains(Search) select k;
            foreach (var item in getMv)
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
                movieLst.Add(m);
            }
            return movieLst;
            //var movie = from m in db.Movies
            //            select m;
            //if (!string.IsNullOrEmpty(Search))
            //    movie = movie.Where(s => s.Title.Contains(Search));
            //return movie.ToList();
        }
    }
}
