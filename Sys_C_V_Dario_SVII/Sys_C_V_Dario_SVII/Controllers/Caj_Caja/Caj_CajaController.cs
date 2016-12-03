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
        public ActionResult Index()
        {
            Caj_CajaDA objCajaDA = new Caj_CajaDA();
            Emp_SucursalDA objSucursalDA = new Emp_SucursalDA();
            Emp_SucursalBE objSucursal = new Emp_SucursalBE();
            List<SelectListItem> objListSelectListSucursal = new List<SelectListItem>();
            objListSelectListSucursal.Add(new SelectListItem() { Value = "0", Text = "Todos...", Selected = true });
            foreach( var item in objSucursalDA.ListarSucursal(0, "''"))
            {

                objListSelectListSucursal.Add(new SelectListItem() { Value = item.in_idSucursal + "", Text = item.st_dscpSucursal + "", Selected = false });
            }
            ViewBag.objListSelectListSucursal = objListSelectListSucursal ;
            return View(objCajaDA.ListarCaja(-1, "''"));
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