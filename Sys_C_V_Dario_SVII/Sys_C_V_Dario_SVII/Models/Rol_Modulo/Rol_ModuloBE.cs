using Sys_C_V_Dario_SVII.Models.Rol_Funcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Rol_Modulo
{
    public class Rol_ModuloBE
    {
        public int in_idModulo { get; set; }
        public string st_descripcionModulo { get; set; }
        public List<Rol_FuncionBE> objListFuncion { get; set; }
    }
}