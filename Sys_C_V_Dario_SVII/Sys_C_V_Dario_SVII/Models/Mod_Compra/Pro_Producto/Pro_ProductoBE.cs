using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto
{
    public class Pro_ProductoBE
    {
        public string c_codProducto { get; set; }
        public string vc_dscpProducto { get; set; }
        public Pro_Seccion.Pro_SeccionBE oSeccionBE { get; set; }
        public Pro_Tipo_Producto.Pro_Tipo_ProductoBE  oTipoProductoBE { get; set; }
        public Pro_Marca.Pro_MarcaBE oMarcaBE { get; set; }
        public Pro_Registro_ProductoBE oRegistroProducto { get; set; }
        public List<Pro_PrecioBE> oListPrecio { get; set; }
        public List<Pro_ProductoBE> oListProducto { get; set; }
        public Pro_ProductoBE()
        {
            oSeccionBE = new Pro_Seccion.Pro_SeccionBE();
            oTipoProductoBE = new Pro_Tipo_Producto.Pro_Tipo_ProductoBE();
            oMarcaBE = new Pro_Marca.Pro_MarcaBE();
            oRegistroProducto = new Pro_Registro_ProductoBE();
            oListPrecio = new List<Pro_PrecioBE>();
            oListProducto = new List<Pro_ProductoBE>();
        }
    }
}