using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Categoria
{
	public class Pro_CategoriaDA
	{
        
            public List<Pro_CategoriaBE> ListaRegistroCategoria(string dato)
        {
            List<Pro_CategoriaBE> oListPro_CategoriaBE = new List<Pro_CategoriaBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_CATEGORIA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_CategoriaBE oPro_CategoriaBE = new Pro_CategoriaBE();
                                oPro_CategoriaBE.i_idCategoria = (int)(oSqlDataReader["i_idCategoria"]);
                                oPro_CategoriaBE.vc_dscpCategoria = (string)(oSqlDataReader["vc_dscpCategoria"]);
                                oListPro_CategoriaBE.Add(oPro_CategoriaBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_CategoriaBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
	}
}