using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Mod_Venta.Vta_Venta;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto;

namespace Sys_C_V_Dario_SVII.Controllers.Vta_Venta
{
    public class Vta_VentaController : Controller
    {
        // GET: Vta_Venta

        public ActionResult Index()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult _modalDetalle(int i_idVenta)
        {
            string pDato = Convert.ToString(i_idVenta);
            Vta_VentaDA objVentaDA = new Vta_VentaDA();
            Vta_VentaBE objVentaBE = new Vta_VentaBE();
            foreach (Vta_VentaBE objVenta in objVentaDA.ListaRegistroVenta(0, pDato))
            {
                objVentaBE = objVenta;
            }
            return PartialView("_modalDetalle", objVentaBE);
        }

        [HttpPost]
        public ActionResult _modalGenerar(int i_idVenta)
        {
            string pDato = Convert.ToString(i_idVenta);
            Vta_VentaDA objVentaDA = new Vta_VentaDA();
            Vta_VentaBE objVentaBE = new Vta_VentaBE();
            foreach (Vta_VentaBE objVenta in objVentaDA.ListaRegistroVenta(0, pDato))
            {
                objVentaBE = objVenta;
            }
            return PartialView("_modalGenerar", objVentaBE);
        }

        [HttpPost]
        public ActionResult _modalSeleccionarProducto()
        {
            return PartialView("_modalSeleccionarProducto");
        }

        [HttpPost]
        public ActionResult ListarProducto(int _case, string filtro)
        {
            Pro_ProductoDA objProductoDA = new Pro_ProductoDA();
            return PartialView("ListarProducto", objProductoDA.ListaRegistroProducto(_case, filtro));
        }

        public ActionResult RegistrarVenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _modalAgregarCliente()
        {
            return PartialView("_modalAgregarCliente");
        }

        [HttpPost]
        public ActionResult ListarVenta(int _case, string filtro)
        {
            Vta_VentaDA objVentaDA = new Vta_VentaDA();
            return PartialView("ListarVenta", objVentaDA.ListaRegistroVenta(_case, filtro));
        }

    }
}