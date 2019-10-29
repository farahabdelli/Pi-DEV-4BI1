using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domaine;
using projetPIWeb.Models;
using System.IO;
using Services;
using PagedList;
using System;

namespace projetPIWeb.Controllers
{
    public class ProduitController : Controller
    {

        ServiceProduit sp = new ServiceProduit();
        ServiceCategory sc = new ServiceCategory();
        ServiceBrand sb = new ServiceBrand();
        ServiceNetwork sn = new ServiceNetwork();
        // GET: Product
        public ActionResult ProductList( string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nom_desc" : "";

            List<Product> listproduit = Session["Produits"] as List<Product>;
            var produits = sp.GetMany();

            switch (sortOrder)
            {
                case "name_desc":
                    produits = produits.OrderByDescending(s => s.Nom);
                    break;
                
                default:
                    produits = produits.OrderBy(s => s.Nom);
                    break;
            }
            return View(produits);
          
        }
       
        // GET: Product
        public ActionResult Index2()
        {
            List<Product> listproduit = Session["Produits"] as List<Product>;
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
            var produits = sp.GetById(id);
            return View(produits);
          
        }

        // GET: Product/Create
        public ActionResult CreateProduct()
        {
            ProduitModel pm = new ProduitModel();
            pm.Categories = sc.GetMany().Select(c => new SelectListItem()
            {
                Text = c.Nom,
                Value = c.CategorieId.ToString()
            });
            pm.Brands = sb.GetMany().Select(c => new SelectListItem()
            {
                Text = c.Nom,
                Value = c.BrandId.ToString()
            });
            pm.Networks = sn.GetMany().Select(c => new SelectListItem()
            {
                Text = c.Nom,
                Value = c.NetworkId.ToString()
            });
            return View(pm);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult CreateProduct(ProduitModel pm, HttpPostedFileBase Image)
        {
            pm.Image = Image.FileName;

            Product p = new Product()
            {

                Description = pm.Description,
                Image = pm.Image,
                Nom = pm.Nom,
                CategorieId = pm.CategorieId,
                BrandId=pm.BrandId,
                NetworkId=pm.NetworkId,
                Prix = pm.Prix,
                Quantite = pm.Quantite,
               
            };
            //path image
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
           
            try
            {
                sp.Add(p);
                /*      listproduct.Add(p);
                      Session["Products"] = listproduct;*/
                sp.Commit();

                return RedirectToAction("ProductList");
            }
            catch
            {
                return View();
            }
        }


        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            var produits = sp.GetById(id);
            return View(produits);
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,ProduitModel pm, HttpPostedFileBase Image)
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

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            var produits = sp.GetById(id);
            return View(produits);
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
                
                
                return RedirectToAction("ProductList");
            }
            catch
            {
                return View();
            }
        }
    }
}