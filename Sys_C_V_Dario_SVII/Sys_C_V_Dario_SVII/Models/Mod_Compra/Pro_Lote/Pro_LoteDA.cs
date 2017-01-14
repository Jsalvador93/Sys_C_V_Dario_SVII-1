using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Lote
{
    public class Pro_LoteDA
    {
        public List<Pro_Lote_DetalleBE> ListaRegistroLoteDetalle(byte dato)
        {
            List<Pro_Lote_DetalleBE> oListLoteDetalle = new List<Pro_Lote_DetalleBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    string strCondicion = string.Empty;
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_LOTE_DETALLE", conexion))
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
                                Pro_Lote_DetalleBE oPro_DetalleBE = new Pro_Lote_DetalleBE();
                                oPro_DetalleBE.oLoteBE.i_idLote = (byte)(oSqlDataReader["i_idLote"]);
                                oPro_DetalleBE.oProductoBE.vc_dscpProducto = (string)(oSqlDataReader["vc_dscpProducto"]);
                                oPro_DetalleBE.dt_fchIgrLote = (DateTime)(oSqlDataReader["dt_fchIgrLote"]);
                                oPro_DetalleBE.f_cantidad = (double)(oSqlDataReader["f_cantidad"]);
                                oPro_DetalleBE.oUnidProducto.oUnidCompra.vc_dscpUnidad = (string)(oSqlDataReader["unidCompra"]);
                                oPro_DetalleBE.oUnidProducto.oUnidVenta.vc_dscpUnidad = (string)(oSqlDataReader["unidVenta"]);
                                oListLoteDetalle.Add(oPro_DetalleBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListLoteDetalle;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

        public List<Pro_LoteBE> ListaRegistroLote(int _case, string filtro)
        {
            List<Pro_LoteBE> oListLote = new List<Pro_LoteBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_LOTE", conexion))
                    {
                        oSqlCommand.Parameters.Add("@case", SqlDbType.Int).Value = _case;
                        oSqlCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_LoteBE oPro_LoteBE = new Pro_LoteBE();
                                oPro_LoteBE.i_idLote = (byte)(oSqlDataReader["i_idLote"]);
                                oPro_LoteBE.dt_fchFabricacion = (DateTime)(oSqlDataReader["dt_fchFabricacion"]);
                                oPro_LoteBE.dt_fchVencimiento = (DateTime)(oSqlDataReader["dt_fchVencimiento"]);
                                oPro_LoteBE.totalCantidad = (double)(oSqlDataReader["totalCantidad"]);
                                oPro_LoteBE.oListLoteDetalle = ListaRegistroLoteDetalle(oPro_LoteBE.i_idLote);
                                oListLote.Add(oPro_LoteBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListLote;
                }
                catch (System.Exception e)
                {
                    
                    return null;
                }
            }
        }
    }
}