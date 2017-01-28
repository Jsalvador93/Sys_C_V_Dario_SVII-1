using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Angulo_Producto
{
    public class Pro_Angulo_ProductoDA
    {
        public List<Pro_Angulo_ProductoBE> ListaProductoAngulo(string dato)
        {
            List<Pro_Angulo_ProductoBE> oListPro_Angulo_ProductoBE = new List<Pro_Angulo_ProductoBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_ANGULO_PRODUCTO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_Angulo_ProductoBE oPro_Angulo_ProductoBE = new Pro_Angulo_ProductoBE();
                                oPro_Angulo_ProductoBE.oProducto.c_codProducto = (String)(oSqlDataReader["c_codProducto"]);
                                oPro_Angulo_ProductoBE.oAngulo.i_idAngulo = (int)(oSqlDataReader["i_idAngulo"]);
                                oListPro_Angulo_ProductoBE.Add(oPro_Angulo_ProductoBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_Angulo_ProductoBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }


    }
}