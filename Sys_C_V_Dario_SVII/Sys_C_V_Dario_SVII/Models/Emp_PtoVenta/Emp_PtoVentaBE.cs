using Sys_C_V_Dario_SVII.Models.Emp_Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Emp_PtoVenta
{
    public class Emp_PtoVentaBE
    {
        public int in_idPtoVenta { get; set; }
        public string st_dscpPtoVenta { get; set; }
        public DateTime dt_fchRegistro { get; set; }

        public Emp_SucursalBE objSucursal { get; set; }

        public Emp_PtoVentaBE()
        {
            objSucursal = new Emp_SucursalBE();
        }
}
}