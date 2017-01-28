using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_SubCategoria_Producto
{
    public class Pro_SubCategoria_ProductoDA
    {
        public List<Pro_SubCategoria_ProductoBE> ListaRegistroSubCategoriaProducto(string dato)
        {
            List<Pro_SubCategoria_ProductoBE> oListPro_SubCategoria_ProductoBE = new List<Pro_SubCategoria_ProductoBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_SUBCATEGORIA_PRODUCTO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_SubCategoria_ProductoBE oPro_SubCategoria_ProductoBE = new Pro_SubCategoria_ProductoBE();
                                oPro_SubCategoria_ProductoBE.oProducto.c_codProducto = (string)(oSqlDataReader["c_codProducto"]);
                                oPro_SubCategoria_ProductoBE.oSubCategoria.i_idSubcategoria = (int)(oSqlDataReader["i_idSubcategoria"]);
                                oListPro_SubCategoria_ProductoBE.Add(oPro_SubCategoria_ProductoBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_SubCategoria_ProductoBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}