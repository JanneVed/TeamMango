using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Models
{
    public class TicketModel
    {
        [Key]
        public int TicketId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TicketPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TicketDiscountPrice { get; set; }

        public bool TicketIsInStock { get; set; }
        public int TicketStock { get; set; }

        public int MovieId { get; set; }
        public MovieModel Movie { get; set; }
    }
}
