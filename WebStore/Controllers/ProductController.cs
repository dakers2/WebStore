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
            ProductModel model = new ProductModel();
            using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                var product = e.Products.Single(x => x.ProductId == id);

                if(id != null)
                {
                    model.Name = product.ProductName;
                    model.Name = product.Image;
                    model.Description = product.Description;
                    model.Price = product.Price??0; //if null, price is 0
                }
                else
                {
                    new HttpNotFoundResult("Product Not Found");
                }
            }

            return View(model);
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