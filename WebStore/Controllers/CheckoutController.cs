using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            CheckoutModel model = new CheckoutModel();
            // TODO: check this order id = cust's order id
            string orderId = Request.Cookies["OrderId"].Value;



            using(WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                //gets shipping method
                model.ShippingList = e.Shippings.Select(x => x.Method).ToList();
            }
            return View(model);
        }

        // POST: Checkout
        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            if(ModelState.IsValid)
            {
                // TODO: see if checkout works... 
                using (WebStoreDatabaseEntities entities = new WebStoreDatabaseEntities())
                {
                    int orderNumber = int.Parse(Request.Cookies["OrderId"].Value);
                    var orderHeader = entities.OrderHeaders.Single(x => x.OrderId == orderNumber);
                    //looks at shipping table, gets method that equals model.method, then finds the ID for that method.
                    var shipMethod = entities.Shippings.Single(x => x.Method == model.ShippingMethod).ShippingMethodId;
                    
                    var address = entities.Addresses.FirstOrDefault(
                        x => x.Line1 == model.ShippingAddress1
                        && x.Line2 == model.ShippingAddress2
                        && x.City == model.ShippingCity
                        && x.State == model.ShippingState
                        && x.Zipcode == model.ShippingZipcode);
                    
                    if (address == null)
                    {
                        address = new Address
                        {
                            AddressId = entities.Addresses.Max(x => x.AddressId) + 1,
                            Line1 = model.ShippingAddress1,
                            Line2 = model.ShippingAddress2,
                            City = model.ShippingCity,
                            State = model.ShippingState,
                            Zipcode = model.ShippingZipcode,
                        };
                        entities.Addresses.Add(address);
                    }
                    orderHeader.ShipToAddress = address.AddressId;
                    entities.SaveChanges();
                }
                return RedirectToAction("Index", "Receipt");
            }
            else
            {
                return View(model);
            }
        }
    }
}