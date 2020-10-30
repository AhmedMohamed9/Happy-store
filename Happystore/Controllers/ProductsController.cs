using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Happystore.Models;

namespace Happystore.Controllers
{
    public class ProductsController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Sub_Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Sub_Categorie_id = new SelectList(db.Sub_Category, "id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/upload"),
                    DateTime.Now.ToString("MM-dd-yyyy H-mm-ss") + upload.FileName);
                upload.SaveAs(path);
                product.Image = DateTime.Now.ToString("MM-dd-yyyy H-mm-ss") + upload.FileName;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sub_Categorie_id = new SelectList(db.Sub_Category, "id", "Name", product.Sub_Categorie_id);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sub_Categorie_id = new SelectList(db.Sub_Category, "id", "Name", product.Sub_Categorie_id);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload !=null)
                {
                    string path = Path.Combine(Server.MapPath("~/upload"),
                       DateTime.Now.ToString("MM-dd-yyyy H-mm-ss") + upload.FileName);
                    string oldpath = Path.Combine(Server.MapPath("~/upload"), product.Image);
                    upload.SaveAs(path);
                    System.IO.File.Delete(oldpath);
                    product.Image = DateTime.Now.ToString("MM-dd-yyyy H-mm-ss") + upload.FileName;
                    
                }
                
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sub_Categorie_id = new SelectList(db.Sub_Category, "id", "Name", product.Sub_Categorie_id);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Product product = db.Products.Find(id);
            string oldpath = Path.Combine(Server.MapPath("~/upload"), product.Image);
            db.Products.Remove(product);
            db.SaveChanges();
            System.IO.File.Delete(oldpath);
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
