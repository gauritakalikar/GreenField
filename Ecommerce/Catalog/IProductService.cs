using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        Product GetProductByName(string name);

        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        
    }
}
