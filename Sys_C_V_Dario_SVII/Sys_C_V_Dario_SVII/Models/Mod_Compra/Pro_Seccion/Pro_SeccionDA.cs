using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Seccion
{
    public class Pro_SeccionDA
    {
        public List<Pro_SeccionBE> ListaRegistroSeccion(string dato)
        {
            List<Pro_SeccionBE> oListPro_SeccionBE = new List<Pro_SeccionBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_SECCION", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_SeccionBE oPro_SeccionBE = new Pro_SeccionBE();
                                oPro_SeccionBE.i_idSeccion = (int)(oSqlDataReader["i_idSeccion"]);
                                oPro_SeccionBE.vc_dscpSeccion = (string)(oSqlDataReader["vc_dscpSeccion"]);
                                oListPro_SeccionBE.Add(oPro_SeccionBE);
                            }

                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_SeccionBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}