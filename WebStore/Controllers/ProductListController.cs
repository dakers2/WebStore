using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class ProductListController : Controller
    {
        // GET: ProductList
        public ActionResult Index()
        {
            List<ProductModel> model = null;
            using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                //products are a db type. change them to a ProductModel using lambda expressions.
                model = e.Products.Select(x => new ProductModel
                {
                     ID = x.ProductId,
                     Name = x.ProductName,
                     Description = x.Description,
                     Image = x.Image,
                     Price = x.Price ?? 0
                }).ToList();
            }
            return View(model);
        }

        //POST: Product
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            // TODO: what happens when you click on a product
            
            return View(model);
        }
    }
}