using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Modulo;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Interfaz
{
    public class InterfazBE
    {
        public int in_idInterfaz { get; set; }
        public string st_itfzNombre { get; set; }
        public ModuloBE oModuloBE { get; set; }

        public InterfazBE()
        {
            oModuloBE = new ModuloBE();
        }
    }
}