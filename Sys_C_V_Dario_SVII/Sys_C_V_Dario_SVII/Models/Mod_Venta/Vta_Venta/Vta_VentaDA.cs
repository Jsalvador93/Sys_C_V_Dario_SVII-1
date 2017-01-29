using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Vta_Venta
{
    public class Vta_VentaDA
    {

        public Boolean RegistrarVenta(Vta_VentaBE oVenta)
        {
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                conexion.Open();
                SqlTransaction oTransaction = conexion.BeginTransaction();
                try
                {
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_VTA_ABM_VENTA", conexion))
                    {
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        oSqlCommand.Transaction = oTransaction;
                        oSqlCommand.Parameters.Add("@tipoABM", SqlDbType.Int).Value = 1;
                        oSqlCommand.Parameters.Add("@i_idVenta", SqlDbType.Int).Value = oVenta.i_idVenta;
                        oSqlCommand.Parameters.Add("@vc_codUsuario", SqlDbType.VarChar).Value = oVenta.oUsuario.vc_codUsuario;
                        oSqlCommand.Parameters.Add("@i_idPersona", SqlDbType.Int).Value = oVenta.oPersona.i_idPersona;
                        oSqlCommand.ExecuteNonQuery();
                        foreach (Vta_Venta_DetalleBE oVentaDetalle in oVenta.oListVentaDetalle)
                        {
                            oSqlCommand.CommandText = "SP_VTA_ABM_VENTA_DETALLE";
                            oSqlCommand.Parameters.Clear();
                            oSqlCommand.Parameters.Add("@tipoABM", SqlDbType.Int).Value = 1;
                            oSqlCommand.Parameters.Add("@i_idVntDetalle", SqlDbType.Int).Value = oVentaDetalle.i_idVntDetalle;
                            oSqlCommand.Parameters.Add("@i_idVenta", SqlDbType.Int).Value = oVenta.i_idVenta;
                            oSqlCommand.Parameters.Add("@f_totalVntDetalle", SqlDbType.Float).Value = oVentaDetalle.f_totalVntDetalle;
                            oSqlCommand.Parameters.Add("@f_cntPrdVntDetalle", SqlDbType.Float).Value = oVentaDetalle.f_cntPrdVntDetalle;
                            oSqlCommand.Parameters.Add("@c_codProducto", SqlDbType.Char).Value = oVentaDetalle.oProductoBE.c_codProducto;
                            oSqlCommand.ExecuteNonQuery();
                        }
                    }
                    oTransaction.Commit();
                    conexion.Close();
                    return true;
                }
                catch (System.Exception e)
                {
                    oTransaction.Rollback();
                    conexion.Close();
                    return false;
                }
            }
        }

        public List<Vta_Venta_DetalleBE> ListaRegistroVentaDetalle(int dato)
        {
            List<Vta_Venta_DetalleBE> oListVentaDetalle = new List<Vta_Venta_DetalleBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_VTA_LC_VENTA_DETALLE", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.Int).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Vta_Venta_DetalleBE oVta_Venta_DetalleBE = new Vta_Venta_DetalleBE();
                                //oVta_Venta_DetalleBE.oVentaBE.i_idVenta = (int)(oSqlDataReader["i_idVenta"]);
                                oVta_Venta_DetalleBE.i_idVntDetalle = (int)(oSqlDataReader["i_idVntDetalle"]);
                                oVta_Venta_DetalleBE.oProductoBE.vc_dscpProducto = (string)(oSqlDataReader["vc_dscpProducto"]);
                                oVta_Venta_DetalleBE.f_cntPrdVntDetalle = (Double)(oSqlDataReader["f_cntPrdVntDetalle"]);
                                oVta_Venta_DetalleBE.f_totalVntDetalle = (Double)(oSqlDataReader["f_totalVntDetalle"]);
                                oListVentaDetalle.Add(oVta_Venta_DetalleBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListVentaDetalle;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

        public List<Vta_VentaBE> ListaRegistroVenta(int _case, string filtro)
        {
            List<Vta_VentaBE> oListVenta = new List<Vta_VentaBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_VTA_LC_VENTA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@case", SqlDbType.Int).Value = _case;
                        oSqlCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Vta_VentaBE oVta_VentaBE = new Vta_VentaBE();
                                oVta_VentaBE.i_idVenta = (int)(oSqlDataReader["i_idVenta"]);
                                oVta_VentaBE.dt_fchRegistro = (DateTime)(oSqlDataReader["dt_fchRegistro"]);
                                oVta_VentaBE.oUsuario.oPersona.nombreCompleto = (string)(oSqlDataReader["nombreUsuario"]);
                                oVta_VentaBE.oPersona.nombreCompleto = (string)(oSqlDataReader["nombreCliente"]);
                                //oVta_VentaBE.oComprobante.oTipo_ComprobanteBE.vc_dscpTipComprobante = (string)(oSqlDataReader["vc_dscpTipComprobante"]);
                                //oVta_VentaBE.oComprobante.i_idComprobante = (int)(oSqlDataReader["i_idComprobante"]);
                                //oVta_VentaBE.oComprobante.vc_numComprobante = (string)(oSqlDataReader["vc_numComprobante"]);
                                //oVta_VentaBE.oTipoEstado.vc_dscpTipEstado = (string)(oSqlDataReader["vc_dscpTipEstado"]);
                                oVta_VentaBE.subTotal = (decimal)(oSqlDataReader["subtotal"]);
                                oVta_VentaBE.igv = (decimal)(oSqlDataReader["igv"]);
                                oVta_VentaBE.total = (decimal)(oSqlDataReader["total"]);
                                oVta_VentaBE.oListVentaDetalle = ListaRegistroVentaDetalle(oVta_VentaBE.i_idVenta);
                                oListVenta.Add(oVta_VentaBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListVenta;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}