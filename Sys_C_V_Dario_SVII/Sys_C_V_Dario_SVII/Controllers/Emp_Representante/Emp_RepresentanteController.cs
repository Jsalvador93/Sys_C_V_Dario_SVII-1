using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys_C_V_Dario_SVII.Controllers.Emp_Representante
{
    public class Emp_RepresentanteController : Controller
    {
        // GET: Emp_Representante
        public ActionResult Index()
        {
            return View();
        }

        // GET: Emp_Representante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emp_Representante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp_Representante/Create
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

        // GET: Emp_Representante/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Emp_Representante/Edit/5
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

        // GET: Emp_Representante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Emp_Representante/Delete/5
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
