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
        public Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE oUsuario { get; set; }
        public Mod_Sistema.Pers_Persona.Pers_PersonaBE oPersona { get; set; }
        //public Cprb_Comprobante.Cprb_ComprobanteBE oComprobante { get; set; }
        public decimal subTotal { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }
        public List<Vta_Venta_DetalleBE> oListVentaDetalle { get; set; }
        public List<Vta_VentaBE> oVenta { get; set; }
        //public Mod_Sistema.Est_Tipo_Estado.Est_Tipo_Estado oTipoEstado { get; set; }
        public Vta_VentaBE()
        {
            oPersona = new Mod_Sistema.Pers_Persona.Pers_PersonaBE();
            //oComprobante = new Cprb_Comprobante.Cprb_ComprobanteBE();
            oListVentaDetalle = new List<Vta_Venta_DetalleBE>();
            oUsuario = new Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE();
            oVenta = new List<Vta_VentaBE>();
            //oTipoEstado = new Mod_Sistema.Est_Tipo_Estado.Est_Tipo_Estado();
        }


    }
}
