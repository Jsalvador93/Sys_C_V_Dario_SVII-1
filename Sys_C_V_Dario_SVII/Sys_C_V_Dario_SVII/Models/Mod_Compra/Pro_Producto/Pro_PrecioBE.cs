using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto
{
    public class Pro_PrecioBE
    {
        public DateTime dt_fchRgtrPrecio { get; set; }
        public Pro_ProductoBE oProducto { get; set; }
        public Pro_Marca.Pro_MarcaBE oMarca { get; set; }
        public double f_prcCompra { get; set; }
        public double f_prcVenta { get; set; }
        public double f_utilidad { get; set; }
        public double f_prcVntNeto { get; set; }

        public Pro_PrecioBE()
        {
            oProducto = new Pro_ProductoBE();
            oMarca = new Pro_Marca.Pro_MarcaBE();
        }
    }
}