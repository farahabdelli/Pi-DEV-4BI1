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
using System.Diagnostics;

namespace projetPIWeb.Controllers
{
    public class QuestionController : Controller
    {
        ServiceQuestion sb = new ServiceQuestion();

        // GET: Questions

        public ActionResult Index()
        {
            var question = sb.GetMany();
            return View(question);

        }

        // GET: Questions/Details/5
        public ActionResult DetailsQuestion(int id)
        {
            var s = sb.GetById(id);
            s.NbVues = s.NbVues + 1;
            return View(s);
        }
        public ActionResult LikeQuestion(int id)
        {
            var s = sb.GetById(id);
            s.NbLikes = s.NbLikes + 1;
            var question = sb.GetMany();
            return View(question);
        }
        public ActionResult DisikeQuestion(int id)
        {
            var s = sb.GetById(id);
            s.NbDislikes = s.NbDislikes + 1;
            var question = sb.GetMany();
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult CreateQuestion()
        {
            QuestionModel pm = new QuestionModel();
            return View(pm);

        }

        // POST: Product/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateQuestion(QuestionModel pm)
        {
            Question p = new Question()
            {
                Titre = pm.Titre,
                Description = pm.Description,
                DatePost = pm.DatePost,
                NbVues = pm.NbVues,
                NbLikes = pm.NbLikes,
                NbDislikes = pm.NbDislikes,
                

            };
        

            
                sb.Add(p);
                /*      listproduct.Add(p);
                      Session["Products"] = listproduct;*/
                sb.Commit();

                return RedirectToAction("Index");
           



        }


        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question cl)
        {
            try
            {
                Question clb = sb.GetById(id);
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

    

    // GET: Questions/Delete/5
    public ActionResult DeleteQuestion(int id)
        {
            var s = sb.GetById(id);
            return View(s);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult DeleteQuestion(int id, FormCollection collection)
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

        public ActionResult Statistique()
        {
            var question = sb.GetMany();
            return View(question);

        }






    }
   
}
