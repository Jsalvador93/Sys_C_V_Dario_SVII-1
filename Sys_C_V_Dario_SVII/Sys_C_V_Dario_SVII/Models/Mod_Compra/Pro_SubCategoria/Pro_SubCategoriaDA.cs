using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_SubCategoria
{
    public class Pro_SubCategoriaDA
    {
        public List<Pro_SubCategoriaBE> ListaRegistroSubCategoria(string dato)
        {
            List<Pro_SubCategoriaBE> oListPro_SubCategoriaBE = new List<Pro_SubCategoriaBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_SUBCATEGORIA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_SubCategoriaBE oPro_SubCategoriaBE = new Pro_SubCategoriaBE();
                                oPro_SubCategoriaBE.i_idSubcategoria = (int)(oSqlDataReader["i_idSubcategoria"]);
                                oPro_SubCategoriaBE.vc_dscpSubCategoria = (string)(oSqlDataReader["vc_dscpSubCategoria"]);
                                oPro_SubCategoriaBE.oCategoria.vc_dscpCategoria = (string)(oSqlDataReader["vc_dscpCategoria"]);
                                oListPro_SubCategoriaBE.Add(oPro_SubCategoriaBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_SubCategoriaBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}