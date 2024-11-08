using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM;
namespace ECommerceWeb.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, FirstName = "Rutuja", LastName = "Patil", Email = "rsyadav@gmail.com", ContactNo = "8778964521" });
            customers.Add(new Customer { Id = 1, FirstName = "Sam", LastName = "Deshmukh", Email = "patil@gmail.com", ContactNo = "1234567890" });
            customers.Add(new Customer { Id = 1, FirstName = "Gauri", LastName = "Takilkar", Email = "sam@gmail.com", ContactNo = "9876543210" });
            customers.Add(new Customer { Id = 1, FirstName = "Jasmin", LastName = "Wedding Flower", Email = "tyafey@gmail.com", ContactNo = "4512789632" });
            customers.Add(new Customer { Id = 1, FirstName = "Lotus", LastName = "Wedding Flower", Email = "ftqyet@gmai.com", ContactNo = "7418529632" });

            return View(customers);
        }
    }
}