using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Sys_Cupon
{
    public class Sys_CuponBE
    {public char c_codCupon { get; set; }
        public float fl_dscnCupon { get; set; }
        public DateTime dt_fchIniCupon { get; set; }
        public DateTime dt_fchFinCupon { get; set; }
        public float fl_mntMinimo { get; set; }
        public float fl_cntRqrdCupon { get; set; }

    }
}