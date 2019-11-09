using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domaine;
using projetPIWeb.Models;

namespace projetPIWeb.Controllers
{
    public class PacksController : Controller
    {
        private projetPIWebContext db = new projetPIWebContext();

        // GET: Packs
        public ActionResult Index()
        {
            var packs = db.Packs.Include(p => p.Offer);
            return View(packs.ToList());
        }

        // GET: Packs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = db.Packs.Find(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // GET: Packs/Create
        public ActionResult Create()
        {
            ViewBag.OfferId = new SelectList(db.Offers, "OfferId", "title");
            return View();
        }

        // POST: Packs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackId,quantity,OfferId")] Pack pack)
        {
            if (ModelState.IsValid)
            {
                db.Packs.Add(pack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OfferId = new SelectList(db.Offers, "OfferId", "title", pack.OfferId);
            return View(pack);
        }

        // GET: Packs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = db.Packs.Find(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfferId = new SelectList(db.Offers, "OfferId", "title", pack.OfferId);
            return View(pack);
        }

        // POST: Packs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackId,quantity,OfferId")] Pack pack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OfferId = new SelectList(db.Offers, "OfferId", "title", pack.OfferId);
            return View(pack);
        }

        // GET: Packs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = db.Packs.Find(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Packs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pack pack = db.Packs.Find(id);
            db.Packs.Remove(pack);
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
