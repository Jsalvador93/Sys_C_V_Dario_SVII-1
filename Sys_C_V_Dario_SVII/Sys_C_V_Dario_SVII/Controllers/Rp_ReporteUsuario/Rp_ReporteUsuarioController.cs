using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Rp_ReporteUsuario;

namespace Sys_C_V_Dario_SVII.Controllers.Rp_ReporteUsuario
{
    public class Rp_ReporteUsuarioController : Controller
    {
        // GET: Rp_ReporteUsuario
        public ActionResult Index()
        {
            ReporteUsuarioDA oRUDA = new ReporteUsuarioDA();
            return View(oRUDA.ListarUsuarioReporte(0,""));
        }
    }
}