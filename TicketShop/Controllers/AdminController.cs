using Microsoft.AspNetCore.Mvc;
using TicketShop.Models;
using TicketShop.Models.Repository;
using TicketShop.ViewModels;
using TicketShop.Objects;
using TicketShop.Logics;

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
        public IActionResult Dashboard(DashboardViewModel dashboardViewModel)
        {

            dashboardViewModel.Tickets = _TicketContext.GetAllTickets();
            dashboardViewModel.Movies = _MovieContext.GetAllMovies();
            dashboardViewModel.Purchases = _PurchaseContext.GetAllPurchases();

            if (dashboardViewModel.ConvertTo == null)
            {
                dashboardViewModel.CurrencySymbol = "$";
                dashboardViewModel.ConvertTo = "USD";
            }
            else if (dashboardViewModel.ConvertTo == "USD")
            {
                dashboardViewModel.CurrencySymbol = "$";
            }
            else if (dashboardViewModel.ConvertTo == "EUR")
            {
                foreach (var purchase in dashboardViewModel.Purchases)
                {
                    var result = APICalls.GetCurrencyConversionAPI(dashboardViewModel.ConvertTo, purchase.PurchasePrice);
                    purchase.PurchasePrice = result.Result;
                }
                dashboardViewModel.CurrencySymbol = "€";
            }
            else if (dashboardViewModel.ConvertTo == "SEK")
            {
                foreach (var purchase in dashboardViewModel.Purchases)
                {
                    var result = APICalls.GetCurrencyConversionAPI(dashboardViewModel.ConvertTo, purchase.PurchasePrice);
                    purchase.PurchasePrice = result.Result;
                }
                dashboardViewModel.CurrencySymbol = "kr";
            }

            return View(dashboardViewModel);
        }
        [HttpPost]
        public IActionResult Dashboard(TicketModel ticket, MovieModel movie, CCViewModel model)
        {
            if (ticket.TicketId != 0)
            {
                _TicketContext.UpdateTicket(ticket);
            }
            else if (movie.MovieId != 0)
            {
                _MovieContext.UpdateMovie(movie);
            }

            if (model.ConvertTo != null)
            {
                return RedirectToAction("dashboard", model);
            }

            return RedirectToAction("dashboard");
        }
    }
}
