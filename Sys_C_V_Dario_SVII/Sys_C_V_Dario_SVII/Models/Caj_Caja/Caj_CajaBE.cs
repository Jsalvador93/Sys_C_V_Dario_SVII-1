using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Emp_PtoVenta;

using Sys_C_V_Dario_SVII.Models.Emp_Sucursal;

namespace Sys_C_V_Dario_SVII.Models.Caj_Caja
{
    public class Caj_CajaBE
    {
        public int in_idCaja { get; set; }
        public bool bl_ver { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public DateTime dt_fchIngreso { get; set; }
        public string st_dscpCaja { get; set; }
        public Emp_PtoVentaBE objPtoVenta { get; set; }
        public Emp_SucursalBE objSucursal { get; set; }

        public Caj_CajaBE()
        {
            objPtoVenta = new Emp_PtoVentaBE();
            objSucursal = new Emp_SucursalBE();
        }
}
}