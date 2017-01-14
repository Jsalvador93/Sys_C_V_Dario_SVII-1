using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Mod_Sistema;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Vta_Venta
{
    public class Vta_VentaBE
    {
        public int i_idVenta { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE oTipoUsuario { get; set; }
        public Mod_Sistema.Rol_Usuario.Rol_UsuarioBE oUsuario { get; set; }
        public Mod_Sistema.Pers_Persona.Pers_PersonaBE oPersona { get; set; }
        public Cprb_Tipo_Comprobante.Cprb_Tipo_ComprobanteBE oTipoComprobante { get; set; }
        public List<Vta_Venta_DetalleBE> oListVentaDetalle { get; set; }
        public List<Vta_VentaBE> oVenta { get; set; }
        public Vta_VentaBE()
        {
            oTipoUsuario = new Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE();
            oPersona = new Mod_Sistema.Pers_Persona.Pers_PersonaBE();
            oTipoComprobante = new Cprb_Tipo_Comprobante.Cprb_Tipo_ComprobanteBE();
            oListVentaDetalle = new List<Vta_Venta_DetalleBE>();
            oUsuario = new Mod_Sistema.Rol_Usuario.Rol_UsuarioBE();
            oVenta = new List<Vta_VentaBE>();
        }


    }
}