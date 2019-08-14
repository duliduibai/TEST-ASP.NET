using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VM_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public bool Authenticate(string userName, string password)
        {

            return true;
        }

        [HttpPost]
        public bool Register(string userName, string password)
        {

            return true;
        }
    }
}