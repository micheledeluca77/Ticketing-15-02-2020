using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Data;
using Ticketing.Models;

namespace Ticketing.Repos
{
    public class TicketRepo : ITicketRepo
    {
        private DataContext _context;

        public TicketRepo(DataContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Tickets.AsEnumerable();
        }

        public void CreateTicket(Ticket newTicket)
        {
            newTicket.TicketId = 0;
            _context.Tickets.Add(newTicket);
            _context.SaveChanges();
        }

        public void UpdateTicket(Ticket newTicket)
        {
            _context.Tickets.First(d => d.TicketId == newTicket.TicketId).Title = newTicket.Title;
            _context.Tickets.First(d => d.TicketId == newTicket.TicketId).Request = newTicket.Request;
            _context.Tickets.First(d => d.TicketId == newTicket.TicketId).Response = newTicket.Response;
            _context.Tickets.First(d => d.TicketId == newTicket.TicketId).RequestTime = newTicket.RequestTime;
            _context.Tickets.First(d => d.TicketId == newTicket.TicketId).ResponseTime = newTicket.ResponseTime;
            _context.Tickets.First(d => d.TicketId == newTicket.TicketId).State = newTicket.State;
            _context.SaveChanges();
        }

        public Ticket GetTicket(int id)
        {
            return _context.Tickets
                .Include(t => t.User)
                .FirstOrDefault(a => a.TicketId == id);
        }

        public void DeleteTicket(int id)
        {
            _context.Tickets.Remove(_context.Tickets.Find(id));
            _context.SaveChanges();
        }
    }
}
