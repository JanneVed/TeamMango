using ASP.NET_Shop.Data;
using ASP.NET_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Shop.Logics
{
    public class StockManager
    {
        public static void SetInStockStatus(Ticket ticket)
        {
            if (ticket.Stock == 0)
            {
                ticket.IsInStock = false;
            }
            else if (ticket.Stock > 0)
            {
                ticket.IsInStock = true;
            }
        }
    }
}
