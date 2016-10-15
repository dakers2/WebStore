using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Log]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            if(id == 1)
            {
                return View(new ProductModel {ID = 1 , Name = "Chocolate Chip Cookies", Price = 12.50m, Description = "Made with delicious milk chocolate chips and lots of love. Just like grandma used to make!", Image = "http://placehold.it/350x350"}); //using m turns price into currency
            }
            if(id == 2)
            {
                return View(new ProductModel { ID = 2, Name = "Peanut Butter Cookies", Price = 10.50m, Description = "Endugle your inner squirrel and stuff your cheeks with these yummy Peanut Butter Cookies." });
            }

            return new HttpNotFoundResult("Product Not Found");

        }

        // POST: Product
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            // TODO: Add product to cart in database.
            using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                //create line item
                OrderDetail detail = new OrderDetail();
                detail.OrderOty = model.Quantity;

                OrderHeader header = new OrderHeader();
                header.OrderDate = DateTime.UtcNow;
                header.OrderId = e.OrderHeaders.Max(x => x.OrderId) + 1;

                //Adds new order detail to order header
                header.OrderDetails.Add(detail);

                //TODO: Make sure people are registered and use THEIR customer ID.
                header.CustomerId = e.Customers.First().CustomerId;

                //get subtotal
                header.SubTotal = model.Price * model.Quantity;

                //Adds data to order header table
                e.OrderHeaders.Add(header);

                //Saves changes to the database now.
                e.SaveChanges();
            }



            return RedirectToAction("Index", "Cart"); //determines what happens after you add it to cart
        }

    }
}