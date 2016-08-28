using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dot_not.Models;

namespace dot_not.Controllers
{
    public class ChallengesController : Controller
    {
 
        private DotNotDBContext db = new DotNotDBContext();

        public ChallengesController() { }

        public ChallengesController(DotNotDBContext context)
        {
            db = context;
        }

        // GET: Challenges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeModel challengeModel = db.Challenges.Find(id);
            if (challengeModel == null)
            {
                return HttpNotFound();
            }
            ChallengeViewModel cvm = new ChallengeViewModel();
            cvm.Challenge = challengeModel;

            return View(cvm);
        }

        // GET: Challenges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Challenges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Flag")] ChallengeModel challengeModel)
        {
            if (ModelState.IsValid)
            {
                db.Challenges.Add(challengeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(challengeModel);
        }

        [HttpPost]
        public ActionResult Submit(ChallengeViewModel challengeModel)
        {
            ChallengeModel challengeToSolve = db.Challenges.Find(challengeModel.Challenge.ID);

            ChallengeViewModel svm = new ChallengeViewModel();

            if(challengeModel.Challenge.Flag == challengeToSolve.Flag)
            {
                svm.Success = true;
                //Update user model to say they solved challenge
            }
   
            return View("Details",svm);

        }

        // GET: Challenges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeModel challengeModel = db.Challenges.Find(id);
            if (challengeModel == null)
            {
                return HttpNotFound();
            }
            return View(challengeModel);
        }

        // POST: Challenges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Flag")] ChallengeModel challengeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(challengeModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(challengeModel);
        }


        // GET: Challenges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeModel challengeModel = db.Challenges.Find(id);
            if (challengeModel == null)
            {
                return HttpNotFound();
            }
            return View(challengeModel);
        }

        // POST: Challenges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChallengeModel challengeModel = db.Challenges.Find(id);
            db.Challenges.Remove(challengeModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
