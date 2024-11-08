using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }// Auto Property
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String ContactNo { get; set; }
    }
}