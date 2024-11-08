using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxation
{
    public class TaxHandler
    {
        public static void PayIncomeTax(float factor)
        {
            Console.WriteLine("Income Tax " + factor + " is deducted from your account.");
        }
        public static void PayServiceTax(float factor) { Console.WriteLine("Service Tax " + factor + " is deducted from your account."); }
        public static void PayGST(float factor)
        {
            Console.WriteLine("GST " + factor + " is deducted from your account.");
        }
        public static void PayProfessionalTax(float factor)
        {
            Console.WriteLine("Prof Tax " + factor + " is deducted from your account.");
        }
    }
}
