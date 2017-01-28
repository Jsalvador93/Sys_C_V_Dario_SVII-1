using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Caj_CajGeneral
{
    public class Caj_CajGeneralBE
    {

        public int in_idCajGeneral { get; set; }
        public DateTime dt_fchInicio { get; set; } //date
        public DateTime dt_fchFin { get; set; } // date
        public float fl_mntCajChica { get; set; }
        public float fl_mntSdoCaja { get; set; }
        public DateTime dt_fchRegistro { get; set; } // date
        public Boolean bl_ver { get; set; }
    }
}