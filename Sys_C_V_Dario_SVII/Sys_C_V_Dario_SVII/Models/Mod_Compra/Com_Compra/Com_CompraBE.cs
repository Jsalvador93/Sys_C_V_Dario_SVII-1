using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Compra
{
    public class Com_CompraBE
    {
        public int i_idCompra { get; set; }
        public DateTime dt_fchCompra { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        //public Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE oTipoUsuarioComprador { get; set; }
        public Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE oUsuarioComprador { get; set; }
        //public Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE oTipoUsuarioRegistrador { get; set; }
        public Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE oUsuarioRegistrador { get; set; }
        public Mod_Sistema.Pers_Persona.Pers_PersonaBE oPersona { get; set; }
        public Mod_Venta.Cprb_Comprobante.Cprb_ComprobanteBE oComprobante { get; set; }
        public List<Com_Compra_DetalleBE> oListCompraDetalle { get; set; }
        public List<Com_CompraBE> oListCompra { get; set; }

        public Com_CompraBE()
        {
            //oTipoUsuarioComprador = new Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE();
            oUsuarioComprador = new Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE();
            //oTipoUsuarioRegistrador = new Mod_Sistema.Rol_Tipo_Usuario.Rol_Tipo_UsuarioBE();
            oUsuarioRegistrador = new Mod_Sistema.Rol_Rol_Usuario.RolUsuarioBE();
            oPersona = new Mod_Sistema.Pers_Persona.Pers_PersonaBE();
            oComprobante = new Mod_Venta.Cprb_Comprobante.Cprb_ComprobanteBE();
            oListCompraDetalle = new List<Com_Compra_DetalleBE>();
            oListCompra = new List<Com_CompraBE>();
        }
    }
}                                               