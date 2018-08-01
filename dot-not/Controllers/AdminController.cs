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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IDotNotDBContext idb = new DotNotDBContext();
        private DotNotDBContext db = new DotNotDBContext();

        public AdminController() { }

        public AdminController(IDotNotDBContext context)
        {
            idb = context;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(idb.Challenges.ToList());
        }



        // GET: Admin/Details/5
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
            return View(challengeModel);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Flag")] ChallengeModel challengeModel)
        {
            if (ModelState.IsValid)
            {
                idb.Challenges.Add(challengeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(challengeModel);
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
   
        public ActionResult ResetFlags()
        {
            foreach( ChallengeModel c in db.Challenges)
            {
                c.ResetFlag();
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
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
            return View(challengeModel);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Flag")] ChallengeModel challengeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(challengeModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(challengeModel);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
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
            return View(challengeModel);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChallengeModel challengeModel = idb.Challenges.Find(id);
            idb.Challenges.Remove(challengeModel);
            db.Entry(challengeModel).State = System.Data.Entity.EntityState.Deleted;
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
