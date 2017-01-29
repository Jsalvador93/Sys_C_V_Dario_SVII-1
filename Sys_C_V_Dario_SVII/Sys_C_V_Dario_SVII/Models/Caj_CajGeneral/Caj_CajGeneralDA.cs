using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Sys_C_V_Dario_SVII.Models.Sys_Conexion;
using System.Data;

namespace Sys_C_V_Dario_SVII.Models.Caj_CajGeneral
{
    public class Caj_CajGeneralDA
    {
        
       
        SqlConnection objSqlConnection = Conexion.GetConexion();
        public Boolean InsertarRegistro(Caj_CajGeneralBE objCajGeneral)
        {


            //SqlTransaction objSqlTransaction = objSqlConnection.BeginTransaction();
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ins_Caj_CajGeneral_registrar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@d_fchInicio", objCajGeneral.dt_fchInicio));
                objSqlCommand.Parameters.Add(new SqlParameter("@d_fchFin", objCajGeneral.dt_fchFin));
                objSqlCommand.Parameters.Add(new SqlParameter("@f_mntCajChica", objCajGeneral.fl_mntCajChica));
                objSqlCommand.Parameters.Add(new SqlParameter("@f_mntSdoCaja", objCajGeneral.fl_mntSdoCaja));
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchRegistro", objCajGeneral.dt_fchRegistro));
                objSqlCommand.ExecuteNonQuery();
                //objSqlTransaction.Commit();
                objSqlConnection.Close();
                return true;//values(@d_fchInicio,@d_fchFin, @f_mntCajChica , @f_mntSdoCaja, @dt_fchRegistro)
            }
            catch (Exception e)
            {
                objSqlConnection.Close();
                return false;
            }
        }

        public Boolean QuitarCajGeneral(Caj_CajGeneralBE objCajGeneral)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_del_Caj_CajGeneral_eliminar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idCajGeneral", objCajGeneral.in_idCajGeneral));
                objSqlCommand.Parameters.Add(new SqlParameter("@b_ver", objCajGeneral.bl_ver));
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

        public Caj_CajGeneralBE ConsultarCajGeneral(int in_idCajGeneral)
        {
            try
            {
                objSqlConnection.Open();
                Caj_CajGeneralBE objCajGeneral;
                SqlCommand objSqlCommand = new SqlCommand("sp_sel_Caj_CajGeneral_seleccionar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idCajGeneral", in_idCajGeneral));
                SqlDataReader objSqlDateReader = objSqlCommand.ExecuteReader();
                if (objSqlDateReader.Read())
                {
                    objCajGeneral = new Caj_CajGeneralBE();
                    objCajGeneral.in_idCajGeneral = (int)objSqlDateReader["i_idCajGeneral"];
                    objCajGeneral.bl_ver = (bool)objSqlDateReader["b_ver"];
                    objCajGeneral.dt_fchRegistro = (DateTime)(objSqlDateReader["dt_fchRegistro"]);
                    objCajGeneral.dt_fchInicio = (DateTime)objSqlDateReader["d_fchInicio"];
                    objCajGeneral.dt_fchFin = (DateTime)objSqlDateReader["d_fchFin"];
                    objCajGeneral.fl_mntCajChica = (float)(double)objSqlDateReader["f_mntCajChica"];
                    objCajGeneral.fl_mntSdoCaja = (float)(double)objSqlDateReader["f_mntSdoCaja"];
                    return objCajGeneral;
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
        public Boolean ModificarCajGeneral(Caj_CajGeneralBE objCajGeneral)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_upd_Caj_CajGeneral_actualizar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idCajGeneral", objCajGeneral.in_idCajGeneral));
                objSqlCommand.Parameters.Add(new SqlParameter("@d_fchInicio", objCajGeneral.dt_fchInicio));
                objSqlCommand.Parameters.Add(new SqlParameter("@d_fchFin", objCajGeneral.dt_fchFin));
                objSqlCommand.Parameters.Add(new SqlParameter("@f_mntCajChica", objCajGeneral.fl_mntCajChica));
                objSqlCommand.Parameters.Add(new SqlParameter("@f_mntSdoCaja", objCajGeneral.fl_mntSdoCaja));
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
        public List<Caj_CajGeneralBE> ListarCajGeneral(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Caj_CajGeneralBE> objListCajGeneral = new List<Caj_CajGeneralBE>();
                Caj_CajGeneralBE objCajGeneral;          //sp_list_Caj_CajGeneralBE_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Caj_CajGeneral_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objCajGeneral = new Caj_CajGeneralBE();
                    objCajGeneral.in_idCajGeneral = (int)objSqlDataReader["i_idCajGeneral"];
                    objCajGeneral.bl_ver = (bool)objSqlDataReader["b_ver"];
                    objCajGeneral.dt_fchInicio = (DateTime)objSqlDataReader["d_fchInicio"];
                    objCajGeneral.dt_fchFin = (DateTime)objSqlDataReader["d_fchFin"];
                    objCajGeneral.fl_mntCajChica = (float)(double)objSqlDataReader["f_mntCajChica"];
                    objCajGeneral.fl_mntSdoCaja = (float)(double)objSqlDataReader["f_mntSdoCaja"];
              
                    objListCajGeneral.Add(objCajGeneral);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListCajGeneral;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<Caj_CajGeneralBE> ListarCajGeneralIntervalo( DateTime dt_fchDesde , DateTime dt_fchHasta)
        {
            List<Caj_CajGeneralBE> objListCajGeneral = new List<Caj_CajGeneralBE>();
            foreach( var item in ListarCajGeneral( 0 , "" ))
            {
                if( dt_fchDesde.CompareTo(item.dt_fchInicio) <= 0 && dt_fchHasta.CompareTo(item.dt_fchFin) >= 0 )
                {
                    objListCajGeneral.Add(item);
                }
            }
            return objListCajGeneral;
        }
        //sp_del_Caj_CajGeneral_eliminar
    }
}