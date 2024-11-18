using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;
namespace HRPortal.Services
{
    public interface IEmployeeService
    {
         bool Update(Employee EmployeeTobeUpdated);
         bool Insert(Employee Employee);
         List<Employee> GetAll();
        Employee Get(int id);
        bool Delete(int id);

    }
}
