using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Compra
{
    public class Com_Compra_DetalleBE
    {
        public Com_CompraBE oCompraBE { get; set; }
        public Com_Pedido.Com_PedidoBE oPedidoBE { get; set; }
        public Pro_Producto.Pro_ProductoBE oProductoBE { get; set; }
        public double f_prcTotPrdCmprDetalle { get; set; }
        public double f_cntPrdComDetalle { get; set; }

        public Com_Compra_DetalleBE()
        {
            oCompraBE = new Com_CompraBE();
            oPedidoBE = new Com_Pedido.Com_PedidoBE();
            oProductoBE = new Pro_Producto.Pro_ProductoBE();
        }
    }
} 