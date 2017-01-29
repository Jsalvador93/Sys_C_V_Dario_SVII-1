using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Rp_ReporteProducto;

namespace Sys_C_V_Dario_SVII.Controllers.Rp_ReporteProducto
{
    public class Rp_ReporteProductoController : Controller
    {
        // GET: Rp_ReporteProducto
        public ActionResult Index()
        {
            ReporteProductoDA objRPDA = new ReporteProductoDA();
            return View(objRPDA.ListarProductoReporte(0,""));
        }
    }
}