using Sys_C_V_Dario_SVII.Models.Rol_Sub_Modulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Rol_Funcion
{
    public class Rol_FuncionBE
    {
        public int in_idFuncion { get; set; }
        public string st_dscpFuncion { get; set; }
        public List <Rol_Sub_ModuloBE> objListSubModulo { get; set; }
    }
}