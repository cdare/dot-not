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
    public class ChallengesController : Controller
    {
 
        private IDotNotDBContext idb = new DotNotDBContext();
        private DotNotDBContext db = new DotNotDBContext();

        public ChallengesController() { }

        public ChallengesController(IDotNotDBContext context)
        {
            idb = context;
        }

        // GET: Challenges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeModel challengeModel = idb.Challenges.Find(id);
            if (challengeModel == null)
            {
                return HttpNotFound();
            }
            ChallengeViewModel cvm = new ChallengeViewModel();
            cvm.Challenge = challengeModel;

            return View(cvm);
        }

        //Comments
        public ActionResult Challenge1()
        {
            ChallengeModel challengeModel = idb.Challenges.Find(1);
            return View(challengeModel);
        }

        //Base64 Comments
        public ActionResult Challenge2()
        {
            ChallengeModel challengeModel = idb.Challenges.Find(2);
            challengeModel.Flag = Convert.ToBase64String(Encoding.UTF8.GetBytes(challengeModel.Flag));
            return View(challengeModel);
        }

        //JS Reverse Engineer
        public ActionResult Challenge3()
        {
            ChallengeModel challengeModel = idb.Challenges.Find(3);

            string key = "907b310b879c4526baeee72194424315";
            ViewBag.Key = key;

            ViewBag.Password = ChallengeHelper.XORHexStrings(challengeModel.HexFlag(), key);
            return View(challengeModel);
        }

        //Header Manipulation
        public ActionResult Challenge4()
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
                challengeModel = idb.Challenges.Find(4);
            }
            return View("GenericChallengeView", challengeModel);
        }

        //Header Manipulation 2
        public ActionResult Challenge5()
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
                challengeModel = idb.Challenges.Find(5);
            }
            return View("GenericChallengeView", challengeModel);
        }

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
