using System;
using System.Collections.Generic;
using System.Linq;
using DelsProject.Models;
using DelsProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DelsProject.Controllers
{
    public class BookingController : Controller
    {
        public readonly ILogger<BookingController> _logger;
        public readonly IRepo<Booking> _repo;
        public BookingController(ILogger<BookingController> logger, IRepo<Booking> repo)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLogin admin)
        {
            if (admin.Username == "Rishab" && admin.Password == "Rish@12345")
            {
                return RedirectToAction("MenuPageAdmin");
            }
            else
            {
                ViewData["message"] = "Invalid credentials, Kindly enter valid credentials.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Booking> booking = _repo.GetAll().ToList();
            return View(booking);
        }
        public IActionResult RecentBookings()
        {
            int id = Convert.ToInt32(TempData.Peek("CustomerID"));
            List<Booking> booking = _repo.GetAll().Where(a => a.CustomerID == id && (a.BookingStatus != "OrderAccepted" && a.BookingStatus != "OrderOnProgress" && a.BookingStatus != "OrderDelivered" && a.BookingStatus != "OrderRejected")).ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("Empty");
            }
            return View();
        }
        public IActionResult AcceptedBookings()
        { 
            int id = Convert.ToInt32(TempData.Peek("CustomerID"));
            List<Booking> booking = _repo.GetAll().Where(a => a.CustomerID == id &&( a.BookingStatus == "OrderAccepted" || a.BookingStatus == "OrderOnProgress" || a.BookingStatus == "OrderDelivered" || a.BookingStatus == "OrderRejected")).ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("EmptyAccepted");
            }
            return View();
        }

        public IActionResult AddBooking()
        {
            int Custid = Convert.ToInt32(TempData.Peek("CustomerID"));
            Booking booking = new Booking();
            booking.CustomerID = Custid;
            return View(booking);
        }
        [HttpPost]

        public IActionResult AddBooking(Booking b)
        {
            _repo.Add(b);
            return RedirectToAction("RecentBookings");

        }
        [HttpGet]
        public IActionResult StatusUpdate(int id)
        {

            Booking booking = _repo.Get(id);
            return View(booking);
        }
        public IActionResult StatusUpdate(int id, Booking booking)
        {
            _repo.UpdateOrder(id, booking);
            return RedirectToAction("RequestFromCustomers");
        }
        public IActionResult EditBooking(int id)
        {
            Booking booking = _repo.Get(id);
            return View(booking);
        }
        [HttpPost]
        public IActionResult EditBooking(int id,Booking booking)
        {
            _repo.Update(id, booking);
            return RedirectToAction("RecentBookings");

        }
        public ActionResult CancelBooking(int id)
        {
            Booking booking = _repo.Get(id);
            return View(booking);
            
        }
        [HttpPost]
        public IActionResult CancelBooking(int id,Booking booking)
        {
            booking.OrderID = id;
            _repo.CancelBooking(booking);
            return View(booking);
        }
        public IActionResult BookingDetails(int id)
        {
            Booking booking = _repo.Get(id);
            return View(booking);
        }
        

        [HttpGet]
        public IActionResult RequestFromCustomers(Booking b)
        {
            int Execid = Convert.ToInt32(TempData.Peek("ExecutiveID"));
            List<Booking> booking = _repo.GetAll().Where(a => a.ExecutiveID == Execid).ToList();
            return View(booking);

        }
        public IActionResult Empty()
        {
            return View();
        }
        public IActionResult EmptyAccepted()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View("Login");
        }
        public ActionResult MenuPageAdmin()
        {
            return View();
        }

    }
}
