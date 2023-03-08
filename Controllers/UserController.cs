using DelsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DelsProject.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("Create", "Customer");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("Create", "Executive");
            }
            return View();
        }
        public ActionResult Login(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("Login", "Customer");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("Login", "Executive");
            }
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
       



    }
}
