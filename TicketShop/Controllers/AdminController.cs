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
        public IActionResult Login(LoginViewModel account)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in _AccountContext.GetAccounts())
                {
                    if (account.UserName == item.UserName)
                    {
                        if (account.Password == item.Password)
                        {
                            if (item.IsAdmin)
                            {
                                return RedirectToAction("Dashboard");
                            }
                            else if (item.IsAdmin == false)
                            {
                                return RedirectToAction("home", "index");
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
        public IActionResult Dashboard(TicketModel ticket, MovieModel movie, Convert convert)
        {
            if (ticket.TicketId != 0)
            {
                _TicketContext.UpdateTicket(ticket);
            }
            else if (movie.MovieId != 0)
            {
                _MovieContext.UpdateMovie(movie);
            }

            if (convert.ConvertTo != null)
            {
                return RedirectToAction("dashboard", convert);
            }

            return RedirectToAction("dashboard");
        }

        [HttpPost]
        public IActionResult AddOrRemove(TicketModel ticket, MovieModel movie, Operation operation)
        {
            if (operation.AddOrRemove == "Remove")
            {
                if (ticket.TicketId != 0)
                {
                    _TicketContext.RemoveTicket(ticket.TicketId);
                }
                else if (movie.MovieId != 0)
                {
                    _MovieContext.RemoveMovie(movie.MovieId);
                }
                return RedirectToAction("dashboard");
            }
            else if (operation.AddOrRemove == "Add")
            {
                if (operation.MovieOrTicket == "Ticket")
                {
                    _TicketContext.AddTicket(ticket);
                }
                else if (operation.MovieOrTicket == "Movie")
                {
                    _MovieContext.AddMovie(movie);
                }
                return RedirectToAction("dashboard");
            }
            return RedirectToAction("dashboard");
        }
    }
}
