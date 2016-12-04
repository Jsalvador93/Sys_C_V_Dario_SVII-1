using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys_C_V_Dario_SVII.Controllers.Pers_Persona
{
    public class Pers_PersonaController : Controller
    {
        // GET: Pers_Persona
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pers_Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pers_Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pers_Persona/Create
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

        // GET: Pers_Persona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pers_Persona/Edit/5
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

        // GET: Pers_Persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pers_Persona/Delete/5
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
