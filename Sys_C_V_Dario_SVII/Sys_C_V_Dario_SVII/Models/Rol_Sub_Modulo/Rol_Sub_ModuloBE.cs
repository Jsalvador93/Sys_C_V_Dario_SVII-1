using Sys_C_V_Dario_SVII.Models.Rol_Modulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Rol_Sub_Modulo
{
    public class Rol_Sub_ModuloBE
    {
        public int i_idSubModulo{ get; set; }
        public string st_dscpSubModulo { get; set; }
         public List<Rol_ModuloBE> objListModulo { get; set; }
    }
}