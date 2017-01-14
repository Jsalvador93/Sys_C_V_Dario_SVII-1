using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Guia_Remision
{
    public class Cprb_Guia_RemisionBE
    {

        public Cprb_Comprobante.Cprb_ComprobanteBE oComprobanteBE { get; set; }
        public Cprb_Motivo_Traslado.Cprb_Motivo_TrasladoBE oMotivo_TrasladoBE { get; set; }
        //public Rol_Usuario.Rol_UsuarioBE oRol_UsuarioBE { get; set; }
        //public Emp_Punto_Venta.Emp_Punto_VentaBE oEmp_Punto_VentaBE { get; set; }

        public Cprb_Guia_RemisionBE()
        {
            oComprobanteBE = new Cprb_Comprobante.Cprb_ComprobanteBE();
            oMotivo_TrasladoBE = new Cprb_Motivo_Traslado.Cprb_Motivo_TrasladoBE();
            //oRol_UsuarioBE = new Rol_Usuario.Rol_UsuarioBE();
            //oEmp_Punto_VentaBE = new Emp_Punto_Venta.Emp_Punto_VentaBE();



        }
        
 

    }
}