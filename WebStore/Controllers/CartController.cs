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
            //TODO: new entity (using), create line item, create the header, add new line item to header, 
            using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                //int orderNumber = e.OrderHeader.Single(x => x.)
            }

            //save cart as cookie so we can use this order on the checkout page


            //save to database
            //clear the cookie after order is placed
            return RedirectToAction("Index", "Checkout");
        }
    }
}