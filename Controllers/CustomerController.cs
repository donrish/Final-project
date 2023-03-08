using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelsProject.Models;
using DelsProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DelsProject.Controllers
{
    public class CustomerController : Controller
    {
       
        public readonly ILogger<CustomerController> _logger;
        public readonly IRepo<Customer> _repo;
        public CustomerController(ILogger<CustomerController> logger, IRepo<Customer> repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> cust = _repo.GetAll().ToList();
          
            return View(cust);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            
            _repo.Add(c);
            ViewData["message"] = "Registration Successfull";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer d)
        {

            int id = _repo.Login(d);
            if (id != 0)
            {
                TempData["CustomerID"] = id;
                return RedirectToAction("MenuPageCustomer", "Customer");
            }
            else
            {
                return RedirectToAction("Error");

            }

        }
        public IActionResult Verify(int id)
        {
            Customer customer = _repo.Get(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Verify(int id, Customer customer)
        {
            _repo.Update(id, customer);

            return RedirectToAction("Index");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotVerified()
        {
            return View();
        }
        public ActionResult MenuPageCustomer()
        {
            return View();
        }
        public IActionResult LogOut()
        {

            return RedirectToAction("Login");
        }
    }
}
