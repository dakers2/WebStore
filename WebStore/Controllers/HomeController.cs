using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductModel[] model = { };
            using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                model = e.Products.Where(x => x.Featured == 1).Select(x => new ProductModel
                {
                    ID = x.ProductId,
                    Name = x.ProductName,
                    Image = x.Image,
                    Price = x.Price
                }).ToArray();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}