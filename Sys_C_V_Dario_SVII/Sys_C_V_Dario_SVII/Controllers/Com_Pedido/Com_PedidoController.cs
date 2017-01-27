using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Pedido;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto;

namespace Sys_C_V_Dario_SVII.Controllers.Com_Pedido
{
    public class Com_PedidoController : Controller
    {
        // GET: Com_Pedido
        public ActionResult Index()
        {
            Com_PedidoDA objVentaDA = new Com_PedidoDA();
            return View(objVentaDA.ListaRegistroPedido(0, ""));
        }

        [HttpPost]
        public ActionResult _modalDetalle(int i_idPedido)
        {
            string pDato = Convert.ToString(i_idPedido);
            Com_PedidoDA objPedidoDA = new Com_PedidoDA();
            Com_PedidoBE objPedidoBE = new Com_PedidoBE();
            foreach (Com_PedidoBE objPedido in objPedidoDA.ListaRegistroPedido(0, pDato))
            {
                objPedidoBE = objPedido;
            }
            return PartialView("_modalDetalle", objPedidoBE);
        }

        [HttpPost]
        public ActionResult _modalListaProductos(string a)
        {
            Pro_ProductoDA objProductoDA = new Pro_ProductoDA();
            return PartialView("_modalListaProductos", objProductoDA.ListaRegistroProducto(0, ""));
        }

        public ActionResult RegistrarPedidos()
        {
            return View();
        }
    }
}