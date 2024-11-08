using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    //Prototype, Contract, Specification..
    public interface ICustomerService
    {
        List<Customer> GetAll(); //abstract method
        Customer Get(int id);
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(int id);
    }
}
