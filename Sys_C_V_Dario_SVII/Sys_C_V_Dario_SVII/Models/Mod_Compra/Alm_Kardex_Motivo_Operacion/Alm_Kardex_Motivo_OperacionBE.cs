using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Alm_Kardex_Motivo_Operacion
{
    public class Alm_Kardex_Motivo_OperacionBE
    {
        public int i_idMtvOperacion { get; set; }
        public string vc_dscpMtvOperacion { get; set; }
        public Alm_Kardex_Operacion.Alm_Kardex_OperacionBE oOpKardex { get; set; }

        public Alm_Kardex_Motivo_OperacionBE()
        {
            oOpKardex = new Alm_Kardex_Operacion.Alm_Kardex_OperacionBE();
        }
    }
}