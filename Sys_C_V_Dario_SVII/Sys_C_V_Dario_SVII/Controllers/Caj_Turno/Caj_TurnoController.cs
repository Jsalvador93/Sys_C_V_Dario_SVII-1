using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Caj_Turno;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_Turno
{
    public class Caj_TurnoController : Controller
    {
        // GET: Caj_Tujrno
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CPVNuevaTurno()
        {
            return PartialView("_Nuevo");
        }
        [HttpPost]
        public JsonResult NuevaTurno(Caj_TurnoBE objTurno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_TurnoDA objTurnoDA = new Caj_TurnoDA();
                    bool eval = objTurnoDA.InsertarRegistro(objTurno);
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
        public ActionResult CPVQuitarTurno()
        {
            return PartialView("_Quitar");
        }
        [HttpPost]
        public JsonResult QuitarTurno(Caj_TurnoBE objTurno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_TurnoDA objTurnoDA = new Caj_TurnoDA();
                    bool eval = objTurnoDA.QuitarTurno(objTurno);
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
        public ActionResult DetallesTurno(int in_idTurno)
        {
            Caj_TurnoDA objTurnoDA = new Caj_TurnoDA();
            return PartialView("_Detalle", objTurnoDA.ConsultarTurno(in_idTurno));
        }
        [HttpPost]
        public ActionResult CPVModificarTurno(int in_idTurno)
        {
            Caj_TurnoDA objTurnoDA = new Caj_TurnoDA();
            return PartialView("_Modificar", objTurnoDA.ConsultarTurno(in_idTurno));
        }
        [HttpPost]
        public JsonResult ModificarTurno(Caj_TurnoBE objTurno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_TurnoDA objTurnoDA = new Caj_TurnoDA();
                    bool eval = objTurnoDA.ModificarTurno(objTurno);
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
        public ActionResult ListarTurno(int _case, string filtro)
        {
            Caj_TurnoDA objTurnoDA = new Caj_TurnoDA();

            return PartialView("_ListarTurno", objTurnoDA.ListarTurno(_case, filtro));
        }
    }
}