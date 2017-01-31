using Sys_C_V_Dario_SVII.Controllers.Emp_Logo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Emp_Empresa
{
    public class Emp_EmpresaBE
    {
        public int in_idEmpresa { get; set; }
        public char c_ruc { get; set; }
        public string st_nmbComercial { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public string st_drcWeb { get; set; }
        public List<Emp_LogoBE> objListLogo { get; set; }
    }
}