using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public String Status { get; set; }
        public DateTime Created { get; set; }
    }
}
