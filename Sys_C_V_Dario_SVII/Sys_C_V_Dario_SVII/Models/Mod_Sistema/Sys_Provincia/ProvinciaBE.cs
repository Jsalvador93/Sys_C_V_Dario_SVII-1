using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Departamento;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Provincia
{
    public class ProvinciaBE
    {
        public int i_idProvincia { get; set; }
        public string st_dscrpProvincia { get; set; }
        public DepartamentoBE odepartamentoBE { get; set; }

        public ProvinciaBE()
        {
            odepartamentoBE = new DepartamentoBE();
        }
    }
}