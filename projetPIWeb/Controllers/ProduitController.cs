using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domaine;
using projetPIWeb.Models;
using System.IO;
using Services;

namespace projetPIWeb.Controllers
{
    public class ProduitController : Controller
    {
        
        ServiceCategorie sc = new ServiceCategorie();
        ServiceProduit sp = new ServiceProduit();
        // GET: Product
        public ActionResult Index()
        {
            List<Produit> listproduit = Session["Produits"] as List<Produit>;
            var produits = sp.GetMany();
            return View(produits);
        }

        // GET: Product
        public ActionResult Index2()
        {
            List<Produit> listproduit = Session["Produits"] as List<Produit>;
            var produits = sp.GetMany();
            return View(produits);
        }
        // POST: Product
        [HttpPost]
        public ActionResult Index(string SearchString)
        {
            var produits = sp.GetMany(p => p.Nom.Contains(SearchString));
            return View(produits);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProduitModel pm = new ProduitModel();
            pm.Categories = sc.GetMany().Select(c => new SelectListItem()
            {
                Text = c.Nom,
                Value = c.CategorieId.ToString()
            });
            return View(pm);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProduitModel pm, HttpPostedFileBase Image)
        {
            pm.Image = Image.FileName;

            Produit p = new Produit()
            {
             
                Description = pm.Description,
                Image = pm.Image,
                Nom = pm.Nom,
                Prix = pm.Prix,
                Quantite = pm.Quantite,
                CategorieId = pm.CategorieId
            };
            //path image
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            /*List<Product> listproduct = Session["Products"] as List<Product>;
            if (listproduct==null)
            {
                listproduct = new List<Product>();
            }*/
            try
            {
                sp.Add(p);
                /*      listproduct.Add(p);
                      Session["Products"] = listproduct;*/
                sp.Commit();

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
            return View();
        }

        // POST: Produit/Edit/5
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

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produit/Delete/5
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
