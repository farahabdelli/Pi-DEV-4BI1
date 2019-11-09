using Domaine;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetPIWeb.Controllers
{
    public class ReponseController : Controller
    {
        ServiceReponse sb = new ServiceReponse();
        // GET: Reponse
        public ActionResult Index()
        {
            var reponse = sb.GetMany();
            return View(reponse);
        }

        // GET: Reponse/Details/5
        public ActionResult Details(int id)
        {
            var s = sb.GetById(id);
            s.NbVues = s.NbVues + 1;
            return View(s);
        }

        // GET: Reponse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reponse/Create
        [HttpPost]
        public ActionResult Create(Reponse sm)
        {



            try
            {
                sb.Add(sm);

                sb.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reponse/Edit/5
        public ActionResult Edit(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Reponse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Reponse cl)
        {
            try
            {
                Reponse clb = sb.GetById(id);
                clb.Titre = cl.Titre;
                Debug.WriteLine(clb);
                sb.Update(clb);
                sb.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reponse/Delete/5
        public ActionResult Delete(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Reponse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var s = sb.GetById(id);
            try
            {
                // TODO: Add delete logic here

                sb.Delete(s);
                sb.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
