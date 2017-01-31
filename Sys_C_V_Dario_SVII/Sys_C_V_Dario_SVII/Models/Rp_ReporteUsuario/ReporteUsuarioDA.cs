using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Sys_C_V_Dario_SVII.Models.Sys_Conexion;

namespace Sys_C_V_Dario_SVII.Models.Rp_ReporteUsuario
{
    public class ReporteUsuarioDA
    {
        public List<ReporteUsuarioBE> ListarUsuarioReporte(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<ReporteUsuarioBE> objListReporteUsuario = new List<ReporteUsuarioBE>();
                ReporteUsuarioBE objReporteUsuario;          //sp_list_Caj_Denominacion_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Rp_Usuario_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objReporteUsuario = new ReporteUsuarioBE();
                    objReporteUsuario.objRolUsuarioBE.dt_fchRgtrUsuario = (DateTime)objSqlDataReader["dt_fchRgtrUsuario"];
                    objReporteUsuario.objRolUsuarioBE.oPersonaBE.st_drcWeb = (string)objSqlDataReader["vc_drcWeb"];
                    objReporteUsuario.objRolUsuarioBE.st_username = (string)objSqlDataReader["vc_username"];
                    objReporteUsuario.objRolUsuarioBE.oPersonaBE.st_apePaterno = (string)objSqlDataReader["vc_apePaterno"];
                    objReporteUsuario.objRolUsuarioBE.oPersonaBE.st_apeMaterno = (string)objSqlDataReader["vc_apeMaterno"];
                    objReporteUsuario.objRolUsuarioBE.oPersonaBE.st_nombreCompleto = (string)objSqlDataReader["vc_nomPersona"];
                    objReporteUsuario.objRolUsuarioBE.oRolBE.st_rolNombre = (string)objSqlDataReader["vc_rolNombre"];
                    objListReporteUsuario.Add(objReporteUsuario);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListReporteUsuario;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}