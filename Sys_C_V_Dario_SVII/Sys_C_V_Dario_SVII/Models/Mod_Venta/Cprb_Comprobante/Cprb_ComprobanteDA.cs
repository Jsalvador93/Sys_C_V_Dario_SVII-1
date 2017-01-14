using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Comprobante
{
    public class Cprb_ComprobanteDA
    {
        public List<Cprb_ComprobanteBE> ListaRegistroComprobante(string dato)
        {
            List<Cprb_ComprobanteBE> oListCpr_ComprobanteBE = new List<Cprb_ComprobanteBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_COMPROBANTE", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_ComprobanteBE oCprb_ComprobanteBE = new Cprb_ComprobanteBE();
                                oCprb_ComprobanteBE.i_idComprobante = (int)(oSqlDataReader["i_idComprobante"]);
                                oCprb_ComprobanteBE.vc_numComprobante = (string)(oSqlDataReader["vc_numComprobante"]);
                                oCprb_ComprobanteBE.dt_fchEmision = (DateTime)(oSqlDataReader["dt_fchEmision"]);
                                oCprb_ComprobanteBE.oPCBE.i_idPc = (int)(oSqlDataReader["i_idPc"]);
                                oCprb_ComprobanteBE.oNaturalezaBE.i_idNaturaleza = (int)(oSqlDataReader["i_idNaturaleza"]);
                                oCprb_ComprobanteBE.oTipo_ComprobanteBE.c_codTipComprobante = (string)(oSqlDataReader["c_codTipComprobante"]);
                                oListCpr_ComprobanteBE.Add(oCprb_ComprobanteBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCpr_ComprobanteBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }







    }
}