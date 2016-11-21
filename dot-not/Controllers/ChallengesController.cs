﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using dot_not.Models;

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

        public ActionResult SimpleChallenge1()
        {
            ChallengeModel challengeModel = idb.Challenges.Find(1);
            return View(challengeModel);
        }

        public ActionResult SimpleChallenge2()
        {
            ChallengeModel challengeModel = idb.Challenges.Find(2);
            challengeModel.Flag = Convert.ToBase64String(Encoding.UTF8.GetBytes(challengeModel.Flag));
            return View(challengeModel);
        }

        public ActionResult SimpleChallenge3()
        {
            ChallengeModel challengeModel = idb.Challenges.Find(3);
            challengeModel.Flag = Convert.ToBase64String(Encoding.UTF8.GetBytes(challengeModel.Flag));
            return View(challengeModel);
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
