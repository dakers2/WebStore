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
            ProductModel model = new ProductModel();

            // TODO: add the index method here for what happens when the user gets to this page
            //get cookie and display cart data in model


            return View(model);
        }

        // POST: Cart
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            //TODO: new entity (using), create line item, create the header, add new line item to header, 
            using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                

                //save cart as cookie so we can use this order on the checkout page
                Response.Cookies.Add(new HttpCookie("orderId", 1.ToString()) { Expires = DateTime.Now.AddMinutes(15) });

                //save to database
                e.SaveChanges();

                //clear the cookie after order is placed
            }


            return RedirectToAction("Index", "Checkout");
        }
    }
}