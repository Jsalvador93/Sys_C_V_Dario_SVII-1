using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Alm_Kardex_Operacion
{
    public class Alm_Kardex_OpracionDA
    {
        public List<Alm_Kardex_OperacionBE> ListaRegistroKardexOperacion(string dato)
        {
            List<Alm_Kardex_OperacionBE> oListAlm_Kardex_OperacionBE = new List<Alm_Kardex_OperacionBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_KARDEX_OPERACION", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Alm_Kardex_OperacionBE oAlm_Kardex_OperacionBE = new Alm_Kardex_OperacionBE();
                                oAlm_Kardex_OperacionBE.i_idOpKardex = (int)(oSqlDataReader["i_idOpKardex"]);
                                oAlm_Kardex_OperacionBE.vc_dscpOperacion = (string)(oSqlDataReader["vc_dscpOperacion"]);
                                oListAlm_Kardex_OperacionBE.Add(oAlm_Kardex_OperacionBE);
                            }
                            oSqlDataReader.Close();
                        }

                    }

                    conexion.Close();
                    return oListAlm_Kardex_OperacionBE;

                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}