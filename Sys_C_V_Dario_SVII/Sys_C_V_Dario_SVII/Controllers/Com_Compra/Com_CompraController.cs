using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Compra;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Pedido;

namespace Sys_C_V_Dario_SVII.Controllers.Com_Compra
{
    public class Com_CompraController : Controller
    {
        // GET: Com_Compra
        public ActionResult Index()
        {
            Com_CompraDA objCompraDA = new Com_CompraDA();
            return View(objCompraDA.ListaRegistroCompra(0, ""));
        }

        [HttpPost]
        public ActionResult _modalDetalle(int i_idCompra)
        {
            string pDato = Convert.ToString(i_idCompra);
            Com_CompraDA objCompraDA = new Com_CompraDA();
            Com_CompraBE objCompraBE = new Com_CompraBE();
            foreach (Com_CompraBE objCompra in objCompraDA.ListaRegistroCompra(0, pDato))
            {
                objCompraBE = objCompra;
            }
            return PartialView("_modalDetalle", objCompraBE);
        }

        [HttpPost]
        public ActionResult _modalAgregarPedido(string a)
        {
            Com_PedidoDA objPedidoDA = new Com_PedidoDA();
            return PartialView("_modalAgregarPedido", objPedidoDA.ListaRegistroPedido(0, ""));
        }

        public ActionResult RegistrarCompra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _modalAgregarComprador(string a)
        {
            return PartialView("_modalAgregarComprador");
        }

        [HttpPost]
        public ActionResult _modalAgregarProveedor(string a)
        {
            return PartialView("_modalAgregarProveedor");
        }


    }
}