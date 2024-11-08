using Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    public class HomeController : Controller
    {
        //action methods
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            //products.Add(new Product { Id = 1, Name = "gerberra", Description = "Wedding Flower", UnitPrice = 50, Quantity = 150, Image="/Images/gerberra.jpg" });
            //products.Add(new Product { Id = 2, Name = "Lotus", Description = "Workship Flower", UnitPrice = 40, Quantity = 150, Image = "/Images/gerberra.jpg" });
            //products.Add(new Product { Id = 3, Name = "Rose", Description = "Valentine Flower", UnitPrice = 65, Quantity = 200, Image = "/Images/gerberra.jpg" });

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}