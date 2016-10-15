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
                //TODO: check to see if address is already in database. if not, add it to the db.
                //example from Joe: var address = entities.Address.FirstOrDefault(x => x.AddressLine1 == model.ShippingAddress1 && x.AddresLine2 == model.ShippingAddress2....etc...)
                //if (address == null) 
                //{
                //    address = new address
                //    {
                //        addressId = entities.Address.Max(x => x.AddressId) + 1,
                //        addressLine1 = model.ShippingAddress1,
                //        ...etc...
                //    };
                //    entities.Address.Add(Address);
                //}

                return RedirectToAction("Index", "Receipt");
            }
            else
            {
                return View(model);
            }
        }
    }
}