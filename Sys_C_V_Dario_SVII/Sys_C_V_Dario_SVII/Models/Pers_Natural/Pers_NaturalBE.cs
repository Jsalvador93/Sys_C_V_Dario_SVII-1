using Sys_C_V_Dario_SVII.Models.Pers_Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Pers_Natural
{
    public class Pers_NaturalBE
    {
        public char c_dni { get; set; }
        public string st_apPaterno { get; set; }
        public string st_apMaterno { get; set; }
        public byte  by_sexo { get; set; }

        public List<Pers_PersonaBE> objListPersona { get; set; }

    }
}