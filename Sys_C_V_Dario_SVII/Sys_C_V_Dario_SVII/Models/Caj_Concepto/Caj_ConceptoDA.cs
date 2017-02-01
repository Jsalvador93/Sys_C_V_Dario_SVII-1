using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Sys_C_V_Dario_SVII.Models.Sys_Conexion;

namespace Sys_C_V_Dario_SVII.Models.Caj_Concepto
{
    public class Caj_ConceptoDA
    {
        SqlConnection objSqlConnection = Conexion.GetConexion();
        public Boolean InsertarRegistro(Caj_ConceptoBE objConcepto)
        {


            //SqlTransaction objSqlTransaction = objSqlConnection.BeginTransaction();
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_ins_Caj_Concepto_registrar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@dt_fchRegistro", objConcepto.dt_fchRegistro));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpConcepto", objConcepto.st_dscpConcepto));
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idDenominacion", objConcepto.objDenominacionBE.in_idDenominacion));
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

        public Boolean QuitarConcepto(Caj_ConceptoBE objConcepto)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_del_Caj_Concepto_eliminar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idConcepto", objConcepto.in_idConcepto));
                objSqlCommand.Parameters.Add(new SqlParameter("@b_ver", objConcepto.bl_ver));
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

        public Caj_ConceptoBE ConsultarConcepto(int in_idConcepto)
        {
            try
            {
                objSqlConnection.Open();
                Caj_ConceptoBE objConcepto;
                SqlCommand objSqlCommand = new SqlCommand("sp_sel_Caj_Concepto_seleccionar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idConcepto", in_idConcepto));
                SqlDataReader objSqlDateReader = objSqlCommand.ExecuteReader();
                if (objSqlDateReader.Read())
                {
                    objConcepto = new Caj_ConceptoBE();
                    objConcepto.in_idConcepto = (int)objSqlDateReader["i_idConcepto"];
                    objConcepto.bl_ver = (bool)objSqlDateReader["b_ver"];
                    objConcepto.dt_fchRegistro = (DateTime)(objSqlDateReader["dt_fchRegistro"]);
                    objConcepto.st_dscpConcepto = (string)objSqlDateReader["vc_dscpConcepto"];
                    objConcepto.objDenominacionBE.in_idDenominacion = (int)objSqlDateReader["i_idDenominacion"];
                    objConcepto.objDenominacionBE.st_dscpDenominacion = (string)objSqlDateReader["vc_dscpDenominacion"];
                    return objConcepto;
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
        public Boolean ModificarConcepto(Caj_ConceptoBE objConcepto)
        {
            try
            {
                objSqlConnection.Open();
                SqlCommand objSqlCommand = new SqlCommand("sp_upd_Caj_Concepto_actualizar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //  objSqlCommand.Transaction = objSqlTransaction;
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idConcepto", objConcepto.in_idConcepto));
                objSqlCommand.Parameters.Add(new SqlParameter("@vc_dscpConcepto", objConcepto.st_dscpConcepto));
                objSqlCommand.Parameters.Add(new SqlParameter("@i_idDenominacion", objConcepto.objDenominacionBE.in_idDenominacion));
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
        public List<Caj_ConceptoBE> ListarConcepto(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Caj_ConceptoBE> objListConcepto = new List<Caj_ConceptoBE>();
                Caj_ConceptoBE objConcepto;          //sp_list_Caj_Concepto_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Caj_Concepto_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objConcepto = new Caj_ConceptoBE();
                    objConcepto.in_idConcepto = (int)objSqlDataReader["i_idConcepto"];
                    objConcepto.bl_ver = (bool)objSqlDataReader["b_ver"];
                    objConcepto.dt_fchRegistro = (DateTime)objSqlDataReader["dt_fchRegistro"];
                    objConcepto.st_dscpConcepto = (string)objSqlDataReader["vc_dscpConcepto"];
                    objConcepto.objDenominacionBE.in_idDenominacion = (int)objSqlDataReader["i_idDenominacion"];
                    objConcepto.objDenominacionBE.st_dscpDenominacion = (string)objSqlDataReader["vc_dscpDenominacion"];
                    objListConcepto.Add(objConcepto);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListConcepto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}