using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_SubCategoria_Producto
{
    public class Pro_SubCategoria_ProductoBE
    {
        public Pro_Producto.Pro_ProductoBE oProducto { get; set; }
        public  Pro_SubCategoria.Pro_SubCategoriaBE oSubCategoria { get; set; }

        public Pro_SubCategoria_ProductoBE()
        {
            oProducto = new Pro_Producto.Pro_ProductoBE();
            oSubCategoria = new Pro_SubCategoria.Pro_SubCategoriaBE();
        }
    }
}