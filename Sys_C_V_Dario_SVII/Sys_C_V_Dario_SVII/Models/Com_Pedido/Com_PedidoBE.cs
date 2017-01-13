using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Com_Pedido;
using Sys_C_V_Dario_SVII.Models.Rol_RolUsuario;
using Sys_C_V_Dario_SVII.Models.Est_TipEstDetalle;

namespace Sys_C_V_Dario_SVII.Models.Com_Pedido
{
    public class Com_PedidoBE
    {
        public int in_idPedido { get; set; }
        public DateTime dt_fchRgtPedido { get; set; }
        public Rol_RolUsuarioBE objRolUsuario { get; set; }
        public Est_TipEstDetalleBE objTipoEstDetalle { get; set; }
        public Com_PedidoBE()
        {
            objRolUsuario = new Rol_RolUsuarioBE();
            objTipoEstDetalle = new Est_TipEstDetalleBE();
        }
    }
}