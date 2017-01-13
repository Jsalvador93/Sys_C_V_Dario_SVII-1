using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Caj_Denominacion
{
    public class Caj_DenominacionBE
    {
        public int in_idDenominacion { get; set; }

        public bool bl_ver { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public string st_dscpDenominacion { get; set; }
    }
}