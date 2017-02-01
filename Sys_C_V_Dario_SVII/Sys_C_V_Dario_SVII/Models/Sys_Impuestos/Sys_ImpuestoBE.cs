using Sys_C_V_Dario_SVII.Models.Sys_Impuesto_Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Sys_Impuestos
{
    public class Sys_ImpuestoBE
    {
        public byte by_impuesto { get; set; }
        public String vc_abreviatura { get; set; }
        public String vc_dscpImpuesto { get; set; }
        public List<Sys_impuesto_updateBE> objListimpuesto { get; set; }
    }
       }
