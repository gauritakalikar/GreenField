using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> customerList;
        public CustomerService() { 
            this.customerList = new List<Customer>();
        }
        public bool Delete(int id)
        {
            Customer thiscustomer = this.Get(id);
            return customerList.Remove(thiscustomer);

        }

        public Customer Get(int id)
        {
            foreach (Customer customer in customerList) { 
                if (customer.Id == id) return customer;
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return customerList;
        }

        public bool Insert(Customer customer)
        {
            this.customerList.Add(customer);
            return true;
        }

        public bool Update(Customer customer)
        {
            Customer thecustomer = this.Get(customer.Id);
            this.customerList.Remove(thecustomer);
            this.customerList.Add(customer);
            return true;
        }
    }
}
