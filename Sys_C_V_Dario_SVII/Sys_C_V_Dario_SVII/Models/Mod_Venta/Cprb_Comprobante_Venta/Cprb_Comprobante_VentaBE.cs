using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Comprobante_Venta
{
    public class Cprb_Comprobante_VentaBE
    {
        public Cprb_Comprobante.Cprb_ComprobanteBE oComprobanteBE { get; set; }
        public Vta_Venta.Vta_VentaBE oVentaBE { get; set; }

        public Cprb_Comprobante_VentaBE()
        {
            oComprobanteBE = new Cprb_Comprobante.Cprb_ComprobanteBE();
            oVentaBE = new Vta_Venta.Vta_VentaBE();



        }





    }
}