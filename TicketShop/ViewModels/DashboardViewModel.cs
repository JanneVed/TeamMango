using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Models;

namespace TicketShop.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<MovieModel> Movies { get; set; }
        public IEnumerable<TicketModel> Tickets { get; set; }
        public IEnumerable<PurchaseModel> Purchases { get; set; }
    }
}
