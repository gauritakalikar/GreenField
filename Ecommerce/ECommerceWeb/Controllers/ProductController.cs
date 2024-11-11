using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalog;
using POCO;
namespace ECommerceWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //List<Product> products = new List<Product>();
            //products.Add(new Product { Id = 1, Title = "gerberra", Description = "Wedding Flower", unitPrice = 50, Quantity = 150, ImgURL="/Images/gerberra.jpg" });
            //products.Add(new Product { Id = 2, Title = "Lotus", Description = "Workship Flower", unitPrice = 40, Quantity = 150, ImgURL = "/Images/gerberra.jpg" });
            //products.Add(new Product { Id = 3, Title = "Rose", Description = "Valentine Flower", unitPrice = 65, Quantity = 200, ImgURL = "/Images/gerberra.jpg" });

            //return View(products);
            IProductService svc = new ProductService();
            List<Product> products = svc.GetAll();
            return View(products);
        }
        public ActionResult Details() {
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        public ActionResult Update() {
            return View();
        }
    }
}