using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Caj_LibroCaja
{
    public class Caj_LibroCajaBE
    {
        public int in_idLibroCaja { get; set; }
        public DateTime dt_fchDesde { get; set; }
        public DateTime dt_fchHasta { get; set; }
        public DateTime dt_fchRegistro { get; set; }
        public float fl_mntSdoCaja { get; set; }
        public float fl_mntCajChica { get; set; }
        public float fl_totIngreso { get; set; }
        public float fl_totEgreso { get; set; }
        public List<Caj_LibroCajaDetalleBE> objListLibroCajaDetalle { get; set; }

        public Caj_LibroCajaBE() {
            objListLibroCajaDetalle = new List<Caj_LibroCajaDetalleBE>();
        } 
    }
}