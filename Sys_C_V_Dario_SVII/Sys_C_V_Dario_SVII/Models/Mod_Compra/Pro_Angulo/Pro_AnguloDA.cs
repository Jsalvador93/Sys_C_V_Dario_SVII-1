using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Angulo
{
	public class Pro_AnguloDA
	{
        public List<Pro_AnguloBE> ListaRegistroAngulo(string dato)
        {
            List<Pro_AnguloBE> oListPro_AnguloBE = new List<Pro_AnguloBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_ANGULO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_AnguloBE oPro_AnguloBE = new Pro_AnguloBE();
                                oPro_AnguloBE.i_idAngulo = (int)(oSqlDataReader["c_codAngulo"]);
                                oPro_AnguloBE.vc_dscpAngulo = (string)(oSqlDataReader["vc_dscpAngulo"]);
                                oListPro_AnguloBE.Add(oPro_AnguloBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_AnguloBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }   
	}
}