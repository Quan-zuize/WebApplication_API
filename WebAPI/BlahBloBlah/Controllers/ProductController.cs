using BlahBloBlah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlahBloBlah.Controllers
{
    public class ProductController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            using (Product_APIEntities dbContext = new Product_APIEntities())
            {
                return dbContext.Products.ToList();
            }

        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            using (Product_APIEntities dbContext = new Product_APIEntities())
            {
                return dbContext.Products.FirstOrDefault(e => e.productId == id);
            }

        }
    }
}
