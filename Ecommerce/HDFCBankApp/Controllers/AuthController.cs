using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;
using HDFCBankApp.Services;
namespace HDFCBankApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth/Login
        public ActionResult Login()
        {

            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            AuthService svc = new AuthService();

            if (svc.Login(email, password))
            {
                this.HttpContext.Session["loggedinuser"] = email;
                return RedirectToAction("welcome");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User u)
        {
            AuthService svc = new AuthService();

            if (svc.Register(u))
            {
                this.HttpContext.Session["loggedinuser"] = u.Email;
                return RedirectToAction("welcome");
            }
            return View();

        }

        public ActionResult Welcome()
        {
            ViewBag.Email = this.HttpContext.Session["loggedinuser"] as string;
            return View();
        }
    }

}