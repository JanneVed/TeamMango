using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Models;
using TicketShop.Models.Repository;
using TicketShop.ViewModels;

namespace TicketShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountRepository _AccountContext;
        private readonly ITicketRepository _TicketContext;
        private readonly IMovieRepository _MovieContext;
        private readonly IPurchaseRepository _PurchaseContext;


        public AdminController(IAccountRepository accountRepository, ITicketRepository ticketRepository, IMovieRepository movieRepository,
            IPurchaseRepository purchaseRepository)
        {
            _AccountContext = accountRepository;
            _TicketContext = ticketRepository;
            _MovieContext = movieRepository;
            _PurchaseContext = purchaseRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in _AccountContext.GetAccounts())
                {
                    if (model.UserName == item.UserName)
                    {
                        if (model.Password == item.Password)
                        {
                            if (item.IsAdmin)
                            {
                                return RedirectToAction("Dashboard");
                            }
                            else if (item.IsAdmin == false)
                            {
                                return RedirectToAction("index", "home");
                            }
                        }
                    }
                }
            }
            return RedirectToAction("home", "index");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var dashboardViewModel = new DashboardViewModel()
            {
                Tickets = _TicketContext.GetAllTickets(),
                Movies = _MovieContext.GetAllMovies(),
                Purchases = _PurchaseContext.GetAllPurchases()
            };
            return View(dashboardViewModel);
        }
        [HttpPost]
        public IActionResult Dashboard(TicketModel ticket, MovieModel movie)
        {
            _TicketContext.Update(ticket);

            return RedirectToAction("dashboard");
        }
    }
}
