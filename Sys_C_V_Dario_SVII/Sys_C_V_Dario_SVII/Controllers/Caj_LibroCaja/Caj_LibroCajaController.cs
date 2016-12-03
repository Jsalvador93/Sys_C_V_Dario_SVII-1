using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_LibroCaja
{
    public class Caj_LibroCajaController : Controller
    {
        // GET: Caj_LibroCaja
        public ActionResult LibroCajaGeneral()
        {
            return View();
        }
        public ActionResult LibroCajaSucursal()
        {
            return View();
        }

        public ActionResult LibroCajaPtoVenta()
        {
            return View();
        }
    }
}