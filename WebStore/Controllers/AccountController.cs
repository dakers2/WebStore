using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                    //connects model to db
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
                    string token = WebMatrix.WebData.WebSecurity.CreateUserAndAccount(model.Email, model.Password,
                        new
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            Password = model.Password,
                            Line1 = model.BillingAddress1,
                            Line2 = model.BillingAddress2,
                            City = model.City,
                            State = model.State,
                            Zipcode = model.Zipcode
                        },
                        true);

                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
                    SendGrid.SendGridAPIClient client = new SendGrid.SendGridAPIClient(apiKey);

                    Email from = new Email("admin@webstore.com");
                    string subject = "Complete your WebStore registration!";
                    Email to = new Email(model.Email);

                    string emailContent = string.Format("<html><body><a href=\"{0}\">Complete your registration</a></body></html>", Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/RegisterConfirm/" + HttpUtility.UrlEncode(token) + "?email=" + HttpUtility.UrlEncode(model.Email));
                    Content content = new Content("text/HTML", emailContent);
                    Mail mail = new Mail(from, subject, to, content);

                    client.client.mail.send.post(requestBody: mail.Get());

                    return RedirectToAction("RegisterComplete");
                }
            }
                return View(model);
        }

        // GET: RegisterComplete
        [AllowAnonymous]
        public ActionResult RegisterComplete()
        {
            return View();
        }
        
        // GET: RegisterConfirm
        [AllowAnonymous]
        public ActionResult RegisterConfirm(string id, string email)
        {
            if (WebMatrix.WebData.WebSecurity.ConfirmAccount(email, id))
                ViewBag.Confirmed = true;
            return View();   
        }

        // GET: PasswordForgot
        public ActionResult ForgotPassword()
        {
            RegistrationModel model = new RegistrationModel();
            string token = WebMatrix.WebData.WebSecurity.GeneratePasswordResetToken(model.Email);

            string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
            SendGrid.SendGridAPIClient client = new SendGrid.SendGridAPIClient(apiKey);

            Email from = new Email("admin@webstore.com");
            string subject = "WebStore Password Reset";
            Email to = new Email(model.Email);

            string emailContent = string.Format("<html><body><a href=\"{0}\">Reset my password</a></body></html>", 
                Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/PasswordReset" 
                + HttpUtility.UrlEncode(token) + "?email=" + HttpUtility.UrlEncode(model.Email));
            Content content = new Content("text/HTML", emailContent);
            Mail mail = new Mail(from, subject, to, content);

            client.client.mail.send.post(requestBody: mail.Get());

            return RedirectToAction("PasswordReset");
        }

        // GET: PasswordReset
        [AllowAnonymous]
        public ActionResult PasswordReset(string password, string token)
        {
            // TODO: password reset - This is probably broken.
            WebMatrix.WebData.WebSecurity.ResetPassword(token, password);
            return View();
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
                if (WebMatrix.WebData.WebSecurity.Login(model.Email, model.Password, true))
                {
                    // TODO: give user auth cookie so it can be used on cart page
                    //pulls their data from the DB based on their customerId
                }
                // TODO: Be sure error shows up if username/pass is incorrect
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}