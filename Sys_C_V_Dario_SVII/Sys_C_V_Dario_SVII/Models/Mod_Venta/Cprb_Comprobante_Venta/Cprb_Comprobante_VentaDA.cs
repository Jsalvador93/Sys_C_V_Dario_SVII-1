using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Comprobante_Venta
{
    public class Cprb_Comprobante_VentaDA
    {
        public List<Cprb_Comprobante_VentaBE> ListaRegistroComprobanteVenta(string dato)
        {
            List<Cprb_Comprobante_VentaBE> oListComprobante_VentaBE = new List<Cprb_Comprobante_VentaBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_COMPROBANTE_VENTA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_Comprobante_VentaBE oCprb_Comprobante_VentaBE = new Cprb_Comprobante_VentaBE();
                                oCprb_Comprobante_VentaBE.oComprobanteBE.i_idComprobante = (int)(oSqlDataReader["i_idComprobante"]);
                                oCprb_Comprobante_VentaBE.oVentaBE.i_idVenta = (int)(oSqlDataReader["i_idVenta"]);
                                oListComprobante_VentaBE.Add(oCprb_Comprobante_VentaBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListComprobante_VentaBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }



    }
}