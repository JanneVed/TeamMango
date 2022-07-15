using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieImageUrl { get; set; }
        public string MovieTitle { get; set; }
        public string MovieSynopsis { get; set; }
        public string MovieLength { get; set; }
        public string MovieGenre { get; set; }

        public ICollection<TicketModel> Tickets { get; set; }
    }
}
