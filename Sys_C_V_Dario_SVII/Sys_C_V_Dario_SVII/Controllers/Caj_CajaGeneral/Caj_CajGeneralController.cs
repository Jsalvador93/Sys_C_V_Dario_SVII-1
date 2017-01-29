using Sys_C_V_Dario_SVII.Models.Caj_CajGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_CajaGeneral
{
    public class Caj_CajGeneralController : Controller
    {
        // GET: Caj_CajaGeneral
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CPVNuevaCajGeneral()
        {
            return PartialView("_Nuevo");
        }

        [HttpPost]
        public JsonResult NuevaCajGeneral(Caj_CajGeneralBE objCajGeneral)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
                    bool result = objCajGeneralDA.InsertarRegistro(objCajGeneral);
                    return Json(new { Success = 1, result = result, ex = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se pudo Crear Este Registro").Message.ToString() });
        }
        [HttpPost]
        public JsonResult ConsultarCajGeneral(int in_idCajGeneral)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
                    Caj_CajGeneralBE objCajGeneral = objCajGeneralDA.ConsultarCajGeneral(in_idCajGeneral);
                    return Json(new { Success = 1, result = objCajGeneral, Exception = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Consultar este Registro").Message.ToString() });
        }

        [HttpPost]
        public ActionResult DetallesCajGeneral(int in_idCajGeneral)
        {
            Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
            Caj_CajGeneralBE objCajGeneral = objCajGeneralDA.ConsultarCajGeneral(in_idCajGeneral);
            return PartialView("_Detalle", objCajGeneral);
        }
        [HttpPost]
        public ActionResult CPVModificarCajGeneral(int in_idCajGeneral)
        {
            Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
            Caj_CajGeneralBE objCajGeneral = objCajGeneralDA.ConsultarCajGeneral(in_idCajGeneral);
            return PartialView("_Modificar", objCajGeneral);
        }
        [HttpPost]
        public JsonResult ModificarCajGeneral(Caj_CajGeneralBE objCajGeneral)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
                    return Json(new { Success = 1, resultado = objCajGeneralDA.ModificarCajGeneral(objCajGeneral), ex = "Se Modifico Correctamente este Registro!!" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Modificar este Registro").Message.ToString() });
        }
        [HttpPost]
        public ActionResult ListarCajGeneral(int _case, string filtro)
        {
            Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
            return PartialView("_ListarCajGeneral", objCajGeneralDA.ListarCajGeneral(_case, filtro));
        }
        [HttpPost]
        public ActionResult ListarCajGeneralFiltro(DateTime dt_fchDesde, DateTime dt_fchHasta)
        {
            Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
            return PartialView("_ListarCajGeneral", objCajGeneralDA.ListarCajGeneralIntervalo(dt_fchDesde, dt_fchHasta));
        }
        [HttpPost]
        public ActionResult CPVQuitarCajGeneral()
        {
            return PartialView("_Quitar");
        }
        [HttpPost]
        public JsonResult QuitarCajGeneral(Caj_CajGeneralBE objCajGeneral)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_CajGeneralDA objCajGeneralDA = new Caj_CajGeneralDA();
                    bool eval = objCajGeneralDA.QuitarCajGeneral(objCajGeneral);
                    return Json(new { Success = 1, result = eval, ex = (eval ? "" : "No ") + "Se Quito este Registro" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.ToString() });
            }
            return Json(new { Success = 0, ex = "No se Puede Quitar este Registro" });
        }
    }
}