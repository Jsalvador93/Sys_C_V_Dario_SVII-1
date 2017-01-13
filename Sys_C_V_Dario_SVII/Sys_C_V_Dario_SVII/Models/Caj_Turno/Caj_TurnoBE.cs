using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Caj_Turno
{
    public class Caj_TurnoBE
    {
        public int in_idTurno { get; set; }
        public bool bl_ver { get; set; }
        public string st_dscpTurno { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public string st_hrInicio { get; set; }
        public string st_hrFin { get; set; }
    }
}