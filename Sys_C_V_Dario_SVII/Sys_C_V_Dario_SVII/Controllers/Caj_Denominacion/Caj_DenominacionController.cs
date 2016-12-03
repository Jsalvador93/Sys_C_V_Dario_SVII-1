using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Caj_Denominacion;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_Denominacion
{
    public class Caj_DenominacionController : Controller
    {
        // GET: Caj_Denominacion
        public ActionResult Index()
        {
            Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();

            return View(objDenominacionDA.ListarDenominacion( -1 , "''"));
        }
    }
}