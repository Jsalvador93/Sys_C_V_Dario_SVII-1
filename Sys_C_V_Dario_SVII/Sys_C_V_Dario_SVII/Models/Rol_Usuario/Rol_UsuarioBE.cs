using Sys_C_V_Dario_SVII.Models.Emp_Empresa;
using Sys_C_V_Dario_SVII.Models.Pers_Persona;
using Sys_C_V_Dario_SVII.Models.Rol_Tipo_Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Rol_Usuario
{
    public class Rol_UsuarioBE
    {
        public string st_codUsuario { get; set; }
        public string st_password { get; set; }
        public DateTime dt_fchaRgtrUsuario { get; set; }
        public List<Rol_Tipo_UsuarioBE> objListTipoUsuario { get; set; }
        public  List<Emp_EmpresaBE> objListEmpresa { get; set; }
        public List<Pers_PersonaBE> objListPersona { get; set; }
    }
}