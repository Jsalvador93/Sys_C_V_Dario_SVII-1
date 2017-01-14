using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Lote
{
    public class Pro_Lote_DetalleBE
    {
        public DateTime dt_fchIgrLote { get; set; }
        public double f_cantidad { get; set; }
        public Pro_LoteBE oLoteBE { get; set; }
        public Pro_Producto.Pro_ProductoBE oProductoBE { get; set; }
        public Pro_Unidad_Producto.Pro_Unidad_ProductoBE oUnidProducto { get; set; }
        public Pro_Lote_DetalleBE()
        {
            oLoteBE = new Pro_LoteBE();
            oProductoBE = new Pro_Producto.Pro_ProductoBE();
            oUnidProducto = new Pro_Unidad_Producto.Pro_Unidad_ProductoBE();
        }

    }
}