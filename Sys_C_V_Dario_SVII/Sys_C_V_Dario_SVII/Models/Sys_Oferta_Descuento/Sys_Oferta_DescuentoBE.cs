using Sys_C_V_Dario_SVII.Models.Sys_Oferta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Sys_Oferta_Descuento
{
    public class Sys_Oferta_DescuentoBE
    {public Boolean  bl_nrlzOfrtDescuento { get; set; }
        public float fl_cntMaxima { get; set; }
        public float fl_cntMinima { get; set; }
        public float fl_dscnOferta { get; set; } 
        public List<Sys_OfertaBE> objListOferta { get; set; }
    }
}