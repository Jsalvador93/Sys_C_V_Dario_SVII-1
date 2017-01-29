using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Emp_Logo;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Emp_Empresa
{
    public class EmpresaBE
    {
        public int in_idEmpresa { get; set; }
        public string st_ruc { get; set; }
        public string st_nmbComercial { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public string st_drcWeb { get; set; }
        public LogoBE oLogoBE { get; set; }

        public EmpresaBE()
        {
            oLogoBE = new LogoBE();
        }
    }
}