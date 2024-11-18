using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models;
using HRPortal.Repositories;
namespace HRPortal.Services
{
    public class EmployeeService : IEmployeeService

    {
        string JSONFile = @"D:/HRemployees.json";

        public bool Seeding()
        {
            bool status = false;
            List<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee { Id = 1, Name = "Gauri", Description="Boss",BasicSalary=40,DailyAllowance=10,WorkingDays=1,JoinDate=DateTime.Now,IsConfirmed=true });
            Employees.Add(new Employee { Id = 2, Name = "Rani", Description = "WOrker", BasicSalary = 30, DailyAllowance = 5, WorkingDays = 1, JoinDate = DateTime.Now, IsConfirmed = true });
            Employees.Add(new Employee {Id = 3, Name = "Sonal", Description = "Servant", BasicSalary = 400, DailyAllowance = 150, WorkingDays = 4, JoinDate = DateTime.Now, IsConfirmed = true });
            Employees.Add(new Employee {Id = 4, Name = "Aditya", Description = "Servant", BasicSalary = 90, DailyAllowance = 1, WorkingDays = 6, JoinDate = DateTime.Now, IsConfirmed = true });
            Employees.Add(new Employee {Id = 5, Name = "Yash", Description = "Secretary", BasicSalary = 100, DailyAllowance = 10, WorkingDays = 10, JoinDate = DateTime.Now, IsConfirmed = true });

            // IDataRepository<Employee> repo = new BinaryRepository<Employee>();
            IDataRepository<Employee> repo = new JsonRepository<Employee>();
            status = repo.Serialize(JSONFile, Employees);
            return status;
        }
        public bool Delete(int id)
        {
            Employee theEmployee = Get(id);
            if (theEmployee != null)
            {
                List<Employee> allEmployees = GetAll();
                allEmployees.RemoveAll(p => p.Id == id);
                IDataRepository<Employee> repo = new JsonRepository<Employee>();
                repo.Serialize(JSONFile, allEmployees);
            }
            return false;
        }

        public Employee Get(int id)
        {
            Employee foundEmployee = null;
            List<Employee> Employees = GetAll();
            foreach (Employee p in Employees)
            {
                if (p.Id == id)
                {
                    foundEmployee = p;

                }
            }
            return foundEmployee;
        }

        public List<Employee> GetAll()
        {
            List<Employee> Employees = new List<Employee>();
            IDataRepository<Employee> repository = new JsonRepository<Employee>();
            Employees = repository.Deserialize(JSONFile);
            return Employees;
        }

        public bool Insert(Employee Employee)
        {
            List<Employee> allEmployees = GetAll();
            allEmployees.Add(Employee);
            IDataRepository<Employee> repo = new JsonRepository<Employee>();
            repo.Serialize(JSONFile, allEmployees);

            return false;
        }

        public bool Update(Employee EmployeeTobeUpdated)
        {
            Employee theEmployee = Get(EmployeeTobeUpdated.Id);
            if (theEmployee != null)
            {
                List<Employee> allEmployees = GetAll();
                allEmployees.Remove(theEmployee);
                allEmployees.Add(EmployeeTobeUpdated);
                IDataRepository<Employee> repo = new JsonRepository<Employee>();
                repo.Serialize(JSONFile, allEmployees);
            }
            return false;
        }

    }
}