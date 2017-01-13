using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Caj_Denominacion;

namespace Sys_C_V_Dario_SVII.Models.Caj_Concepto
{
    public class Caj_ConceptoBE
    {
        public int in_idConcepto { get; set; }

        public bool  bl_ver { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public string st_dscpConcepto { get; set; }
        public Caj_DenominacionBE objDenominacionBE { get; set; }

        public Caj_ConceptoBE() {
            objDenominacionBE = new Caj_DenominacionBE();
        }

    }
}