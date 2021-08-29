using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Genre
    {
        public int GenreId { get; set; }//Id the loai
        public string GenreName { get; set; } //Ten the loai
        public virtual ICollection<Album> Albums { get; set; }
        public Genre()
        {
            this.Albums = new HashSet<Album>();
        }
    }
}