using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;
using HRPortal.Services;
namespace HRPortal.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            EmployeeService svc = new EmployeeService();
            return View(svc.GetAll());
        }
        public ActionResult Details(int id)
        {
            EmployeeService svc = new EmployeeService();
            Employee emp= svc.Get(id);
            return View(emp);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection )
        {
            string FirstName= collection["firstname"] as string;
            string LastName = collection["Lastname"] as string;
            string Email = collection["email"] as string;
            return View();
        }
        public ActionResult Insert() { return View(); }
        [HttpPost]
        public ActionResult Insert(Employee emp) 
        {
            EmployeeService svc = new EmployeeService();
            svc.Insert( emp );
            return View(); 
        }
        public ActionResult Edit() 
            { 
            Employee employee = new Employee();
            employee.Id = 1;
            employee.Name = "Gauri";
            employee.IsConfirmed = true;
            employee.JoinDate = DateTime.Now;
            employee.WorkingDays = 10;
            employee.BasicSalary = 100;
            employee.DailyAllowance = 300;
            employee.Description = "Worker";
            return View(employee); 
        }
        [HttpPost]
        public ActionResult Edit(Employee emp) 
        {
            EmployeeService svc = new EmployeeService();
            svc.Update(emp);
            return View(); 
        }
        public ActionResult Delete(Employee emp) 
        {
            EmployeeService svc = new EmployeeService();
            svc.Delete(emp.Id);
            return View(emp); 
        }
    }
}