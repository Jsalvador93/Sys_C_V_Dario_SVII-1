using Sys_C_V_Dario_SVII.Models.Pro_Producto;
using Sys_C_V_Dario_SVII.Models.Sys_Tipo_Oferta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Sys_Oferta
{
    public class Sys_OfertaBE
    {public int in_idOferta { get; set; }
        public string st_dscpOferta { get; set; }
        public List<Sys_OfertaBE> objListOferta { get; set; }
        public List<Pro_ProductoBE> objListProducto { get; set; }
        public List<Sys_Tipo_OfertaBE> objListTipo { get; set; }
    }
}