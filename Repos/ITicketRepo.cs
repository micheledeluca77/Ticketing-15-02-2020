using System.Collections.Generic;
using Ticketing.Models;

namespace Ticketing.Repos
{
    public interface ITicketRepo
    {
        void CreateTicket(Ticket newTicket);
        void DeleteTicket(int id);
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicket(int id);
        void UpdateTicket(Ticket newTicket);
    }
}