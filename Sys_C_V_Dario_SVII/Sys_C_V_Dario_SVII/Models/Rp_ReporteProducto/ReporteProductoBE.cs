using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto;

namespace Sys_C_V_Dario_SVII.Models.Rp_ReporteProducto
{
    public class ReporteProductoBE
    {
        public Pro_ProductoBE objProProductoBE { get; set; }
        public Pro_PrecioBE objProPrecioBE { get; set; }
        public Pro_Registro_ProductoBE objProRgtrProductoBE { get; set; }
        public ReporteProductoBE()
        {
            objProProductoBE = new Pro_ProductoBE();
            objProPrecioBE = new Pro_PrecioBE();
            objProRgtrProductoBE = new Pro_Registro_ProductoBE();
        }
    }
}