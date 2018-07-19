using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_9_1_vj_Fakultet.Controllers
{
    public class KolegijController : Controller
    {
        // GET: Kolegij
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kolegij/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kolegij/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kolegij/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kolegij/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kolegij/Edit/5
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

        // GET: Kolegij/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kolegij/Delete/5
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
