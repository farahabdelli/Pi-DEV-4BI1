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
using PagedList;

namespace projetPIWeb.Controllers
{
    public class StoresController : Controller
    {
        ServiceBoutique sb = new ServiceBoutique();

        // GET: Stores

        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var s = sb.GetMany();
            switch (sortOrder)
            {
                case "name_desc":
                    s = s.OrderByDescending(ss => ss.Nom);
                    break;
                default:
                    s = s.OrderByDescending(ss => ss.Nom);
                    break;

            }
            return View(s.ToPagedList(page ?? 1, 1));

        }

        // GET: Stores/Details/5
        public ActionResult DetailsStore(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // GET: Stores/Create
        public ActionResult CreateStore()
        {
            StoreModel pm = new StoreModel();
            return View(pm);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult CreateStore(StoreModel sm)
        {

            Store s = new Store()
            {
                Nom = sm.Nom,
                Description = sm.Description,
                Adresse = sm.Adresse,
                Ville = sm.Ville,
                tel = sm.tel,
                type = sm.type,
                heure_ouv = sm.heure_ouv,
                heure_ferm = sm.heure_ferm,
                //Produits = sm.Produits

            };

            try
            {
                sb.Add(s);
            
                sb.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, StoreModel pm)
        {


            try
            {
                // TODO: Add update logic here
                // sp.Update(pm);
                return RedirectToAction("ProductList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Delete/5
        public ActionResult DeleteStore(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult DeleteStore(int id, FormCollection collection)
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
