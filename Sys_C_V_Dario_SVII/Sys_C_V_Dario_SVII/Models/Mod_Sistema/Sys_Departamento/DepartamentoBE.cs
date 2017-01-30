using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Pais;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Departamento
{
    public class DepartamentoBE
    {
        public int i_idDepartamento { get; set; }
        public string st_dscpDepartamento { get; set; }
        public PaisBE opaisBE { get; set; }
        public DepartamentoBE()
        {
            opaisBE = new PaisBE();
        }
    }
}