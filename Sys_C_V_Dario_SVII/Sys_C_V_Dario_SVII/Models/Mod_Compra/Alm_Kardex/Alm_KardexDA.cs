using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Alm_Kardex
{
    public class Alm_KardexDA
    {
        public List<Alm_Kardex_DetalleBE> ListaRegistroKardexDetalle(int dato)
        {
            List<Alm_Kardex_DetalleBE> oListKardexDetalle = new List<Alm_Kardex_DetalleBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    string strCondicion = string.Empty;
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_KARDEX_DETALLE", conexion))
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
                                Alm_Kardex_DetalleBE oKardex_DetalleBE = new Alm_Kardex_DetalleBE();
                                oKardex_DetalleBE.i_idKrdDetalle = (int)(oSqlDataReader["i_idKrdDetalle"]);
                                oKardex_DetalleBE.f_cntExistencia = (double)(oSqlDataReader["f_cntExistencia"]);
                                oKardex_DetalleBE.f_cantidad = (double)(oSqlDataReader["f_cantidad"]);
                                oKardex_DetalleBE.dt_fchOperacion = (DateTime)(oSqlDataReader["dt_fchOperacion"]);
                                oKardex_DetalleBE.oKardex.i_idKardex = (int)(oSqlDataReader["i_idKardex"]);
                                oKardex_DetalleBE.oMotivoOperacion.i_idMtvOperacion = (int)(oSqlDataReader["i_idMtvOperacion"]);

                                //<---- INTEGRAR PUNTO DE VENTA

                                oListKardexDetalle.Add(oKardex_DetalleBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListKardexDetalle;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

        public List<Alm_KardexBE> ListaRegistroKardex(int dato)
        {
            List<Alm_KardexBE> oListKardex = new List<Alm_KardexBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_KARDEX", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Alm_KardexBE oAlm_KardexBE = new Alm_KardexBE();
                                oAlm_KardexBE.i_idKardex = (int)(oSqlDataReader["i_idKardex"]);
                                oAlm_KardexBE.dt_fchInicio = (DateTime)(oSqlDataReader["dt_fchInicio"]);
                                oAlm_KardexBE.dt_fchFin = (DateTime)(oSqlDataReader["dt_fchFin"]);
                                oAlm_KardexBE.b_krdNaturaleza = (Boolean)(oSqlDataReader["b_krdNaturaleza"]);
                                oAlm_KardexBE.oProductoBE.c_codProducto = (string)(oSqlDataReader["c_codProducto "]);
                                //<---- Punto de Vista
                                //oAlm_KardexBE.oListKardexDetalle = ListaRegistroKardexDetalle(oAlm_KardexBE.i_idKardex);
                                oListKardex.Add(oAlm_KardexBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListKardex;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}