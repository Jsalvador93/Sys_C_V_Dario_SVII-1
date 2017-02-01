

using Sys_C_V_Dario_SVII.Models.Pers_Telefono;
using Sys_C_V_Dario_SVII.Models.Pers_Tipo_Persona;
using Sys_C_V_Dario_SVII.Models.Sys_Direccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Pers_Persona
{
    public class Pers_PersonaBE
    {
        public string st_codPersona { get; set; }
        public string st_nomPersona { get; set; }
        public string st_apPaterno { get; set; }
        public bool bl_nrlzPersona { get; set; }
        public string st_drcWeb { get; set; }
        public DateTime dt_fchRgtrPersona { get; set; }
        public List<Pers_Tipo_PersonaBE> objListTipo_Persona { get; set; }
        public List<Pers_TelefonoBE> objListTelefono { get; set; }
        public List<Sys_DireccionBE> objListDireccion { get; set; }

    }
}