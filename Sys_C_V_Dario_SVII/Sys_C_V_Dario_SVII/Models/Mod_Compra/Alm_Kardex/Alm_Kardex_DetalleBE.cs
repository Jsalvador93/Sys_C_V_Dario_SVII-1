using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Alm_Kardex
{
    public class Alm_Kardex_DetalleBE
    {
        public int i_idKrdDetalle { get; set; }
        public double f_cntExistencia { get; set; }
        public double f_cantidad { get; set; }
        public DateTime dt_fchOperacion { get; set; }
        public Alm_KardexBE oKardex { get; set; }
        public Alm_Kardex_Motivo_Operacion.Alm_Kardex_Motivo_OperacionBE oMotivoOperacion { get; set; }
        //public Emp_Punto_Venta oPuntoVenta { get; set}

    }
}