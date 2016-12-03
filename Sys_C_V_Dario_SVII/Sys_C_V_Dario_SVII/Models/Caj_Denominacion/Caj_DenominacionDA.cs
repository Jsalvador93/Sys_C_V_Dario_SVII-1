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
        public Boolean InsertarRegistro(Caj_DenominacionBE objDenominacion)
        {
            SqlConnection objSqlConnection = Conexion.GetConexion();


            //SqlTransaction objSqlTransaction = objSqlConnection.BeginTransaction();
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_Registrar_Caj_Denominacion", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@b_ver", objDenominacion.bl_ver));
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchRegistro", objDenominacion.dt_fchRegistro));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_descripcion", objDenominacion.st_descpDenominacion));
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
                    objDenominacion.st_descpDenominacion = (string)objSqlDataReader["vc_dscpDenominacion"];
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