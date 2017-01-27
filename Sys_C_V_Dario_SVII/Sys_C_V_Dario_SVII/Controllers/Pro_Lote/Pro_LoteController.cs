using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Lote;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto;

namespace Sys_C_V_Dario_SVII.Controllers.Pro_Lote
{
    public class Pro_LoteController : Controller
    {
        // GET: Pro_Lote
        public ActionResult Index()
        {
            Pro_LoteDA objLoteDA = new Pro_LoteDA();
            return View(objLoteDA.ListaRegistroLote(0, ""));
        }

        [HttpPost]
        public ActionResult _modalDetalle(byte i_idLote)
        {
            string pDato = Convert.ToString(i_idLote);
            Pro_LoteDA objLoteDA = new Pro_LoteDA();
            Pro_LoteBE objLoteBE = new Pro_LoteBE();
            foreach (Pro_LoteBE objLote in objLoteDA.ListaRegistroLote(0,pDato))
            {
                objLoteBE = objLote;
            }
            return PartialView("_modalDetalle", objLoteBE);
        }

        public ActionResult RegistrarLote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _modalSeleccionarProducto(string a)
        {
            Pro_ProductoDA objProductoDA = new Pro_ProductoDA();
            return PartialView("_modalSeleccionarProducto", objProductoDA.ListaRegistroProducto(0, ""));
        }

    }
}