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
    public class Sub_CategoryController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Sub_Category
        public ActionResult Index()
        {
            var sub_Category = db.Sub_Category.Include(s => s.Category);
            return View(sub_Category.ToList());
        }

        // GET: Sub_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            if (sub_Category == null)
            {
                return HttpNotFound();
            }
            return View(sub_Category);
        }

        // GET: Sub_Category/Create
        public ActionResult Create()
        {
            ViewBag.Main_categorie_id = new SelectList(db.Categories, "id", "Name");
            return View();
        }

        // POST: Sub_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Main_categorie_id")] Sub_Category sub_Category)
        {
            if (ModelState.IsValid)
            {
                db.Sub_Category.Add(sub_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Main_categorie_id = new SelectList(db.Categories, "id", "Name", sub_Category.Main_categorie_id);
            return View(sub_Category);
        }

        // GET: Sub_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            if (sub_Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.Main_categorie_id = new SelectList(db.Categories, "id", "Name", sub_Category.Main_categorie_id);
            return View(sub_Category);
        }

        // POST: Sub_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Main_categorie_id")] Sub_Category sub_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Main_categorie_id = new SelectList(db.Categories, "id", "Name", sub_Category.Main_categorie_id);
            return View(sub_Category);
        }

        // GET: Sub_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            if (sub_Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.Main_categorie_id = new SelectList(db.Categories, "id", "Name", sub_Category.Main_categorie_id);

            return View(sub_Category);
        }

        // POST: Sub_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            db.Sub_Category.Remove(sub_Category);
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
