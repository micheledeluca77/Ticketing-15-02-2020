using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Data;
using Ticketing.Models;
using Ticketing.Repos;

namespace Ticketing.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepo _ticketRepo;
        private readonly DataContext _context;

        public TicketController(ITicketRepo ticketRepo, DataContext ctx)
        {
            _ticketRepo = ticketRepo;
            _context = ctx;
        }


        // GET: Ticket
        public ActionResult Index()
        {
            return View(_context.Tickets);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            var model = _ticketRepo.GetTicket(id);
            return View(model);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket newTicket)
        {
            _ticketRepo.CreateTicket(newTicket);
            return RedirectToAction(nameof(Index));
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _ticketRepo.GetAllTickets();
            var std = list.Where(u => u.TicketId == id).FirstOrDefault();
            return View(std);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ticket ticket)
        {
            _ticketRepo.UpdateTicket(ticket);
            return RedirectToAction(nameof(Index));
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public IActionResult Delete(Ticket ticket, int id)
        {
            _ticketRepo.DeleteTicket(ticket.TicketId = id);
            return RedirectToAction(nameof(Index));
        }
    }
}