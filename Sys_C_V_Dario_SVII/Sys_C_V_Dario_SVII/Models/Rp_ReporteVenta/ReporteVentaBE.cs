using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Venta.Vta_Venta;

namespace Sys_C_V_Dario_SVII.Models.Rp_ReporteVenta
{
    public class ReporteVentaBE
    {
        public Vta_VentaBE objVentaBE { get; set; }

        public ReporteVentaBE()
        {
            objVentaBE = new Vta_VentaBE();
        }
    }
}