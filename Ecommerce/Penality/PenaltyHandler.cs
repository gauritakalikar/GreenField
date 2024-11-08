using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty
{
    public class PenaltyHandler
    {
        public static void ServiceDisconnectionPenaltyCharges(float amount)
        {
            Console.WriteLine("Disconnection Charges applied: " + amount);
        }
        public static void NotificationPenaltyCharges(float amount)
        {

            Console.WriteLine("Notification Charges applied: " + amount);
        }
    }
}
