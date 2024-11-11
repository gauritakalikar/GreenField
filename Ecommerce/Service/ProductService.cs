using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
using Specification;
using BinaryDataRepositoryLib;
namespace Services
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
            Product foundproduct = null;
            List<Product> products = GetProducts();
            foreach (Product p in products)
            {
                if (p.Title == title) { foundproduct= p; }

            }
            return foundproduct;

        }

        public List<Product> GetProducts()
        {
            List<Product> productsList = new List<Product>();
            IDataRepository repository = new BinaryRepository();
            products = repository.Deserialize("products.dat");
            return products;
        }

        public bool Insert(Product product)
        {
            products.Add(product);
            return true;
        }

        public bool Update(Product product)
        {

            Product product1 = this.GetProductById(product.Id);
            if(product1 != null)
            {
                List<Product> allProducts = GetProducts();

            }
            return true;

        }
    }
}
