using Domaine;
using projetPIWeb.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetPIWeb.Controllers
{

    public class PubliciteController : Controller
    {
        ServicePublicite sb = new ServicePublicite();
        projetPIWebContext context = new projetPIWebContext();

        // GET: Publicite
        public ActionResult Index()
        {
            var question = sb.GetMany();
            return View(question);
        }

        // GET: Publicite/Details/5
        public ActionResult Details(int id)
        {
            var s = sb.GetById(id);
            s.NbVues = s.NbVues + 1;
            return View(s);
        }

        // GET: Publicite/Create
        public ActionResult Create()
        {
            PubliciteModel pm = new PubliciteModel();
            return View(pm);
        }

        // POST: Publicite/Create
        [HttpPost]
        public ActionResult Create(PubliciteModel pm)
        {
            Publicite p = new Publicite()
            {
                NomPartenaire = pm.NomPartenaire,
                TitrePub = pm.TitrePub,
                DescriptionPub = pm.DescriptionPub,
                Address=pm.Address,
                Lat=pm.Lat,
                Long=pm.Long,
                Image = pm.Image,
                DateDebut = pm.DateDebut,
                DateFin = pm.DateFin,
                NbVues = pm.NbVues,


            };



            sb.Add(p);
            /*      listproduct.Add(p);
                  Session["Products"] = listproduct;*/
            sb.Commit();

            return RedirectToAction("Index");

        }

        // GET: Publicite/Edit/5
        public ActionResult Edit(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Publicite/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Publicite cl)
        {
            try
            {
                Publicite clb = sb.GetById(id);
                clb.TitrePub = cl.TitrePub;
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

        // GET: Publicite/Delete/5
        public ActionResult Delete(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Publicite/Delete/5
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
        public JsonResult GetAllLocation()
        {
            var data = context.Publicite.ToList().Select(S => new
            {
                Address = S.Address,
                Lat = S.Lat,
                Long = S.Long
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IndexNew()
        {
            ViewBag.date = context.Publicite.ToList().Select(S => new
            {
                Address = S.Address,
                Lat = S.Lat,
                Long = S.Long
            });
            return View();
        }
    }
}

