using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dot_not.Models;

namespace dot_not.Controllers
{
    public class HomeController : Controller
    {
        private IDotNotDBContext idb = new DotNotDBContext();
        HomeViewModel model = new HomeViewModel();

        public HomeController() { }

        public HomeController(IDotNotDBContext context)
        {
            idb = context;
        }

        public ActionResult Index()
        {
            return View(model);
        }

        public ActionResult Leaderboard()
        {
            return View(model);
        }
    }
}