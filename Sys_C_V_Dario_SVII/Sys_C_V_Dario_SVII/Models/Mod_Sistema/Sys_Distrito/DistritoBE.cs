using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Provincia;


namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Sys_Distrito
{
    public class DistritoBE
    {
        public int i_idDistrito { get; set; }
        public string st_dscpDistrito { get; set; }
        public ProvinciaBE oprovinciaBE { get; set; }

        public DistritoBE(){
            oprovinciaBE = new ProvinciaBE();
        }
    }
}