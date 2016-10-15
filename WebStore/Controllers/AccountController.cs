using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Details
        //page allows logged in user to edit their info
        [Authorize]
        public ActionResult Index()
        {
            AccountDetailsModel model = new AccountDetailsModel();
            using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
            {
                var user = e.Customers.Single(x => x.Email == User.Identity.Name);
                //connect db with model
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
            }
            return View(model);
        }

        // POST: Account/Details
        [HttpPost]
        public ActionResult Index(AccountDetailsModel model)
        {
            if(ModelState.IsValid)
            {
                using (WebStoreDatabaseEntities e = new WebStoreDatabaseEntities())
                {
                    var user = e.Customers.Single(x => x.Email == User.Identity.Name);
                    //connect model to db
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                }
            }
            return View(model);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            RegistrationModel model = new RegistrationModel();
            return View(model);
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            if(ModelState.IsValid)
            {
                if (WebMatrix.WebData.WebSecurity.UserExists(model.Email))
                {
                    ModelState.AddModelError("Email", "Account for this email address already exists.");
                }
                else
                {
                    // TODO: Set up email confirmation tokens
                    WebMatrix.WebData.WebSecurity.CreateUserAndAccount(model.Email, model.Password, null, false);
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(LoginModel model) 
        {
            if (ModelState.IsValid)
            {
                if (WebMatrix.WebData.WebSecurity.UserExists(model.Email))
                {
                    WebMatrix.WebData.WebSecurity.Login(model.Email, model.Password, false);
                }
                else
                {
                    ModelState.AddModelError("Login", "Incorrect username or password.");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
            
        }
    }
}