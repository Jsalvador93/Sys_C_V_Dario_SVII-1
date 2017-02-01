using Sys_C_V_Dario_SVII.Models.Sys_Temporada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Sys_Tipo_Oferta
{
    public class Sys_Tipo_OfertaBE
    {public int i_idTipOferta { get; set; }
        public string st_dscpTipOferta { get; set; }
        public List<Sys_TemporadaBE> objListTemporada { get; set; }
    }
}