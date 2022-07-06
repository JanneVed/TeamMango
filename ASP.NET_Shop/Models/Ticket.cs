using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Shop.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsInStock { get; set; }
        public bool IsOnSale { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
