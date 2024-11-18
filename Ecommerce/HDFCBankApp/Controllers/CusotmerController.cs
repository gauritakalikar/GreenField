using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;
namespace HDFCBankApp.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> list;
        public CustomersController()
        {
            list = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Samrudhee", LastName = "Deshmukh", Email = "sam@gmail.com", ContactNumber = "9867485768", Location = "Pune" },
                new Customer { Id = 2, FirstName = "Gauri", LastName = "Takalikar", Email = "gau@gmail.com", ContactNumber = "90857464873", Location = "Pune" },
                new Customer { Id = 3, FirstName = "Aditya", LastName = "jamdade", Email = "aditya@gmail.com", ContactNumber = "87837673645", Location = "Pune" }
            };
        }
        // GET: Customers
        public ActionResult Index()
        {
            ViewData["list"] = list;
            return View();
        }

        // GET: Customer/Details/{id}
        public ActionResult Details(int id)
        {
            var customer = list.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewData["customer"] = customer;
            return View(customer);
        }
    }
}