using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Unidad_Producto
{
    public class Pro_Unidad_ProductoDA
    {
        public List<Pro_Unidad_ProductoBE> ListaRegistroUnidadProducto(string dato)
        {
            List<Pro_Unidad_ProductoBE> oListPro_Unidad_ProductoBE = new List<Pro_Unidad_ProductoBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_UNIDAD_PRODUCTO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_Unidad_ProductoBE oPro_Unidad_ProductoBE = new Pro_Unidad_ProductoBE();
                                oPro_Unidad_ProductoBE.dt_fchRegistro = (DateTime)(oSqlDataReader["dt_fchRegistro"]);
                                oPro_Unidad_ProductoBE.oProducto.c_codProducto = (string)(oSqlDataReader["c_codProducto"]);
                                oPro_Unidad_ProductoBE.f_cantidad = (float)(oSqlDataReader["f_cantidad"]);
                                //oPro_Unidad_ProductoBE.i_idUndCompra = (int)(oSqlDataReader["i_idUndCompra"]);
                                //oPro_Unidad_ProductoBE.i_idUndVenta = (int)(oSqlDataReader["i_idUndVenta"]);
                                oListPro_Unidad_ProductoBE.Add(oPro_Unidad_ProductoBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_Unidad_ProductoBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

    }
}