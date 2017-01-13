using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Est_Estado;
using Sys_C_V_Dario_SVII.Models.Est_Tipo_Estado;

namespace Sys_C_V_Dario_SVII.Models.Est_TipEstDetalle
{
    public class Est_TipEstDetalleBE
    {
        public Est_EstadoBE objEst_Estado { get; set; }
        public Est_Tipo_EstadoBE objEst_Tipo_Estado { get; set; }
        public DateTime dt_fchRegistro { get; set; }

        public Est_TipEstDetalleBE()
        {
            objEst_Estado = new Est_EstadoBE();
            objEst_Tipo_Estado = new Est_Tipo_EstadoBE();
        }
    }
}