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
            return View();
        }

        [HttpPost]
        public ActionResult CPVNuevaDenominacion()
        {
            return PartialView("_Nuevo");
        }
        [HttpPost]
        public JsonResult NuevaDenominacion(Caj_DenominacionBE objDenominacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();
                    bool eval = objDenominacionDA.InsertarRegistro(objDenominacion);
                    return Json(new { Success = 1, result = eval , ex = (eval ? "":"No ") + "Se Guardo Correctamente este Registro"  });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.ToString() });
            }
            return Json(new { Success = 0, ex = "No se Pudo Grabar este Registro" });
        }
        [HttpPost]
        public ActionResult CPVQuitarDenominacion()
        {
            return PartialView("_Quitar");
        }
        [HttpPost]
        public JsonResult QuitarDenominacion( Caj_DenominacionBE objDenominacion )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();
                    bool eval = objDenominacionDA.QuitarDenominacion(objDenominacion);
                    return Json(new { Success = 1, result = eval, ex = (eval ? "" : "No ") + "Se Quito este Registro" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.ToString() });
            }
            return Json(new { Success = 0, ex = "No se Puede Quitar este Registro" });
        }
        [HttpPost]
        public ActionResult DetallesDenominacion( int in_idDenominacion)
        {
            Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();
            return PartialView("_Detalle", objDenominacionDA.ConsultarDenominacion(in_idDenominacion)) ;
        }
        [HttpPost]
        public ActionResult CPVModificarDenominacion( int in_idDenominacion)
        {
            Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();
            return PartialView("_Modificar", objDenominacionDA.ConsultarDenominacion(in_idDenominacion));
        }
        [HttpPost]
        public JsonResult ModificarDenominacion(Caj_DenominacionBE objDenominacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();
                    bool eval = objDenominacionDA.ModificarDenominacion(objDenominacion);
                    return Json(new { Success = 1, result = eval , ex = (eval ? "Se " : "No Se ") +"Modifico este Registro" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.ToString() });
            }
            return Json(new { Success = 0, ex = "No se Puede Modificar este Registro" });
        }
        [HttpPost]
        public ActionResult ListarDenominacion( int _case , string filtro )
        {
            Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();

            return PartialView("_ListarDenominacion",objDenominacionDA.ListarDenominacion( _case , filtro));
        }

    }
}