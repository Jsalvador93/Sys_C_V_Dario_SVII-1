using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Caj_Concepto;
using Sys_C_V_Dario_SVII.Models.Caj_Denominacion;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_Concepto
{
    public class Caj_ConceptoController : Controller
    {
        // GET: Caj_Concepto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CPVNuevaConcepto()
        {
            return PartialView("_Nuevo");
        }
        [HttpPost]
        public JsonResult NuevaConcepto(Caj_ConceptoBE objConcepto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_ConceptoDA objConceptoDA = new Caj_ConceptoDA();
                    bool eval = objConceptoDA.InsertarRegistro(objConcepto);
                    return Json(new { Success = 1, result = eval, ex = (eval ? "" : "No ") + "Se Guardo Correctamente este Registro" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.ToString() });
            }
            return Json(new { Success = 0, ex = "No se Pudo Grabar este Registro" });
        }
        [HttpPost]
        public ActionResult CPVQuitarConcepto()
        {
            return PartialView("_Quitar");
        }
        [HttpPost]
        public JsonResult QuitarConcepto(Caj_ConceptoBE objConcepto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_ConceptoDA objConceptoDA = new Caj_ConceptoDA();
                    bool eval = objConceptoDA.QuitarConcepto(objConcepto);
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
        public ActionResult DetallesConcepto(int in_idConcepto)
        {
            Caj_ConceptoDA objConceptoDA = new Caj_ConceptoDA();
            return PartialView("_Detalle", objConceptoDA.ConsultarConcepto(in_idConcepto));
        }
        [HttpPost]
        public ActionResult CPVModificarConcepto(int in_idConcepto)
        {
            Caj_ConceptoDA objConceptoDA = new Caj_ConceptoDA();
            return PartialView("_Modificar", objConceptoDA.ConsultarConcepto(in_idConcepto));
        }
        [HttpPost]
        public JsonResult ModificarConcepto(Caj_ConceptoBE objConcepto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_ConceptoDA objConceptoDA = new Caj_ConceptoDA();
                    bool eval = objConceptoDA.ModificarConcepto(objConcepto);
                    return Json(new { Success = 1, result = eval, ex = (eval ? "Se " : "No Se ") + "Modifico este Registro" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.ToString() });
            }
            return Json(new { Success = 0, ex = "No se Puede Modificar este Registro" });
        }
        [HttpPost]
        public ActionResult ListarConcepto(int _case, string filtro)
        {
            Caj_ConceptoDA objConceptoDA = new Caj_ConceptoDA();

            return PartialView("_ListarConcepto", objConceptoDA.ListarConcepto(_case, filtro));
        }
        
        [HttpPost]
        public JsonResult cargarCboDenominacion(int _case, string filtro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_DenominacionDA objDenominacionDA = new Caj_DenominacionDA();
                    return Json(new { Success = 1, resultado = objDenominacionDA.ListarDenominacion(_case, filtro), Exception = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Listar el Combo").Message.ToString() });
        }
    }
}