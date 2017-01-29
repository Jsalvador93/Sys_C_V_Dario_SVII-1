using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Caj_LibroCaja;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_LibroCaja
{
    public class Caj_LibroCajaController : Controller
    {
        // GET: Caj_LibroCaja
        [HttpPost]
        public ActionResult LibroCajaGeneral( int _case , string filtro)
        {
            Caj_LibroCajaDA objLibroCajaDA = new Caj_LibroCajaDA();
            return PartialView( "_ListarLibroCaja" , objLibroCajaDA.ListarLibroCaja(_case ,filtro));
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