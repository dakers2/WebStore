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
            CartModel model = new CartModel();
            
            if (User.Identity.IsAuthenticated)
            {
                int orderId = int.Parse(Request.Cookies["OrderId"].Value);
                using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
                {
                    var cart = e.OrderHeaders.Single(x => x.OrderId == orderId);
                    model.Products = cart.OrderDetails.Select(x => new ProductModel
                    {
                        Name = x.Product.ProductName,
                        Price = x.Product.Price,
                        Quantity = x.OrderOty,
                        ID = x.ProductId,
                        LineTotal = (x.Product.Price * x.OrderOty)
                    }).ToArray();

                    model.Subtotal = model.Products.Sum(x => x.LineTotal);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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

                // TODO: finish creating line item, etc...
                //model.ID = e.OrderDetails.

                e.SaveChanges();
            }
            return RedirectToAction("Index", "Checkout");
        }
    }
}