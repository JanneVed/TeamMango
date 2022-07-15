using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Models.Repository
{
    public interface ITicketRepository
    {
        public TicketModel Update(TicketModel ticketChanges);
        public IEnumerable<TicketModel> GetAllTickets();
        public TicketModel GetTicket(int ticketId);
    }
}
