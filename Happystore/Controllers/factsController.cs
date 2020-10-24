using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Happystore.Models;

namespace Happystore.Controllers
{
    public class factsController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: facts
        public ActionResult Index()
        {
            return View(db.facts.ToList());
        }

        // GET: facts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fact fact = db.facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // GET: facts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: facts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,address,phone")] fact fact)
        {
            if (ModelState.IsValid)
            {
                db.facts.Add(fact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fact);
        }

        // GET: facts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fact fact = db.facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // POST: facts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,address,phone")] fact fact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fact);
        }

        // GET: facts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fact fact = db.facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // POST: facts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fact fact = db.facts.Find(id);
            db.facts.Remove(fact);
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
