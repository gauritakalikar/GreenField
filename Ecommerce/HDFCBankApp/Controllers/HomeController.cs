using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;
namespace HDFCBankApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = TempData["mymessage"];

            return View();
        }

        public ActionResult Contact()
        {
            Contact c = new Contact { ContactNumber = "90473745837", Email = "sh@gmail.com", Website = "simplifyhealthcare.com" };
            ViewData["contact"] = c;
            ViewBag.Message = "Your contact page.";



            return View();
        }
    }
}