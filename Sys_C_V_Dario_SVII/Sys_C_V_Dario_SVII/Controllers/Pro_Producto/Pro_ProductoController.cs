using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Marca;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Seccion;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Tipo_Producto;

namespace Sys_C_V_Dario_SVII.Controllers.Pro_Producto
{
    public class Pro_ProductoController : Controller
    {
        // GET: Pro_Producto
        public ActionResult Index()
        {
            Pro_ProductoDA objProductoDA = new Pro_ProductoDA();
            return View(objProductoDA.ListaRegistroProducto(0, ""));
        }

        [HttpPost]
        public ActionResult _modalPrecio( string c_codProducto)
        {
            //string dato = "1";
            Pro_ProductoDA objProductoDA = new Pro_ProductoDA();
            Pro_ProductoBE objProductoBE = new Pro_ProductoBE();
            foreach (Pro_ProductoBE objProducto in objProductoDA.ListaRegistroProducto(0, c_codProducto))
            {
                objProductoBE = objProducto;
            }
            return PartialView("_modalPrecio", objProductoBE);

        }

        [HttpPost]
        public ActionResult _modalMarca(string a)
        {
            Pro_MarcaDA objMarcaDA = new Pro_MarcaDA();
            return PartialView("_modalMarca", objMarcaDA.ListaRegistroMarca(""));
        }

        [HttpPost]
        public ActionResult _modalSeccion(string a)
        {
            Pro_SeccionDA objSeccionDA = new Pro_SeccionDA();
            return PartialView("_modalSeccion", objSeccionDA.ListaRegistroSeccion(""));
        }

        [HttpPost]
        public ActionResult _modalTipoProducto(string a)
        {
            Pro_Tipo_ProductoDA objTipo_ProductoDA = new Pro_Tipo_ProductoDA();
            return PartialView("_modalTipoProducto", objTipo_ProductoDA.ListaRegistroTipoProducto(""));
        }

        public ActionResult RegistrarProducto()
        {
            
            return View();
        }
    }
}