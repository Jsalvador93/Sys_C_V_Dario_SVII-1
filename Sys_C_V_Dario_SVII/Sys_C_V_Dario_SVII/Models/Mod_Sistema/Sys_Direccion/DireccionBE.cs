using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Distrito;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Direccion
{
    public class DireccionBE
    {
        public int i_idDireccion { get; set; }
        public string st_dscpDireccion { get; set; }
        public DistritoBE odistritoBE { get; set; }

        public DireccionBE()
        {
            odistritoBE = new DistritoBE();
        }
    }
}