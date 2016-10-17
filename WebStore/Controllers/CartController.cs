using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            // TODO: add the index method here for what happens when the user gets to this page
            //get cookie and display cart data in model
            return View();
        }

        // POST: Cart
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            // TODO: what happens when they click checkout? - Be sure to update changes to cart in database!
            return RedirectToAction("Index", "Checkout");
        }
    }
}