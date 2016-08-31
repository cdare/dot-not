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
            model.Challenges = idb.Challenges.ToList();
            return View(model);
        }

    }
}