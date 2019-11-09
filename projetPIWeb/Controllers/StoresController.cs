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
using System.Diagnostics;

namespace projetPIWeb.Controllers
{
    public class StoresController : Controller
    {
        ServiceBoutique sb = new ServiceBoutique();

        // GET: Stores

        public ActionResult Index(string sortOrder, int? page,String SearchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var s = sb.GetMany();
            if (!String.IsNullOrEmpty(SearchString))
            {
                s = s.Where(ss => ss.Nom.Contains(SearchString)
                                       || ss.Ville.Contains(SearchString) || ss.type.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    s = s.OrderByDescending(ss => ss.Nom);
                    break;
                default:
                    s = s.OrderByDescending(ss => ss.Nom);
                    break;

            }
            return View(s.ToPagedList(page ?? 1, 3));

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
        public ActionResult Edit(int id, FormCollection collection, Store s)
        {
            try
            {
                Store st = sb.GetById(id);
                st.Nom = s.Nom;
                st.Adresse = s.Adresse;
                st.Description = s.Description;
                st.Ville = s.Ville;
                st.type = s.type;
                st.tel = s.tel;
                st.heure_ferm = s.heure_ferm;
                st.heure_ouv = s.heure_ouv;
                Debug.WriteLine(st);
                sb.Update(st);
                sb.Commit();


                return RedirectToAction("Index");
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

        public ActionResult StoreFront(string sortOrder, int? page, String SearchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var s = sb.GetMany();
            if (!String.IsNullOrEmpty(SearchString))
            {
                s = s.Where(ss => ss.Nom.Contains(SearchString)
                                       || ss.Ville.Contains(SearchString) || ss.type.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    s = s.OrderByDescending(ss => ss.Nom);
                    break;
                default:
                    s = s.OrderByDescending(ss => ss.Nom);
                    break;

            }
            return View(s.ToPagedList(page ?? 1, 3));

        }

    }
}
