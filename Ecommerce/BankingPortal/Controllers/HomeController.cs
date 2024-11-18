using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankingPortal.Models;
namespace BankingPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string company = "Simplify Healthcare";
            ViewBag.Company = company;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Contact cnt = new Contact
            {
                Name = "Gauri",
                Email="gau@gmail.com",
                Website="google.com"

            };
            ViewData["contact"] = cnt;
            return View();
        }
    }
}