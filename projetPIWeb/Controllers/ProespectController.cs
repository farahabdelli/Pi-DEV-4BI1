using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domaine;
using projetPIWeb.Models;
using System.IO;
using Services;
using PagedList;
using PagedList.Mvc;
using System;
using System.Diagnostics;
using System.Dynamic;

namespace projetPIWeb.Controllers
{
    public class ProespectController : Controller
    {

        ServiceProspect sp = new ServiceProspect();
      
        // GET: Product

        public ActionResult ProspectList(string sortOrder, int? page, string SearchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            var prospects = sp.GetMany();
            if (!String.IsNullOrEmpty(SearchString))
            {
                prospects = prospects.Where(s => s.username.Contains(SearchString) 
                                       || s.Nom.Contains(SearchString) || s.telephone.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "name_asc":
                    prospects = prospects.OrderBy(s => s.username);
                    break;
                default:
                    prospects = prospects.OrderBy(s => s.username);
                    break;

            }
            return View(prospects.ToPagedList(page ?? 1, 5));

        }

        //        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Product
        [HttpPost]
        public ActionResult Index(string SearchString)
        {
            var prospects = sp.GetMany(p => p.username.Contains(SearchString));
            return View(prospects);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var prospects = sp.GetById(id);
            return View(prospects);

        }

        // GET: Product/Create
        public ActionResult CreateProspect()
        {
            ProspectModel pm = new ProspectModel();
           
            return View(pm);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult CreateProspect(ProspectModel pm)
        {


            Prospect p = new Prospect()
            {
                Nom = pm.Nom,
                Prenom = pm.Prenom,
                isclient = pm.isclient,
                email = pm.email,
                age = pm.age,
                id = pm.id,
                emailconfirmation = pm.emailconfirmation,
                opreateur = pm.opreateur,
                password = pm.password,
                telephone = pm.telephone,
                username = pm.username,

            };
            //path image
           

            try
            {
                sp.Add(p);
                /*      listproduct.Add(p);
                      Session["Products"] = listproduct;*/
                sp.Commit();

                return RedirectToAction("ProspectList");
            }
            catch
            {
                return View();
            }
        }


        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            var prospects = sp.GetById(id);
            return View(prospects);
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Prospect pp, HttpPostedFileBase Image)
        {


            try
            {

                Prospect p = sp.GetById(id);
                p.age = pp.age;
                p.email = pp.email;
                p.emailconfirmation = pp.emailconfirmation;
                p.opreateur = pp.opreateur;
                Debug.WriteLine(p);
                sp.Update(p);
                sp.Commit();



                return RedirectToAction("ProspectList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            var Prospects = sp.GetById(id);
            return View(Prospects);
        }

        // POST: Produit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var p = sp.GetById(id);
            try
            {
                // TODO: Add delete logic here

                sp.Delete(p);
                sp.Commit();


                return RedirectToAction("ProspectList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dashboard1()
        {
            var list = sp.GetMany();
            List<int> rep = new List<int>();

            var cat = list.Select(x => x.opreateur).Distinct();
            foreach (var item in cat)
            {
                rep.Add(list.Count(x => x.opreateur == item));

            }
            var r = rep;
            ViewBag.Cat = cat;
            ViewBag.R = rep.ToList();


            return View();

        } 






        /// //////////////////////////FRONT CONTROLLER //////////////////////////////////////////


     



    }
}