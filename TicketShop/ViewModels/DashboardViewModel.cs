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
        public TicketModel Ticket { get; set; }
        public MovieModel Movie { get; set; }
        public string ConvertTo { get; set; }
        public string CurrencySymbol { get; set; }
        public string AddOrRemove { get; set; }
        public string MovieOrTicket { get; set; }
    }
}
