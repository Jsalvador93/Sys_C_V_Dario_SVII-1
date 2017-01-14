using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Factura
{
    public class Cprb_FacturaBE
    {
        public double f_opGrabada { get; set; }
        public double f_opNoGrabada { get; set; }
        public double f_impTotalFactura { get; set; }
        public Cprb_Comprobante.Cprb_ComprobanteBE oComprobanteBE { get; set; }
        //public Cam_Tipo_Cambio.Cam_Tipo_CambioBE oTipo_CambioBE { get; set; }
        //public Pers_Persona.Pers_PersonaBE oPersonaBE { get; set; }

        public Cprb_FacturaBE()
        {
            oComprobanteBE = new Cprb_Comprobante.Cprb_ComprobanteBE();
            //oTipo_CambioBE = new Cam_Tipo_Cambio.Cam_Tipo_CambioBE();
            //oPersonaBE = new Pers_Persona.Per_PersonaBE();





        }





    }
}