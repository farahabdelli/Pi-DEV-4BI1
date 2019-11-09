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
    
    public class CommandeLigneController : Controller
    {
        ServiceCommandeLigne scl = new ServiceCommandeLigne();
        // GET: CommandeLigne
        public ActionResult Index()
        {
            var commandelignes = scl.GetMany();
            return View(commandelignes);
        }

        // GET: CommandeLigne/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommandeLigne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommandeLigne/Create
        [HttpPost]
        public ActionResult Create(CommandeLigne cl)
        {
            try
            {

                scl.Add(cl);
                scl.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CommandeLigne/Edit/5
        public ActionResult Edit(int id)
        {
            CommandeLigne cl = scl.GetById(id);
            return View(cl);
        }

        // POST: CommandeLigne/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommandeLigne cl)
        {
            try
            {
                CommandeLigne clb = scl.GetById(id);
                clb.quantité=cl.quantité;
                Debug.WriteLine(clb);
                scl.Update(clb);
                scl.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CommandeLigne/Delete/5
        public ActionResult Delete(int id)
        {
         
                CommandeLigne cl = scl.GetById(id);
                scl.Delete(cl);
                scl.Commit();
                return RedirectToAction("Index");
           
        }

    }
}
