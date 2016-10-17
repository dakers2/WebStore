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
            //this replaces the sql connections we were using before
            using(WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                //products are a db type. change them to a ProductModel using lambda expressions.
                //e.Products.Select(x => new ProductModel { Category => x.ProductName });
            }

       

            //take this out eventually. product data will be pulled from database.
            List<ProductModel> model = new List<ProductModel>();

            model.Add(new ProductModel {
                ID = 1, Category = "cookies",
                Featured = true,
                Name = "Chocolate Chip Cookies",
                Price = 12.50m,
                Description = "Made with delicious milk chocolate chips and lots of love. Just like grandma used to make!",
                Image = "/Images/choc-chip.jpg"
            });

            model.Add(new ProductModel {
                ID = 2,
                Category = "cookies",
                Featured = true,
                Name = "Gingersnap",
                Price = 10.50m,
                Description = "Indugle your inner squirrel and stuff your cheeks with these yummy cookies.",
                Image = "/Images/cookies-gingersnap.jpg"
            });

            model.Add(new ProductModel {
                ID = 3,
                Category = "cookies",
                Featured = true,
                Name = "Sugar Cookies",
                Price = 11.00m,
                Description = "Sparkling Sugar's famous sugar cookie coated with sparkling sugar. Once you've tried them, you're sure to come back for more.",
                Image = "/Images/cookies-animals.jpg"
            });

            

            return View(model);
        }

        //POST: Product
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            //TODO: new entity (using), create line item, create the header, add new line item to header, save cart as cookie so we can use this order on the checkout page
            //save to database
            //clear the cookie after order is placed
            
            return View(model);
        }
    }
}