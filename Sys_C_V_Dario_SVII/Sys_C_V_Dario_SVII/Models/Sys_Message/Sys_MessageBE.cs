using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Sys_Message
{
    public class Sys_MessageBE
    {
        public string st_cabecera { get; set; }
        public string st_detalle { get; set; }

        public Sys_MessageBE( string st_cabecera , string st_detalle )
        {
            this.st_cabecera = st_cabecera;
            this.st_detalle = st_detalle;
        }
    }
}