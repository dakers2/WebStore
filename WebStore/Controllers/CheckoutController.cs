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
            return View();
        }

        // POST: Checkout
        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            if(ModelState.IsValid)
            {
                //TODO: see if checkout works... & add ship method
                using (WebStoreDatabaseEntities entities = new WebStoreDatabaseEntities())
                {
                    int orderNumber = int.Parse(Request.Cookies["OrderNumber"].Value);
                    var orderHeader = entities.OrderHeaders.Single(x => x.OrderId == orderNumber);
                    //var shipMethod = entities.OrderHeaders.Single(x => x.ShipMethod);
                    var address = entities.Addresses.FirstOrDefault(
                        x => x.Line1 == model.ShippingAddress1 
                        && x.Line2 == model.ShippingAddress2 
                        && x.City == model.ShippingCity 
                        && x.State == model.ShippingState 
                        && x.Zipcode == model.ShippingZipcode);

                    // TODO: Fix null address adder thing
                    //if (address == null)
                    //{
                    //    address = new address
                    //    {
                    //        addressId = entities.Addresses.Max(x => x.AddressId) + 1,
                    //        Line1 = model.ShippingAddress1,
                    //        Line2 = model.ShippingAddress2,
                    //        City = model.ShippingCity,
                    //        State = model.ShippingState,
                    //        Zipcode = model.ShippingZipcode
                    //    };
                    //    entities.Addresses.Add(address);
                    //}
                    //orderHeader.ShipToAddress = address.AddressId;

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