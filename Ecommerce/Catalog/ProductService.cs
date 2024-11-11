using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
namespace Catalog
{
    public class ProductService : IProductService
    {
        public bool Delete(int id)
        {
            return false;
        }

        public Product Get(int id)
        {
            return new Product { Id = 1, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, Image = "/Images/gerberra.jpg" };
        }

        public List<Product> GetAll()
        {

            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, Image = "/Images/gerberra.jpg" });
            products.Add(new Product { Id = 2, Name = "rose", Description = "Valentine Flower", UnitPrice = 23, Quantity = 9000, Image = "/images/gerberra.jpg" });
            products.Add(new Product { Id = 3, Name = "lily", Description = "Delicate Flower", UnitPrice = 2, Quantity = 7000, Image = "/images/gerberra.jpg" });
            products.Add(new Product { Id = 4, Name = "jasmine", Description = "Fregrance Flower", UnitPrice = 12, Quantity = 55000, Image = "/images/gerberra.jpg" });
            products.Add(new Product { Id = 5, Name = "lotus", Description = "Worship Flower", UnitPrice = 45, Quantity = 15000, Image = "/images/gerberra.jpg" });

            return products;

        }

        public bool Insert(Product product)
        {
            return false;
        }

        public bool Update(Product product)
        {
            return false;
        }
    }
}
