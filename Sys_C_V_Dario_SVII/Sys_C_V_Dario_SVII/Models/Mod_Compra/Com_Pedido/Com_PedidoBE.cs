using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Pedido
{
    public class Com_PedidoBE
    {
        public int i_idPedido { get; set; }
        public DateTime dt_fchRgtPedido { get; set; }
        //public Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE oTipoUsuario { get; set; }
        public Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE oUsuario { get; set; }
        public double subTotal { get; set; }
        public List<Com_Pedido_DetalleBE> oListPedidoDetalle { get; set; }
        public List<Com_PedidoBE> oListPedido { get; set; }
        public Com_PedidoBE()
        {
            oListPedidoDetalle = new List<Com_Pedido_DetalleBE>();
            oListPedido = new List<Com_PedidoBE>();
            oUsuario = new Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE();
//            oTipoUsuario = new Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE();
        }
    }
}