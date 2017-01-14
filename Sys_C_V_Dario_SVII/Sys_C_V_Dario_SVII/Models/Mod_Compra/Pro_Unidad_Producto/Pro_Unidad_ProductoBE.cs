using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Unidad_Producto
{
    public class Pro_Unidad_ProductoBE
    {
        public DateTime dt_fchRegistro { get; set; }
        public Pro_Producto.Pro_ProductoBE oProducto { get; set; }
        public float f_cantidad { get; set; }
        //public int i_idUndCompra { get; set; }
        //public int i_idUndVenta { get; set; }
        public Pro_Unidad.Pro_UnidadBE oUnidCompra { get; set; }
        public Pro_Unidad.Pro_UnidadBE oUnidVenta { get; set; }

        public Pro_Unidad_ProductoBE()
        {
            oProducto = new Pro_Producto.Pro_ProductoBE();
            oUnidCompra = new Pro_Unidad.Pro_UnidadBE();
            oUnidVenta = new Pro_Unidad.Pro_UnidadBE();
        }
        
    }
}