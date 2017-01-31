using Sys_C_V_Dario_SVII.Models.Rol_Modulo;
using Sys_C_V_Dario_SVII.Models.Rol_Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Rol_Funcion_Usuario
{
    public class Rol_Funcion_UsuarioBE
    {
        public DateTime dt_fchRol { get; set; }
        public List<Rol_UsuarioBE> objListUsuario { get; set; }
        public List<Rol_ModuloBE> objListModulo { get; set; }
       

    }
}