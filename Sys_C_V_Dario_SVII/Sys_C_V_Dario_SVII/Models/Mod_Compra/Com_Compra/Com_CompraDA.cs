using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Compra
{
    public class Com_CompraDA
    {
        
        public List<Com_Compra_DetalleBE> ListaRegistroCompraDetalle(int dato)
        {
            List<Com_Compra_DetalleBE> oListCompraDetalle = new List<Com_Compra_DetalleBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    string strCondicion = string.Empty;
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_COM_LC_COMPRA_DETALLE", conexion))
                    {
                        if (dato == 0)
                        {
                            strCondicion = "";
                        }
                        else
                        {
                            oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        }
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Com_Compra_DetalleBE oCom_DetalleBE = new Com_Compra_DetalleBE();
                                oCom_DetalleBE.oCompraBE.i_idCompra =(int)(oSqlDataReader["i_idCompra"]);
                                oCom_DetalleBE.oPedidoBE.i_idPedido =(int)(oSqlDataReader["i_idPedido"]);
                                oCom_DetalleBE.oProductoBE.vc_dscpProducto =(string)(oSqlDataReader["vc_dscpProducto"]);
                                oCom_DetalleBE.f_cntPrdComDetalle = (double)(oSqlDataReader["f_cntPrdComDetalle"]);
                                oCom_DetalleBE.f_prcTotPrdCmprDetalle =(double)(oSqlDataReader["subTotal"]);
                                oListCompraDetalle.Add(oCom_DetalleBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCompraDetalle;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

        public List<Com_CompraBE> ListaRegistroCompra(int _case, string filtro)
        {
            List<Com_CompraBE> oListCompra = new List<Com_CompraBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_COM_LC_COMPRA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@case", SqlDbType.Int).Value = _case;
                        oSqlCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Com_CompraBE oCom_CompraBE = new Com_CompraBE();
                                oCom_CompraBE.i_idCompra = (int)(oSqlDataReader["i_idCompra"]);
                                oCom_CompraBE.dt_fchCompra = (DateTime)(oSqlDataReader["dt_fchCompra"]);
                                oCom_CompraBE.dt_fchRegistro = (DateTime)(oSqlDataReader["dt_fchRegistro"]);
                                //oCom_CompraBE.oTipoUsuarioComprador.vc_dscpTipUsuario = (string)(oSqlDataReader["vc_dscpTipUsuario"]);
                                oCom_CompraBE.oUsuarioComprador.oPersonaBE.st_nombreCompleto = (string)(oSqlDataReader["Comprador"]);
                                //oCom_CompraBE.oTipoUsuarioRegistrador.vc_dscpTipUsuario = (string)(oSqlDataReader["vc_dscpTipUsuario"]);
                                oCom_CompraBE.oUsuarioRegistrador.oPersonaBE.st_nombreCompleto = (string)(oSqlDataReader["Registrador"]);
                                oCom_CompraBE.oPersona.st_nombreCompleto = (string)(oSqlDataReader["Proveedor"]);
                                oCom_CompraBE.oComprobante.vc_numComprobante = (string)(oSqlDataReader["vc_numComprobante"]);
                                oCom_CompraBE.oListCompraDetalle = ListaRegistroCompraDetalle(oCom_CompraBE.i_idCompra);
                                oListCompra.Add(oCom_CompraBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCompra;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}