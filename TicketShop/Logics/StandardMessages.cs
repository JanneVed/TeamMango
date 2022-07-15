using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Logics
{
    public class StandardMessages
    {
        public static string ThanksForYourPurchase()
        {
            
            return $"Thank you for your purchase! Enjoy your movie\nYour Ticket Number:\n{Functions.TicketCodeGenerator()}";

        }
    }
}
