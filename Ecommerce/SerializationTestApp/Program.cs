using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
using Specification;
using Services;
namespace SerializationTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService svc
                = new ProductService();
            svc.seeding();
            List<Product> products = svc.GetProducts();
            foreach (Product product in products)
            {
                Console.WriteLine(product.Id+" "+product.Quantity);
            }
        }
    }
}
