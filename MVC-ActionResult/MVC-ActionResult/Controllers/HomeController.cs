using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ActionResult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About()
        {
            return Json(new
            {
                id = 1,
                name = "Boone",
                CreateOn = DateTime.Now
            });
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReturnJson()
        {
            return Json(new
            {
                id = 1,
                name = "Boone",
                CreateOn = DateTime.Now
            });
        }
    }
}