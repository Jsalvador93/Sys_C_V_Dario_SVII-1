using Sys_C_V_Dario_SVII.Models.Sys_Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Caj_Turno
{
    public class Caj_TurnoDA
    {
        SqlConnection objSqlConnection = Conexion.GetConexion();
        public Boolean InsertarRegistro(Caj_TurnoBE objTurno)
        {


            //SqlTransaction objSqlTransaction = objSqlConnection.BeginTransaction();
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ins_Caj_Turno_registrar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchRegistro", objTurno.dt_fchRegistro));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpTurno", objTurno.st_dscpTurno));
                objSqlCommand.Parameters.Add(new SqlParameter("@tm_hrInicio", objTurno.st_hrInicio));
                objSqlCommand.Parameters.Add(new SqlParameter("@tm_hrFin", objTurno.st_hrFin));
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

        public Boolean QuitarTurno(Caj_TurnoBE objTurno)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_del_Caj_Turno_eliminar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idTurno", objTurno.in_idTurno));
                objSqlCommand.Parameters.Add(new SqlParameter("@b_ver", objTurno.bl_ver));
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

        public Caj_TurnoBE ConsultarTurno(int in_idTurno)
        {
            try
            {
                objSqlConnection.Open();
                Caj_TurnoBE objTurno;
                SqlCommand objSqlCommand = new SqlCommand("sp_sel_Caj_Turno_seleccionar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idTurno", in_idTurno));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                if (objSqlDataReader.Read())
                {
                    objTurno = new Caj_TurnoBE();
                    objTurno.in_idTurno = (int)objSqlDataReader["i_idTurno"];
                    objTurno.bl_ver = (bool)objSqlDataReader["b_ver"];
                    objTurno.dt_fchRegistro = (DateTime)(objSqlDataReader["dt_fchRegistro"]);
                    objTurno.st_dscpTurno = (string)objSqlDataReader["vc_dscpTurno"];
                    objTurno.st_hrInicio = (string)(objSqlDataReader["tm_hrInicio"]);
                    objTurno.st_hrFin = (string)objSqlDataReader["tm_hrFin"];
                    return objTurno;
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
        public Boolean ModificarTurno(Caj_TurnoBE objTurno)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_upd_Caj_Turno_actualizar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idTurno", objTurno.in_idTurno));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpTurno", objTurno.st_dscpTurno));
                objSqlCommand.Parameters.Add(new SqlParameter("@tm_hrInicio", objTurno.st_hrInicio));
                objSqlCommand.Parameters.Add(new SqlParameter("@tm_hrFin", objTurno.st_hrFin));
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
        public List<Caj_TurnoBE> ListarTurno(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Caj_TurnoBE> objListTurno = new List<Caj_TurnoBE>();
                Caj_TurnoBE objTurno;          //sp_list_Caj_Turno_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Caj_Turno_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objTurno = new Caj_TurnoBE();
                    objTurno.in_idTurno = (int)objSqlDataReader["i_idTurno"];
                    objTurno.bl_ver = (bool)objSqlDataReader["b_ver"];
                    objTurno.dt_fchRegistro = (DateTime)objSqlDataReader["dt_fchRegistro"];
                    objTurno.st_dscpTurno = (string)objSqlDataReader["vc_dscpTurno"];
                    objTurno.st_hrInicio = (string)(objSqlDataReader["tm_hrInicio"]);
                    objTurno.st_hrFin = (string)objSqlDataReader["tm_hrFin"];
                    objListTurno.Add(objTurno);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListTurno;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}