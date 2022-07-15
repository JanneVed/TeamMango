using ASP.NET_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Shop.Logics
{
    public class PriceManager
    {
        public static void ToggleDiscount(Ticket ticket)
        {
            if (ticket.IsOnSale == true)
            {
                ticket.Price = 10;
            }
            else if (ticket.IsOnSale == false)
            {
                ticket.Price = 15;
            }
        }
    }
}
