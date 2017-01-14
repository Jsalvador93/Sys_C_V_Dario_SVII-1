using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Unidad
{
    public class Pro_UnidadDA
    {
        public List<Pro_UnidadBE> ListaRegistroUnidad(String dato)
        {
            List<Pro_UnidadBE> oList_Pro_UnidadBE = new List<Pro_UnidadBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_UNIDAD", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_UnidadBE oPro_UnidadBE = new Pro_UnidadBE();
                                oPro_UnidadBE.i_idUnidad = (int)(oSqlDataReader["i_idUnidad"]);
                                oPro_UnidadBE.vc_dscpUnidad = (string)(oSqlDataReader["vc_dscpUnidad"]);
                                oList_Pro_UnidadBE.Add(oPro_UnidadBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oList_Pro_UnidadBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }

        }

    }
}