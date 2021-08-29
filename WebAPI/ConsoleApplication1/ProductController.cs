using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleApplication1
{
    public class ProductController : ApiController
    {
        private Product_APIEntities db = new Product_APIEntities();
        public List<Product> products = new List<Product>();
        
        
        public IEnumerable<Product> Get()
        {
            using (Product_APIEntities dbContext = new Product_APIEntities())
            {
                return dbContext.Products.ToList();
            }
            //products = db.Products.ToList();
            //return db.Products.ToList();
        }

        public int get(int id)
        {
            return (int)db.ProBuys.Where(p => p.ProBuyId == id).Sum(p => p.ProNumber);
        }
        //public float Get(int id)
        //{
        //    return (int)db.ProBuys.Where(p => p.ProId == id).Sum(p => p.ProNumber * p.ProBuyPrice);
        //}


    }
}
