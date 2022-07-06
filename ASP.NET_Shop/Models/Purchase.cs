using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Shop.Models
{
    public class Purchase
    {
        public int BuyerId { get; set; }
        public string Buyer { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}
