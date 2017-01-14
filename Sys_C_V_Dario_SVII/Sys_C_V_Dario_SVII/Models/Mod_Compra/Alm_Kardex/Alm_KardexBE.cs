using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Alm_Kardex
{
    public class Alm_KardexBE
    {
        public int i_idKardex { get; set; }
        public DateTime dt_fchInicio { get; set; }
        public DateTime dt_fchFin { get; set; }
        public Boolean b_krdNaturaleza { get; set; }
        public Pro_Producto.Pro_ProductoBE oProductoBE { get; set; }
        public List<Alm_Kardex_DetalleBE> oListKardexDetalle { get; set; }
        public List<Alm_KardexBE> oListKardex { get; set; }

        //public int i_idPtoVenta { get; set; } <---- Llama a la tabla Emp_Punto_Venta

        public Alm_KardexBE()
        {
            oProductoBE = new Pro_Producto.Pro_ProductoBE();
            //oPtoVenta
            oListKardexDetalle = new List<Alm_Kardex_DetalleBE>();
            oListKardex = new List<Alm_KardexBE>();
            
        }
    }
}