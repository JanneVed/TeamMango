﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Models.Repository
{
    public interface ITicketRepository
    {
        public TicketModel UpdateTicket(TicketModel ticketChanges);
        public IEnumerable<TicketModel> GetAllTickets();
        public TicketModel GetTicket(int ticketId);
        public TicketModel RemoveTicket(int ticketId);
        public TicketModel AddTicket(TicketModel newTicket);
    }
}
