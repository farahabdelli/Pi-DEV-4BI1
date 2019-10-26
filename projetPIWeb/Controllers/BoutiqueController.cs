using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetPIWeb.Controllers
{
    public class BoutiqueController : Controller
    {
        // GET: Boutique
        public ActionResult Index()
        {
            return View();
        }

        // GET: Boutique/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Boutique/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boutique/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Boutique/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Boutique/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Boutique/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Boutique/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
