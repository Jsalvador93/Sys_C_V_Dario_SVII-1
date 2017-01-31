using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Interfaz;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Rol;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Rol_Interfaz
{
    public class RolInterfazBE
    {
        public int in_idRolInterfaz { get; set; }
        public DateTime dt_RolInterfaz { get; set; }
        public InterfazBE oInterfazBE { get; set; }
        public RolBE oRolBE { get; set; }

        public RolInterfazBE()
        {
            oInterfazBE = new InterfazBE();
            oRolBE = new RolBE();
        }

    }
}