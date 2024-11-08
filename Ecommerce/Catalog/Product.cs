using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int unitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
    }
}
