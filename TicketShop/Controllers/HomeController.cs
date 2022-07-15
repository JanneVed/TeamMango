using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Logics;
using TicketShop.Models;
using TicketShop.Models.Repository;
using TicketShop.ViewModels;

namespace TicketShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository _MovieRepo;
        private readonly ITicketRepository _TicketRepo;
        private readonly IPurchaseRepository _PurchaseRepo;

        public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepository, ITicketRepository ticketRepository,
            IPurchaseRepository purchaseRepository)
        {
            _logger = logger;
            _MovieRepo = movieRepository;
            _TicketRepo = ticketRepository;
            _PurchaseRepo = purchaseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var homeIndexViewModel = new HomeIndexViewModel()
            {
                Movies = _MovieRepo.GetAllMovies(),
                Tickets = _TicketRepo.GetAllTickets(),
                Amount = 1
            };
            return View(homeIndexViewModel);
        }

        [HttpPost]
        public IActionResult Index(PurchaseModel purchase)
        {
            return RedirectToAction("checkout", purchase);
        }

        [HttpGet]
        public IActionResult Checkout(CheckoutViewModel checkoutViewModel)
        {
            checkoutViewModel.Movie = _MovieRepo.GetMovie(checkoutViewModel.MovieId);
            checkoutViewModel.Ticket = _TicketRepo.GetTicket(checkoutViewModel.TicketId);
            if (checkoutViewModel.Code != "Redeemed!")
            {
                checkoutViewModel.PurchasePrice = checkoutViewModel.Ticket.TicketPrice * checkoutViewModel.Amount;
            }

            return View(checkoutViewModel);
        }

        [HttpPost]
        public IActionResult Checkout(PurchaseModel purchase)
        {
            var purchasedTicket = _TicketRepo.GetTicket(purchase.TicketId);
            purchasedTicket.TicketStock -= purchase.Amount;
            _TicketRepo.Update(purchasedTicket);

            purchase.DateOfPurchase = DateTime.Now;
            _PurchaseRepo.CreateNewPurchase(purchase);
            
            return RedirectToAction("CheckoutComplete");
        }

        [HttpPost]
        public IActionResult CheckCode(CheckoutViewModel checkoutViewModel)
        {
            if (checkoutViewModel.Code == "ticket10")
            {
                ViewBag.wrong = null;
                checkoutViewModel.Ticket = _TicketRepo.GetTicket(checkoutViewModel.TicketId);
                checkoutViewModel.PurchasePrice = checkoutViewModel.Ticket.TicketPrice * checkoutViewModel.Amount;
                checkoutViewModel.PurchasePrice *= 0.9m;
                checkoutViewModel.Code = "Redeemed!";
                checkoutViewModel.GoTo = "checkout";
                return RedirectToAction("checkout", checkoutViewModel);
            }
            else if (checkoutViewModel.Code == null)
            {
                checkoutViewModel.GoTo = "checkout";
                return RedirectToAction("checkout", checkoutViewModel);
            }
            ViewBag.wrong = "Your code was invalid, please check your code and try again.";
            return RedirectToAction("checkout", checkoutViewModel);
        }

        [HttpGet]
        public IActionResult CheckoutComplete()
        {
            ViewBag.Thanks = StandardMessages.ThanksForYourPurchase();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
