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
                    model.Image = product.Image;
                    model.Description = product.Description;
                    model.Price = product.Price;
                    model.Quantity = 1;
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
                detail.ProductId = model.ID;
                
                OrderHeader header = new OrderHeader();
                header.OrderDate = DateTime.UtcNow;
                
                //(ternary expression) Are there order headers? if yes, then do the thing, else = 1.
                header.OrderId = e.OrderHeaders.Any() ? e.OrderHeaders.Max(x => x.OrderId) + 1 : 1;
                detail.OrderId = header.OrderId;
                
                //Adds detail to order details
                header.OrderDetails.Add(detail);

                //TODO: Make sure people are registered and use THEIR customer ID.
                header.CustomerId = e.Customers.First().CustomerId;

                header.SubTotal = model.Price * model.Quantity;
                detail.LineTotal = header.SubTotal;
                e.OrderHeaders.Add(header);
                e.SaveChanges();           
            }
            return RedirectToAction("Index", "Cart"); // TODO: cart page everything
        }

    }
}