using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Shop.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieImageUrl { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public string MovieLength { get; set; }
        public string Genre { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
