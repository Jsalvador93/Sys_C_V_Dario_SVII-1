using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Rol;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Pers_Persona;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Emp_Empresa;
w
namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Rol_Usuario
{
    public class RolUsuarioBE
    {
        public int in_idUsuario { get; set; }
        public DateTime dt_fchRgtrUsuario { get; set; }
        public string st_username { get; set; }
        public string st_password { get; set; }
        public RolBE oRolBE { get; set; }
        public PersonaBE oPersonaBE { get; set; }
        public EmpresaBE oEmpresaBE { get; set; }

        public RolUsuarioBE()
        {
            oRolBE = new RolBE();
            oPersonaBE = new PersonaBE();
            oEmpresaBE = new EmpresaBE();
        }

    }
}