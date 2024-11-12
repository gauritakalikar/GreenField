﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
using Specification;
using BinaryDataRepositoryLib;
using System.Security;
using System.Net.Http;
namespace Services
{

    public class ProductService : IProductService
    {
        public bool Seeding()
        {
            bool status = false;
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, Image = "/Images/gerberra.jpg" });
            products.Add(new Product { Id = 2, Name = "rose", Description = "Valentine Flower", UnitPrice = 23, Quantity = 9000, Image = "/Images/rose.jpg" });
            products.Add(new Product { Id = 3, Name = "lily", Description = "Delicate Flower", UnitPrice = 2, Quantity = 7000, Image = "/Images/lily.jpg" });
            products.Add(new Product { Id = 4, Name = "jasmine", Description = "Fregrance Flower", UnitPrice = 12, Quantity = 55000, Image = "/Images/jasmines.jpg" });
            products.Add(new Product { Id = 5, Name = "lotus", Description = "Worship Flower", UnitPrice = 45, Quantity = 15000, Image = "/Images/lotus.jpg" });
            IDataRepository<Product> repo = new BinaryRepository<Product>();
            status = repo.Serialize("products.dat", products);
            return status;
        }
        public bool Delete(int id)
        {
            Product theProduct = Get(id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theProduct);
                IDataRepository<Product> repo = new BinaryRepository<Product>();
                repo.Serialize("products.dat", allProducts);
            }
            return false;
        }

        public Product Get(int id)
        {
            Product foundProduct = null;
            List<Product> products = GetAll();
            foreach (Product p in products)
            {
                if (p.Id == id)
                {
                    foundProduct = p;

                }
            }
            return foundProduct;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            IDataRepository<Product> repository = new BinaryRepository<Product>();
            products = repository.Deserialize("products.dat");
            return products;
        }

        public bool Insert(Product product)
        {
            List<Product> allProducts = GetAll();
            allProducts.Add(product);
            IDataRepository<Product> repo = new BinaryRepository<Product>();
            repo.Serialize("products.dat", allProducts);

            return false;
        }

        public bool Update(Product productTobeUpdated)
        {
            Product theProduct = Get(productTobeUpdated.Id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theProduct);
                allProducts.Add(productTobeUpdated);
                IDataRepository<Product> repo = new BinaryRepository<Product>();
                repo.Serialize("products.dat", allProducts);
            }
            return false;
        }
    }
}