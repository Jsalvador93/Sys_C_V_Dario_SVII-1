using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys_C_V_Dario_SVII.Models.Sys_Message;

namespace Sys_C_V_Dario_SVII.Controllers.Sys_Message
{
    public class Sys_MessageController : Controller
    {
        // GET: Sys_Message
        public ActionResult _MessageError( string st_cabecera , string st_detalle ) 
        {
            Sys_MessageBE objMessage = new Sys_MessageBE(st_cabecera, st_detalle);
            return PartialView( "_MessageError" , objMessage );
        }
        public ActionResult _MessageAdvertencia(string st_cabecera, string st_detalle)
        {
            Sys_MessageBE objMessage = new Sys_MessageBE(st_cabecera, st_detalle);
            return PartialView("_MessageAdvertencia", objMessage);
        }
        public ActionResult _MessageExito(string st_cabecera, string st_detalle)
        {
            Sys_MessageBE objMessage = new Sys_MessageBE(st_cabecera, st_detalle);
            return PartialView("_MessageExito", objMessage);
        }
        public ActionResult _MessageInformacion(string st_cabecera, string st_detalle)
        {
            Sys_MessageBE objMessage = new Sys_MessageBE(st_cabecera, st_detalle);
            return PartialView("_MessageInformacion", objMessage);
        }
    }
}