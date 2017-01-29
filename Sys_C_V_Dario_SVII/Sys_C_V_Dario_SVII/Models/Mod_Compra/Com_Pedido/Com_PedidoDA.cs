using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Com_Pedido
{
    public class Com_PedidoDA
    {

        public List<Com_Pedido_DetalleBE> ListaRegistroPedidoDetalle(int dato)
        {
            List<Com_Pedido_DetalleBE> oListPedidoDetalle = new List<Com_Pedido_DetalleBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    string strCondicion = string.Empty;
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_COM_LC_PEDIDO_DETALLE", conexion))
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
                                Com_Pedido_DetalleBE oPed_DetalleBE = new Com_Pedido_DetalleBE();
                                oPed_DetalleBE.oPedidoBE.i_idPedido = (int)(oSqlDataReader["i_idPedido"]);
                                oPed_DetalleBE.oProductoBE.vc_dscpProducto = (string)(oSqlDataReader["vc_dscpProducto"]);
                                oPed_DetalleBE.f_prcUntReferencial = (double)(oSqlDataReader["f_prcUntReferencial"]);
                                oPed_DetalleBE.f_cntPrdPdo = (double)(oSqlDataReader["f_cntPrdPdo"]);
                                oPed_DetalleBE.suma = (double)(oSqlDataReader["suma"]);
                                oListPedidoDetalle.Add(oPed_DetalleBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPedidoDetalle;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

        public List<Com_PedidoBE> ListaRegistroPedido(int _case, string filtro)
        {
            List<Com_PedidoBE> oListPedido = new List<Com_PedidoBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_COM_LC_PEDIDO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@case", SqlDbType.Int).Value = _case;
                        oSqlCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Com_PedidoBE oCom_PedidoBE = new Com_PedidoBE();
                                oCom_PedidoBE.i_idPedido = (int)(oSqlDataReader["i_idPedido"]);
                                oCom_PedidoBE.dt_fchRgtPedido = (DateTime)(oSqlDataReader["dt_fchRgtPedido"]);
                                //oCom_PedidoBE.oTipoUsuario.vc_dscpTipUsuario = (string)(oSqlDataReader["vc_dscpTipUsuario"]);
                                oCom_PedidoBE.oUsuario.oPersonaBE.nombreCompleto = (string)(oSqlDataReader["Nombre persona"]);
                                oCom_PedidoBE.subTotal = (double)(oSqlDataReader["subtotal"]);
                                oCom_PedidoBE.oListPedidoDetalle = ListaRegistroPedidoDetalle(oCom_PedidoBE.i_idPedido);
                                oListPedido.Add(oCom_PedidoBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPedido;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

    }
}