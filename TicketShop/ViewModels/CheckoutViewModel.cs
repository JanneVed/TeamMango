using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Models;

namespace TicketShop.ViewModels
{
    public class CheckoutViewModel
    {
        public MovieModel Movie { get; set; }
        //public PurchaseModel Purchase { get; set; }
        public TicketModel Ticket { get; set; }

        public int PurchaseId { get; set; }
        public string Buyer { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime DateOfPurchase { get; set; }
        public int Amount { get; set; }
        public int TicketId { get; set; }
        public int MovieId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }
        public string Code { get; set; }
        public string GoTo { get; set; } = "checkcode";

    }
}
