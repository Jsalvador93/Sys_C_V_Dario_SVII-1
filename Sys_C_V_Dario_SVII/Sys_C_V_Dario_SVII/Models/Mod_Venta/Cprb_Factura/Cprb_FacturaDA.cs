using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Factura
{
    public class Cprb_FacturaDA
    {
        public List<Cprb_FacturaBE> ListaRegistroFactura(string dato)
        {
            List<Cprb_FacturaBE> oListCpr_FacturaBE = new List<Cprb_FacturaBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_FACTURA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_FacturaBE oCprb_FacturaBE = new Cprb_FacturaBE();
                                oCprb_FacturaBE.f_opGrabada = (Double)(oSqlDataReader["f_opGrabada"]);
                                oCprb_FacturaBE.f_opNoGrabada = (Double)(oSqlDataReader["f_opNoGrabada"]);
                                oCprb_FacturaBE.f_impTotalFactura = (Double)(oSqlDataReader["f_impTotalFactura"]);
                                oCprb_FacturaBE.oComprobanteBE.i_idComprobante = (int)(oSqlDataReader["i_idComprobante"]);
                                oListCpr_FacturaBE.Add(oCprb_FacturaBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCpr_FacturaBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

    }
}