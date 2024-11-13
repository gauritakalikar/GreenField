using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM;
using OrderProcessing;
using Catalog;
using EcommerceEntities;
namespace ECommerceTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Customer customer1 = new Customer();
            customer1.Id = 1;
            customer1.FName = "Gauri";
            customer1.LName = "Takalikar";
            customer1.Email = "takalikargauri@gmail.com";
            customer1.Phone = "9021213962";

            Customer customer2 = new Customer();
            customer2.Id = 2;
            customer2.FName = "Sonal";
            customer2.LName = "Dangle";
            customer2.Email = "Sonaldangle@gmail.com";
            customer2.Phone = "9881265756";

            ICustomerService customerService = new CustomerService();
            customerService.Insert(customer1);
            customerService.Insert(customer2);

            List<Customer> AllCustomers = customerService.GetAll();
            foreach (Customer customer in AllCustomers)
            {
                Console.WriteLine(customer.Id);
                Console.WriteLine(customer.FName);
                Console.WriteLine(customer.LName);
                Console.WriteLine(customer.Email);
                Console.WriteLine(customer.Phone);
            }
            */
            /*Order order1 = new Order();
            Order order2 = new Order();
            order1.Id = 1;
            order2.Id = 2;
            order1.Created = DateTime.Now;
            order2.Created = DateTime.Now;
            order1.Status = "Delivered";
            order2.Status = "Cancelled";
            order1.Amount = 60;
            order2.Amount = 50;

            IOrderService orderService = new OrderService();
            orderService.Insert(order1);
            orderService.Insert(order2);

            List<Order> AllOrders = orderService.GetOrders();
            foreach (Order order in AllOrders)
            {
                Console.WriteLine(order.Id);
                Console.WriteLine(order.Created);
                Console.WriteLine(order.Status);
                Console.WriteLine(order.Amount);
                
            }
            */
            Product product1 = new Product();
            Product product2 = new Product();
            product1.Id = 1;
            product2.Id = 2;
            product1.Description = "product description one";
            product2.Description = "product description two";
            product1.Quantity = 1500;
            product2.Quantity = 500;

            IProductService productService = new ProductService();
            productService.Insert(product1);
            productService.Insert(product2);

            List<Product> AllProducts = productService.GetAll();
            foreach (Product product in AllProducts)
            {
                Console.WriteLine(product.Id);
                Console.WriteLine(product.Description);
            }
            Console.ReadLine();
        }
    }
}
