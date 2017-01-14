using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Caj_Denominacion;
using System.Data.SqlClient;
using System.Data;
using Sys_C_V_Dario_SVII.Models.Sys_Conexion;

namespace Sys_C_V_Dario_SVII.Models.Caj_Denominacion
{
    public class Caj_DenominacionDA
    {
        SqlConnection objSqlConnection = Conexion.GetConexion();
        public Boolean InsertarRegistro(Caj_DenominacionBE objDenominacion)
        {


            //SqlTransaction objSqlTransaction = objSqlConnection.BeginTransaction();
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ins_Caj_Denominacion_registrar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchRegistro", objDenominacion.dt_fchRegistro));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpDenominacion", objDenominacion.st_dscpDenominacion));
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

        public Boolean QuitarDenominacion( Caj_DenominacionBE objDenominacion )
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_del_Caj_Denominacion_eliminar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idDenominacion", objDenominacion.in_idDenominacion));
                objSqlCommand.Parameters.Add(new SqlParameter("@b_ver", objDenominacion.bl_ver));
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

        public Caj_DenominacionBE ConsultarDenominacion(int in_idDenominacion)
        {
            try
            {
                objSqlConnection.Open();
                Caj_DenominacionBE objDenominacion;
                SqlCommand objSqlCommand = new SqlCommand("sp_sel_Caj_Denominacion_seleccionar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idDenominacion", in_idDenominacion));
                SqlDataReader objSqlDateReader = objSqlCommand.ExecuteReader();
                if (objSqlDateReader.Read())
                {
                    objDenominacion = new Caj_DenominacionBE();
                    objDenominacion.in_idDenominacion = (int)objSqlDateReader["i_idDenominacion"];
                    objDenominacion.bl_ver = (bool)objSqlDateReader["b_ver"];
                    objDenominacion.dt_fchRegistro = (DateTime)(objSqlDateReader["dt_fchRegistro"]);
                    objDenominacion.st_dscpDenominacion = (string)objSqlDateReader["vc_dscpDenominacion"];
                    return objDenominacion;
                }
                objSqlConnection.Close();
                return null;
            }
            catch (Exception e)
            {
                objSqlConnection.Close();
                return null;
            }
        }
        public Boolean ModificarDenominacion(Caj_DenominacionBE objDenominacion)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_upd_Caj_Denominacion_actualizar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idDenominacion", objDenominacion.in_idDenominacion));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpDenominacion", objDenominacion.st_dscpDenominacion));
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
        public List<Caj_DenominacionBE> ListarDenominacion(int _case , string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Caj_DenominacionBE> objListDenominacion = new List<Caj_DenominacionBE>();
                Caj_DenominacionBE objDenominacion;          //sp_list_Caj_Denominacion_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Caj_Denominacion_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", _case == -1 ? "''" :filtro ));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objDenominacion = new Caj_DenominacionBE();
                    objDenominacion.in_idDenominacion = (int)objSqlDataReader["i_idDenominacion"];
                    objDenominacion.bl_ver = (bool)objSqlDataReader["b_ver"];
                    objDenominacion.dt_fchRegistro = (DateTime)objSqlDataReader["dt_fchRegistro"];
                    objDenominacion.st_dscpDenominacion = (string)objSqlDataReader["vc_dscpDenominacion"];
                    objListDenominacion.Add(objDenominacion);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListDenominacion;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}