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
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly DataContext _context;

        public UserController(IUserRepo userRepo, DataContext ctx)
        {
            _userRepo = userRepo;
            _context = ctx;
        }


        // GET: User
        public ActionResult Index()
        {
            return View(_context.Users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var model = _userRepo.GetUser(id);
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User newUser)
        {
            _userRepo.CreateUser(newUser);
            return RedirectToAction(nameof(Index));
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _userRepo.GetAllUsers();
            var std = list.Where(u => u.UserId == id).FirstOrDefault();
            return View(std);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            _userRepo.UpdateUser(user);
            return RedirectToAction(nameof(Index));
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public IActionResult Delete(User user, int id)
        {
            _userRepo.DeleteUser(user.UserId = id);
            return RedirectToAction(nameof(Index));
        }
    }
}