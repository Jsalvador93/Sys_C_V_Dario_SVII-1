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

        private SqlConnection objSqlConnection = Conexion.GetConexion();
        public Boolean RegistrarCaja(Caj_CajaBE objCaja)
        {
            //SqlTransaction objSqlTransaction = objSqlConnection.BeginTransaction();
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ins_Caj_Caja_registrar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchRegistro", objCaja.dt_fchRegistro/*.ToString("MM/dd/yyyy HH:mm:ss")*/ ) ) ;
                objSqlCommand.Parameters.Add(new SqlParameter("@d_fchIngreso", objCaja.d_fchIngreso/*.ToString("MM/dd/yyyy HH:mm:ss")*/));
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

        public Boolean EliminarCaja(int in_idCaja)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_del_Caj_Caja_eliminar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idCaja", in_idCaja));
                objSqlCommand.ExecuteNonQuery();
                objSqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                objSqlConnection.Close();
                return false;
            }
        }

        public Caj_CajaBE ConsultarCaja( int in_idCaja)
        {
            try
            {
                objSqlConnection.Open();
                Caj_CajaBE objCaja;
                SqlCommand objSqlCommand = new SqlCommand("sp_sel_Caj_Caja_seleccionar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add( new SqlParameter( "@i_idCaja" , in_idCaja ) );
                SqlDataReader objSqlDateReader = objSqlCommand.ExecuteReader();
                if (objSqlDateReader.Read())
                {
                    objCaja = new Caj_CajaBE();
                    objCaja.in_idCaja = (int)objSqlDateReader["i_idCaja"];
                    objCaja.bl_ver = (bool)objSqlDateReader["b_ver"];
                    objCaja.dt_fchRegistro = (DateTime)(objSqlDateReader["dt_fchRegistro"]);
                    objCaja.d_fchIngreso = (DateTime)objSqlDateReader["d_fchIngreso"];
                    objCaja.st_dscpCaja = (string)objSqlDateReader["vc_dscpCaja"];
                    objCaja.objPtoVenta.in_idPtoVenta = (int)objSqlDateReader["i_idPtoVenta"];
                    objCaja.objPtoVenta.st_dscpPtoVenta = (string)objSqlDateReader["vc_nombre"];
                    objCaja.objPtoVenta.objSucursal.in_idSucursal = (int)objSqlDateReader["i_idSucursal"];
                    objCaja.objPtoVenta.objSucursal.st_dscpSucursal = (string)objSqlDateReader["vc_dscpSucursal"];
                    return objCaja;
                }
                objSqlConnection.Close();
                return null;
            }
            catch(Exception e )
            {
                objSqlConnection.Close();
                return null;
            }
        }

        public Boolean ModificarCaja( Caj_CajaBE objCaja , int in_idCaja )
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_upd_Caj_Caja_actualizar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idCaja", objCaja.in_idCaja));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpCaja", objCaja.st_dscpCaja));
                objSqlCommand.Parameters.Add(new SqlParameter("@d_fchIngreso", objCaja.dt_fchRegistro));
                objSqlCommand.ExecuteNonQuery();
                objSqlConnection.Close();
                return true;
            }
            catch(Exception e )
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
                    objCaja.d_fchIngreso = (DateTime)objSqlDataReader["d_fchIngreso"];
                    objCaja.objPtoVenta.objSucursal.in_idSucursal = (int)objSqlDataReader["i_idSucursal"];
                    objCaja.objPtoVenta.objSucursal.st_dscpSucursal = (string)objSqlDataReader["vc_dscpSucursal"];
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