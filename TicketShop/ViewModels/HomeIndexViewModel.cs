using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Models;

namespace TicketShop.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<MovieModel> Movies { get; set; }
        public IEnumerable<TicketModel> Tickets { get; set; }

        public int Amount { get; set; }
        public int TicketId { get; set; }
        public int MovieId { get; set; }
    }
}
