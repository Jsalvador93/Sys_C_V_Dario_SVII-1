using Sys_C_V_Dario_SVII.Models.Sys_Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Caj_Caja
{
    public class Caj_CajaDA
    {
        public Boolean InsertarRegistro(Caj_CajaBE objCaja)
        {
            SqlConnection objSqlConnection = Conexion.GetConexion();


            //SqlTransaction objSqlTransaction = objSqlConnection.BeginTransaction();
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ins_Caj_Caja_insertar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@b_ver", objCaja.bl_ver));
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchRegistro", objCaja.dt_fchRegistro));
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchIngreso", objCaja.dt_fchIngreso));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpCaja", objCaja.st_dscpCaja));
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idPtoVenta", objCaja.objPtoVenta.in_idPtoVenta));
                objSqlCommand.ExecuteNonQuery();
                //objSqlTransaction.Commit();
                objSqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                objSqlConnection.Close();
                return false;
            }
        }
        public List<Caj_CajaBE> ListarCaja(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Caj_CajaBE> objListCaja = new List<Caj_CajaBE>();
                Caj_CajaBE objCaja;          //sp_list_Caj_Caja_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Caj_Caja_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    
                    objCaja = new Caj_CajaBE();
                    objCaja.in_idCaja = (int)objSqlDataReader["i_idCaja"];
                    objCaja.st_dscpCaja = (string)objSqlDataReader["vc_dscpCaja"];
                    objCaja.bl_ver = (bool)objSqlDataReader["b_ver"];
                    objCaja.objPtoVenta.in_idPtoVenta = (int)objSqlDataReader["i_idPtoVenta"];
                    objCaja.objPtoVenta.st_dscpPtoVenta = (string)objSqlDataReader["vc_nombre"];
                    objCaja.dt_fchIngreso = (DateTime)objSqlDataReader["dt_fchIngreso"];
                    objListCaja.Add(objCaja);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListCaja;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}