using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Tipo_Comprobante
{
    public class Cprb_Tipo_ComprobanteDA
    {
        public List<Cprb_Tipo_ComprobanteBE> ListaRegistroTipoComprobante(String dato)
        {
            List<Cprb_Tipo_ComprobanteBE> oListCprb_Tipo_ComprobanteBE = new List<Cprb_Tipo_ComprobanteBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_TIPO_COMPROBANTE", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_Tipo_ComprobanteBE oCprb_Tipo_ComprobanteBE = new Cprb_Tipo_ComprobanteBE();
                                oCprb_Tipo_ComprobanteBE.c_codTipComprobante = (string)(oSqlDataReader["c_codTipComprobante"]);
                                oCprb_Tipo_ComprobanteBE.vc_dscpTipComprobante = (string)(oSqlDataReader["vc_dscpTipComprobante"]);
                                oListCprb_Tipo_ComprobanteBE.Add(oCprb_Tipo_ComprobanteBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCprb_Tipo_ComprobanteBE;
                }

                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
    }
