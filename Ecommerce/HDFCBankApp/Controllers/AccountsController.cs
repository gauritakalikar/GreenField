using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace HDFCBankApp.Controllers
{
    public class AccountsController : Controller
    {

        // GET: Accounts
        public ActionResult Index()
        {
            string theMessage = "I am the manager, and i am responsible for account transation";
            TempData["mymessage"] = theMessage;

            return RedirectToAction("About", "Home");

            //return View();
        }
        public ActionResult Process()
        {
            string theMessage = TempData["mymessage"] as string;
            ViewData["processmessage"] = theMessage;
            return View();
        }
        public ActionResult Details()
        {
            string Email = this.HttpContext.Session["loggedinuser"] as string;
            ViewBag.userEmail = Email;
            return View();
        }
    }
}