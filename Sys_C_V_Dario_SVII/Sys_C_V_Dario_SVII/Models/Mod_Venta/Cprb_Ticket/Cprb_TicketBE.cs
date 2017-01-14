using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Ticket
{
    public class Cprb_TicketBE
    {
        public double f_opGravada { get; set; }
        public double f_opNoGravada { get; set; }
        public double f_impTotTicket { get; set; }
        public Cprb_Comprobante.Cprb_ComprobanteBE oComprobanteBE { get; set; }
        //public Cam_Tipo_Cambio.Cam_Tipo_CambioBE oTipo_CambioBE {get ; set;}
        //public Pers_Persona.Pers_PersonaBE oPersonaBE {get; set;}
        //public Rol_Usuario.Rol_UsuarioBE oUsuarioBE {get; set;}

        public Cprb_TicketBE()
        {
            oComprobanteBE = new Cprb_Comprobante.Cprb_ComprobanteBE();
            //oTipo_CambioBE = new Cam_Tipo_Cambio.Cam_Tipo_CambioBE();
            //oPersonaBE = new Pers_Persona.Pers_PersonaBE(); 
            //oUsuarioBE = new Rol_Usuario.Rol_UsuarioBE();





        }

        //public Cprb_PC.Cprb_PCBE oPCBE { get; set; }




    }
}