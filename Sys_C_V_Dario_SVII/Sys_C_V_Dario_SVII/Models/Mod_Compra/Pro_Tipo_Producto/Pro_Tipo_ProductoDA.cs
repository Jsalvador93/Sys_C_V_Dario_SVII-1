using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Tipo_Producto
{
    public class Pro_Tipo_ProductoDA
    {
        public List<Pro_Tipo_ProductoBE> ListaRegistroTipoProducto(string dato)
        {
            List<Pro_Tipo_ProductoBE> oListPro_Tipo_ProductoBE = new List<Pro_Tipo_ProductoBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_TIPO_PRODUCTO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_Tipo_ProductoBE oPro_Tipo_ProductoBE = new Pro_Tipo_ProductoBE();
                                oPro_Tipo_ProductoBE.i_idTipProducto = (int)(oSqlDataReader["i_idTipProducto"]);
                                oPro_Tipo_ProductoBE.vc_dscpTipProducto = (string)(oSqlDataReader["vc_dscpTipProducto"]);
                                oListPro_Tipo_ProductoBE.Add(oPro_Tipo_ProductoBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_Tipo_ProductoBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}