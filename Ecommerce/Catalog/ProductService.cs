using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        public ProductService() { 
            this.products = new List<Product>();
        }
        public bool Delete(Product product)
        {
            products.Remove(product);
            return true;
        }

        public Product GetProductById(int id)
        {
            List<Product> products = this.products;
            foreach (Product p in products)
            {
                if (p.Id == id) { return p; }

            }
            return null;
        }

        public Product GetProductByName(string title)
        {
            List<Product> products = this.products;
            foreach (Product p in products)
            {
                if (p.Title == title) { return p; }

            }
            return null;

        }

        public List<Product> GetProducts()
        {
            return this.products;
        }

        public bool Insert(Product product)
        {
            products.Add(product);
            return true;
        }

        public bool Update(Product product)
        {
            Product product1 = this.GetProductById(product.Id);
            products.Remove(product1);
            products.Add(product);
            return true;

        }
    }
}
