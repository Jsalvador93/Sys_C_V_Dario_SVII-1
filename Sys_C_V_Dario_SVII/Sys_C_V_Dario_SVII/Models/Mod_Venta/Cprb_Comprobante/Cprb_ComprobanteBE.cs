using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Comprobante
{
    public class Cprb_ComprobanteBE
    {
        public int i_idComprobante { get; set; }
        public string vc_numComprobante { get; set; }
        public DateTime dt_fchEmision { get; set; }
        public Cprb_PC.Cprb_PCBE oPCBE { get; set; }
        public Cprb_Naturaleza.Cprb_NaturalezaBE oNaturalezaBE { get; set;}
        public Cprb_Tipo_Comprobante.Cprb_Tipo_ComprobanteBE oTipo_ComprobanteBE { get;set;}
        //public Emp_Empresa.Emp_EmpresaBE oEmpresaBE {get; set;}
        //public Emp_Sucursal.Emp_SucursalBE oSucursalBE {get; set;}
        //publci Emp_Punto_Venta.Emp_Punto_VentaBE oPunto_VentaBE {get; set,}

        public Cprb_ComprobanteBE()
        {
            oPCBE = new Cprb_PC.Cprb_PCBE();
            oNaturalezaBE = new Cprb_Naturaleza.Cprb_NaturalezaBE();
            oTipo_ComprobanteBE = new Cprb_Tipo_Comprobante.Cprb_Tipo_ComprobanteBE();
            //oEmpresaBE = new Emp_Empresa.Emp_EmpresaBE();
            //oSucursalBE = new Emp_Sucursal.Emp_SucursalBE();
            //oPunto_VentaBE = new Emp_Punto_Venta.Emp_Punto_VentaBE();

        }


       




    }
}