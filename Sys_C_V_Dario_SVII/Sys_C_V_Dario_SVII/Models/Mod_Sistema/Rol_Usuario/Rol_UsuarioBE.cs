using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Sistema.Rol_Usuario
{
    public class Rol_UsuarioBE
    {
        public Pers_Persona.Pers_PersonaBE oPersona { get; set; }

        public Rol_UsuarioBE()
        {
            oPersona = new Pers_Persona.Pers_PersonaBE();
        }
    }
}