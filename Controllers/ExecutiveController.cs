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
    public class ExecutiveController : Controller
    {
        
        public readonly ILogger<ExecutiveController> _logger;
        public readonly IRepo<Executive> _repo;
        public ExecutiveController(ILogger<ExecutiveController> logger, IRepo<Executive> repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Executive> deliveryExecutives = _repo.GetAll().ToList();
            return View(deliveryExecutives);
        }


        public IActionResult ListOfExecutives()
        {

            List<Executive> deliveryExecutives = _repo.GetAll().Where(e => e.IsVerified).ToList();
            return View(deliveryExecutives);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Executive executive)
        {
            _repo.Add(executive);
            ViewData["message"] = "Registration Successfull";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Executive e)
        {
            int id = _repo.Login(e);
            if (id != 0)
            {
                TempData["ExecutiveID"] = id;
                return RedirectToAction("MenuPageExecutive", "Executive");
            }
            else
            {
                return RedirectToAction("Error");

            }
        }
        public IActionResult Verify(int id)
        {
            Executive executive = _repo.Get(id);
            return View(executive);
        }
        [HttpPost]
        public IActionResult Verify(int id, Executive executive)
        {
            _repo.Update(id, executive);

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
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult MenuPageExecutive()
        {
            return View();
        }
        public ActionResult NotVerified()
        {
            return View();
        }
       
        public IActionResult LogOut()
        {

            return RedirectToAction("Login");
        }
    }
}
