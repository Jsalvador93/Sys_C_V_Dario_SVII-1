using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Caj_Caja;
using Sys_C_V_Dario_SVII.Models.Emp_Sucursal;
using Sys_C_V_Dario_SVII.Models.Emp_PtoVenta;

namespace Sys_C_V_Dario_SVII.Controllers.Caj_Caja
{
    public class Caj_CajaController : Controller
    {
        // GET: Caj_caja
        [HttpPost]
        //CPV cargar partialview
        public ActionResult CPVNuevaCaja()
        {
            return PartialView("_Nuevo");
        }
        [HttpPost]
        public JsonResult NuevaCaja(Caj_CajaBE objCaja)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_CajaDA objCajaDA = new Caj_CajaDA();
                    bool result = objCajaDA.RegistrarCaja(objCaja);
                    return Json(new { Success = 1, resultado = result, ex = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se pudo Crear Este Registro").Message.ToString() }); 
        }

        [HttpPost]
        public JsonResult ConsultarCaja( int in_idCaja )
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Caj_CajaDA objCajaDA = new Caj_CajaDA();
                    Caj_CajaBE objCaja = objCajaDA.ConsultarCaja(in_idCaja);
                    return Json(new { Success = 1, resultado = objCaja, Exception = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Consultar este Registro").Message.ToString() });
        }

        [HttpPost]
        public ActionResult DetallesCaja( int in_idCaja)
        {
            Caj_CajaDA objCajaDA = new Caj_CajaDA();
            Caj_CajaBE objCaja = objCajaDA.ConsultarCaja(in_idCaja);
            return PartialView("_Detalles", objCaja);
        }
        [HttpPost]
        public ActionResult CargarModificarCaja(int in_idCaja)
        {
            Caj_CajaDA objCajaDA = new Caj_CajaDA();
            Caj_CajaBE objCaja = objCajaDA.ConsultarCaja(in_idCaja);
            return PartialView("_Modificar", objCaja);
        }
        [HttpPost]
        public JsonResult ConsultarCaja(Caj_CajaBE objCaja , int in_idCaja )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_CajaDA objCajaDA = new Caj_CajaDA();
                    return Json(new { Success = 1, resultado = objCajaDA.ModificarCaja(objCaja), ex = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Visualizar este Registro").Message.ToString() });
        }
        public JsonResult ModificarCaja(Caj_CajaBE objCaja)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Caj_CajaDA objCajaDA = new Caj_CajaDA();
                    return Json(new { Success = 1, resultado = objCajaDA.ModificarCaja(objCaja), ex = "Se Modifico Correctamente este Registro!!" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Modificar este Registro").Message.ToString() });
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarCaja( int _case , string filtro )
        {
            Caj_CajaDA objCajaDA = new Caj_CajaDA();
            return PartialView("_ListarCaja", objCajaDA.ListarCaja( _case , filtro ));
        }

        [HttpPost]
        public JsonResult cargarCboSucursal( int _case )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Emp_SucursalDA objSucursalDA = new Emp_SucursalDA();
                    return Json(new { Success = 1, resultado = objSucursalDA.ListarSucursal(_case , "''"), Exception = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Listar el Combo").Message.ToString() });
        }

        [HttpPost]
        public JsonResult cargarCboPtoVenta( int in_idSucursal )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Emp_PtoVentaDA objPtoVentaDA = new Emp_PtoVentaDA();
                    List<Emp_PtoVentaBE> objPtoSucursal = new List<Emp_PtoVentaBE>();
                    foreach( var item in objPtoVentaDA.ListarPtoVenta( 0 , "''"))
                    {
                        if( item.objSucursal.in_idSucursal == in_idSucursal )
                        {
                            objPtoSucursal.Add( item );
                        }
                    }
                    return Json(new { Success = 1, resultado = objPtoSucursal, Exception = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = 0, ex = e.Message.ToString() });
            }
            return Json(new { Success = 0, ex = new Exception("No se puede Listar el Combo").Message.ToString() });
        }

        /*public ActionResult GetPtoVenta( int idSucursal )
        {
            Emp_PtoVentaDA objPtoVentaDA = new Emp_PtoVentaDA();
            List<Emp_PtoVentaBE> objListPtoVenta = new List<Emp_PtoVentaBE>();
            foreach(var item in objPtoVentaDA.ListarPtoVenta(0 , "''"))
            {
                if( item.objSucursal.in_idSucursal == idSucursal )
                {
                    objListPtoVenta.Add(item);
                }
            }
        }*/
    }
}