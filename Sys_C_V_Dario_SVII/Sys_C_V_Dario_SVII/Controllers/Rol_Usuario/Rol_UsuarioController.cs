﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys_C_V_Dario_SVII.Controllers.Rol_Usuario
{
    public class Rol_UsuarioController : Controller
    {
        // GET: Rol_Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rol_Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rol_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol_Usuario/Create
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

        // GET: Rol_Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rol_Usuario/Edit/5
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

        // GET: Rol_Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rol_Usuario/Delete/5
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
