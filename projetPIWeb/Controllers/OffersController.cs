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
using Services;
using System.IO;

namespace projetPIWeb.Controllers
{
    public class OffersController : Controller
    {
        private projetPIWebContext db = new projetPIWebContext();
        ServiceProduit sp = new ServiceProduit();
        ServiceOffer cp = new ServiceOffer();




        // GET: Offers
        public ActionResult Index()
        {
            var offers = db.Offers.Include(o => o.Product);
            return View(offers.ToList());
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            ViewBag.ProduitId = new SelectList(db.Products, "ProduitId", "Nom");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferModels pm, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                pm.picture = Image.FileName;
            }
            Offer p = new Offer()
            {

                title = pm.title,
                description = pm.description,
                category = pm.category,
                picture = pm.picture,
                start_date = pm.start_date,
                end_date = pm.end_date,
                ProduitId = pm.ProduitId,



            };
            //path image
            if (Image != null)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);
            }

            try
            {
                db.Offers.Add(p);
                db.SaveChanges();
                cp.Add(p);
                /*      listOffer.Add(p);
                      Session["Offers"] = listOffer;*/
                cp.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProduitId = new SelectList(db.Products, "ProduitId", "Nom", offer.ProduitId);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfferId,title,description,picture,category,start_date,end_date,ProduitId")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProduitId = new SelectList(db.Products, "ProduitId", "Nom", offer.ProduitId);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offer offer = db.Offers.Find(id);
            db.Offers.Remove(offer);
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
