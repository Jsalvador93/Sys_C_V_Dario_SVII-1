using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Producto
{
    public class Pro_ProductoDA
    {
        public List<Pro_ProductoBE> ListaRegistroProducto(int _case, string filtro)
        {
            List<Pro_ProductoBE> oListPro_ProductoBE = new List<Pro_ProductoBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_PRODUCTO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@case", SqlDbType.Int).Value = _case;
                        oSqlCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_ProductoBE oPro_ProductoBE = new Pro_ProductoBE();
                                oPro_ProductoBE.c_codProducto = (string)(oSqlDataReader["c_codProducto"]);
                                oPro_ProductoBE.oSeccionBE.vc_dscpSeccion = (string)(oSqlDataReader["vc_dscpSeccion"]);
                                oPro_ProductoBE.oTipoProductoBE.vc_dscpTipProducto = (string)(oSqlDataReader["vc_dscpTipProducto"]);
                                oPro_ProductoBE.oMarcaBE.vc_dscpMarca = (string)(oSqlDataReader["vc_dscpMarca"]);
                                oPro_ProductoBE.vc_dscpProducto = (string)(oSqlDataReader["vc_dscpProducto"]);
                                //oPro_ProductoBE.oRegistroProducto.dt_fchRegistro = (DateTime)(oSqlDataReader["dt_fchRegistro"]);
                                oPro_ProductoBE.oListPrecio = ListaRegistroPrecio(oPro_ProductoBE.c_codProducto);
                                oListPro_ProductoBE.Add(oPro_ProductoBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_ProductoBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }


        public List<Pro_PrecioBE> ListaRegistroPrecio(string dato)
        {
            List<Pro_PrecioBE> oListPro_PrecioBE = new List<Pro_PrecioBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_PRECIO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_PrecioBE oPro_PrecioBE = new Pro_PrecioBE();
                                oPro_PrecioBE.dt_fchRgtrPrecio = (DateTime)(oSqlDataReader["dt_fchRgtrPrecio"]);
                                oPro_PrecioBE.f_prcCompra = (double)(oSqlDataReader["f_prcCompra"]);
                                oPro_PrecioBE.f_prcVenta = (double)(oSqlDataReader["f_prcVenta"]);
                                oPro_PrecioBE.f_utilidad = (double)(oSqlDataReader["f_utilidad"]);
                                oPro_PrecioBE.f_prcVntNeto = (double)(oSqlDataReader["f_prcVntNeto"]);
                                oPro_PrecioBE.oProducto.c_codProducto = (string)(oSqlDataReader["c_codProducto"]);
                                oPro_PrecioBE.oProducto.vc_dscpProducto = (string)(oSqlDataReader["vc_dscpProducto"]);
                                oPro_PrecioBE.oMarca.vc_dscpMarca = (string)(oSqlDataReader["vc_dscpMarca"]);
                                oListPro_PrecioBE.Add(oPro_PrecioBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_PrecioBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}