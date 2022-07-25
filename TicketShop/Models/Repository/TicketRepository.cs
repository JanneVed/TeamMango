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

        public TicketModel AddTicket(TicketModel newTicket)
        {
            _Context.Tickets.Add(newTicket);
            _Context.SaveChanges();
            return newTicket;
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

        public TicketModel RemoveTicket(int ticketId)
        {
            var ticket = _Context.Tickets.Find(ticketId);
            if (ticket != null)
            {
                _Context.Tickets.Remove(ticket);
                _Context.SaveChanges();
            }
            return ticket;
        }

        public TicketModel UpdateTicket(TicketModel ticketChanges)
        {
            var ticket = _Context.Tickets.Attach(ticketChanges);
            ticket.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();
            return ticketChanges;
        }
    }
}
