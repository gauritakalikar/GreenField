using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking;
using Taxation;
using Penalty;
using Delegation;
namespace CSharpFeatureApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Handler.PayGST();
            //Handler.PayIncomeTax();
            //Handler.PayServiceTax();

            //register method with delegate instance
            Operation op1=new Operation(TaxHandler.PayServiceTax);
            Operation op2 = new Operation(TaxHandler.PayIncomeTax);
            Operation op3 = new Operation(TaxHandler.PayGST);

            Operation masterOperation = null;
            masterOperation += op1;
            masterOperation += op2;
            masterOperation += op3;

            //op1.Invoke(30);
            //op2.Invoke(30);
            //op3.Invoke(30);

            masterOperation.Invoke(56);

            Console.WriteLine("After dec");
            masterOperation -= op1;

            masterOperation.Invoke(56);
            */
            Account acct=new Account(15000);
            acct.underBalance += PenaltyHandler.ServiceDisconnectionPenaltyCharges;
            acct.underBalance += PenaltyHandler.NotificationPenaltyCharges;
            acct.Withdraw(8000);
            acct.overBalance += TaxHandler.PayServiceTax;
            acct.overBalance += TaxHandler.PayProfessionalTax;
            acct.overBalance += TaxHandler.PayIncomeTax;
            acct.overBalance += TaxHandler.PayGST;

            acct.Deposit(5000000);
            Console.ReadLine();
        }
    }
}
