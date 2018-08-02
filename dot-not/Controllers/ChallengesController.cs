using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using dot_not.Models;
using System.Numerics;
using dot_not.Helpers;
using Microsoft.Ajax.Utilities;

namespace dot_not.Controllers
{
    [Authorize(Roles = "User")]
    public class ChallengesController : Controller
    {
 
        private IDotNotDBContext idb = new DotNotDBContext();
        private DotNotDBContext db = new DotNotDBContext();

        public ChallengesController() { }

        public ChallengesController(IDotNotDBContext context)
        {
            idb = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }


        //Comments
        public ActionResult Basic1()
        {
            ChallengeModel challengeModel = idb.Challenges.Where(c => c.ChallengeID == 1).First();
            return View(challengeModel);
        }

        //Base64 Comments
        public ActionResult Basic2()
        {
            ChallengeModel challengeModel = idb.Challenges.Where(c => c.ChallengeID == 2).First();
            challengeModel.Flag = Convert.ToBase64String(Encoding.UTF8.GetBytes(challengeModel.Flag));
            return View(challengeModel);
        }

        //JS Reverse Engineer
        public ActionResult Reversing1()
        {
            ChallengeModel challengeModel = idb.Challenges.Where(c => c.ChallengeID == 10).First();

            string key = "907b310b879c4526baeee72194424315";
            ViewBag.Key = key;

            ViewBag.Password = ChallengeHelper.XORHexStrings(challengeModel.HexFlag(), key);
            return View(challengeModel);
        }

        //Header Manipulation
        public ActionResult Spoofing1()
        {
            ChallengeModel challengeModel = new ChallengeModel();
            ViewBag.Title = "A Local Shop for Local People";
            ViewBag.Comment = "flag_unsuccessful";
            ViewBag.Error = "Sorry, Only accepting connections from localhost";
            string ip = Request.Headers.Get("X-FORWARDED-FOR");
            if (ip.IsNullOrWhiteSpace())
            {
                ip = Request.UserHostAddress;
            }
            if (ip == "127.0.0.1" || ip == "localhost")
            {
                ViewBag.Comment = "flag_success";
                ViewBag.Error = "You did it!";
                challengeModel = idb.Challenges.Where(c => c.ChallengeID == 3).First();
            }
            return View("GenericChallengeView", challengeModel);
        }

        //Header Manipulation 2
        public ActionResult Spoofing2()
        {
            ChallengeModel challengeModel = new ChallengeModel();

            ViewBag.Title = "Browser Compatability";
            ViewBag.Comment = "flag_unsuccessful";
            ViewBag.Error = "Sorry, this page only works with Internet Explorer 6";
            string ua = Request.Headers.Get("User-Agent");
    
            if (ua.Contains("MSIE 6.0"))
            {
                ViewBag.Comment = "flag_success";
                ViewBag.Error = "You did it!";
                challengeModel = idb.Challenges.Where(c => c.ChallengeID == 4).First();
            }
            return View("GenericChallengeView", challengeModel);
        }

        //XSS 1
        public ActionResult Challenge6()
        {
            ChallengeModel challengeModel = new ChallengeModel();

            ViewBag.Title = "Caption Competition";
            ViewBag.Comment = "flag_unsuccessful";
            ViewBag.Error = "Sorry, this page only works with Internet Explorer 6";
            string ua = Request.Headers.Get("User-Agent");

            if (ua.Contains("MSIE 6.0"))
            {
                ViewBag.Comment = "flag_success";
                ViewBag.Error = "You did it!";
                challengeModel = idb.Challenges.Where(c => c.ChallengeID == 6).First(); ;
            }
            return View("GenericChallengeView", challengeModel);
        }

        public ActionResult

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                idb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
