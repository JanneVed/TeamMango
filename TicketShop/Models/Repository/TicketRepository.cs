using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Data;

namespace TicketShop.Models.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketShopDbContext _Context;

        public TicketRepository(TicketShopDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<TicketModel> GetAllTickets()
        {
            var Tickets = _Context.Tickets;
            return Tickets;
        }

        public TicketModel GetTicket(int ticketId)
        {
            var ticket = _Context.Tickets.Find(ticketId);
            return ticket;
        }

        public TicketModel Update(TicketModel ticketChanges)
        {
            var ticket = _Context.Tickets.Attach(ticketChanges);
            ticket.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();
            return ticketChanges;
        }
    }
}
