using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleApplication1
{
    public class SongController : ApiController
    {
        private List<Song> songlist = new List<Song>()
        {
            new Song{ Title = "Hey Jude", Artist = "The Beatles", Price = 1.9 },
            new Song{Title = "I Gotta Feeling", Artist = "The Black Eyed Peas", Price = 1.5},
            new Song{Title = "The Twist", Artist = "Chubby Checker", Price = 2}
        };

        public SongController()
        {
            this.songlist = new List<Song>();

        }

        public IEnumerable<Song> Get()
        {
            return songlist;
        }

        public Song Get(int id)
        {
            return songlist[id];
        }

        public void Post([FromBody] Song value)
        {
            songlist.Add(value);
        }

        public void Put(int id, [FromBody] Song value)
        {
            songlist[id] = value;
        }

        public void Delete(int id)
        {
            songlist.RemoveAt(id);
        }
    }
}
