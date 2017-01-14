using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Alm_Kardex_Motivo_Operacion
{
    public class Alm_Kardex_Motivo_OperacionDA
    {
        public List<Alm_Kardex_Motivo_OperacionBE> ListaRegistroKardexMotivoOperacion(string dato)
        {
            List<Alm_Kardex_Motivo_OperacionBE> oListAlm_Kardex_Motivo_OperacionBE = new List<Alm_Kardex_Motivo_OperacionBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_KARDEX_MOTIVO_OPERACION", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Alm_Kardex_Motivo_OperacionBE oAlm_Kardex_Motivo_OperacionBE = new Alm_Kardex_Motivo_OperacionBE();
                                oAlm_Kardex_Motivo_OperacionBE.i_idMtvOperacion = (int)(oSqlDataReader["i_idMtvOperacion"]);
                                oAlm_Kardex_Motivo_OperacionBE.vc_dscpMtvOperacion = (string)(oSqlDataReader["vc_dscpMtvOperacion"]);
                                oAlm_Kardex_Motivo_OperacionBE.oOpKardex.i_idOpKardex = (int)(oSqlDataReader["i_idOpKardex"]);
                                oListAlm_Kardex_Motivo_OperacionBE.Add(oAlm_Kardex_Motivo_OperacionBE);

                                
                            }
                            oSqlDataReader.Close();
                        }

                    }

                    conexion.Close();
                    return oListAlm_Kardex_Motivo_OperacionBE;

                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
    }
