using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Usuario;
namespace Sys_C_V_Dario_SVII.Models.Rp_ReporteUsuario
{
    public class ReporteUsuarioBE
    {
        public Rol_UsuarioBE objRolUsuarioBE { get; set; }

        public ReporteUsuarioBE()
        {
            objRolUsuarioBE = new Rol_UsuarioBE();
        }
    }
}