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
    public class ProduitController : Controller
    {

        ServiceProduit sp = new ServiceProduit();
        ServiceCategory sc = new ServiceCategory();
        ServiceBrand sb = new ServiceBrand();
        ServiceNetwork sn = new ServiceNetwork();
        ServiceProductStores sps = new ServiceProductStores();
        // GET: Product
  
        public ActionResult ProductList(string sortOrder, int? page, string SearchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            var products = sp.GetMany();
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Nom.Contains(SearchString)
                                       || s.Categorie.Nom.Contains(SearchString) || s.Brand.Nom.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "name_asc":
                    products = products.OrderBy(s => s.Nom);
                    break;
                default:
                    products = products.OrderBy(s => s.Nom);
                    break;

            }
            return View(products.ToPagedList(page ?? 1, 5));

        }

//        private ApplicationDbContext db = new ApplicationDbContext();

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
                BrandId = pm.BrandId,
                NetworkId = pm.NetworkId,
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
        public ActionResult Edit(int id, FormCollection collection, Product pp, HttpPostedFileBase Image)
        {


            try
            {
              
                    Product p = sp.GetById(id);
                p.Nom = pp.Nom;
                p.Prix = pp.Prix;
                p.Quantite = pp.Quantite;
                p.Description = pp.Description;
                    Debug.WriteLine(p);
                    sp.Update(p);
                    sp.Commit();


                
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

        public ActionResult Dashboard1()
        {
            var list = sp.GetMany();
            List<int> rep = new List<int>();

            var cat = list.Select(x => x.Categorie.Nom).Distinct();
            foreach(var item in cat)
            {
                rep.Add(list.Count(x => x.Categorie.Nom == item));

            }
            var r = rep;
            ViewBag.Cat = cat;
            ViewBag.R = rep.ToList();

    
            return View();

        }

        




        /// //////////////////////////FRONT CONTROLLER //////////////////////////////////////////


        // GET: Product front

        public ActionResult HomeFront(string sortOrder, int? page, string Selectedcat)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
           
            var rawData = sp.GetMany();
            var emp = from s in rawData
                      select s;

            if (!String.IsNullOrEmpty(Selectedcat))
            {
                emp = emp.Where(s => s.Categorie.Nom.Trim().Equals(Selectedcat.Trim()));
            }
           

            var Uniquecat = from s in emp
                                   group s by s.Categorie.Nom into newGroup
                                   where newGroup.Key != null
                                   orderby newGroup.Key
                                   select new { Categorie = newGroup.Key };
            ViewBag.Uniquecat = Uniquecat.Select(m => new SelectListItem { Value = m.Categorie, Text = m.Categorie }).ToList();

           
            ViewBag.Selectedcat = Selectedcat;
            switch (sortOrder)
            {
                case "name_asc":
                    emp = emp.OrderBy(s => s.Nom);
                    break;
                default:
                    emp = emp.OrderByDescending(s => s.Nom);
                    break;

            }
            return View(emp.ToPagedList(page ?? 1 , 8));

        }


        public ActionResult HomeFront2(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            var products = sp.GetMany();

            switch (sortOrder)
            {
                case "name_asc":
                    products = products.OrderBy(s => s.Nom);
                    break;
                default:
                    products = products.OrderBy(s => s.Nom);
                    break;

            }
            return View(products.ToPagedList(page ?? 1, 8));

        }
        public ActionResult Mobilelist()
        {
            var f = sp.mobile();
            
            return View(f);

        }
        public ActionResult Tabletlist()
        {
            var f = sp.Tablet();

            return View(f);

        }
        public ActionResult ADSLlist()
        {
            var f = sp.ADSL();
            

            return View(f);
        }

             public ActionResult FlyboxList()
        {
            var f = sp.Flybox();

            return View(f);

        }
    
    


        // GET: Product/Details/5
    /*    public ActionResult DetailsFront(int id)
        {
            var produits = sp.GetById(id);

            return View(produits);

        }*/

        public Product DetailsProduct(int id)
        {
            Product produits = sp.GetById(id);

            return produits;

        }

        // GET: Product/Details/5
        public List<ProductStore> Availability(int id)
        {

            List<ProductStore> produit = sps.list(id).ToList();
            return produit;

        }

        /* public ActionResult DetailsFront(int id)
         {
             dynamic dy = new ExpandoObject();
             dy.details = DetailsProduct(id);
             dy.availability = Availability(id);
             return View(dy);

         }*/

        public ActionResult DetailsFront(int id)
        {
            var details = DetailsProduct(id);
            var availability = Availability(id);
            var tuple = new Tuple<Product, List<ProductStore>>(details,availability);
            return View(tuple);
        }
        



    }
}