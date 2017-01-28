using Sys_C_V_Dario_SVII.Models.Caj_Concepto;
using Sys_C_V_Dario_SVII.Models.Cprb_TipComprobante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_Movimiento
{
    public class Caj_MovimientoController : Controller
    {
        // GET: Caj_Movimiento
        //Seccion RegistrarIngresoEgreso
        public ActionResult RegistrarIngresoEgreso()
        {
            return View();
        }
        [HttpPost]
        public JsonResult cargarCboConcepto(int _case, string filtro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_ConceptoDA objConceptoDA = new Caj_ConceptoDA();
                    return Json(new { Success = 1, resultado = objConceptoDA.ListarConcepto(_case, filtro), Exception = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Listar el Combo").Message.ToString() });
        }
            public JsonResult cargarcboTipComprobante(int _case, string filtro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cprb_TipComprobanteDA objTipComprobanteDA =new  Cprb_TipComprobanteDA();
                    return Json(new { Success = 1, resultado = objTipComprobanteDA.ListarTipcomprobante(_case, filtro), Exception = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Listar el Combo").Message.ToString() });
        }
        [HttpPost]
        public ActionResult CPVQuitarRegistro()
        {
            return PartialView("_QuitarIngresoEgreso");
        }
        //Seccion  BuscarMovimiento
        public ActionResult BuscarMovimiento()
        {
            return View();
        }
        //Seccion VerMovimientos
        public ActionResult VerMovimientos()
        {
            return View();
        }

    }
}