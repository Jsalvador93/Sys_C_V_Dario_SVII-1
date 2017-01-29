using Sys_C_V_Dario_SVII.Models.Sys_Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Caj_LibroCaja
{
    public class Caj_LibroCajaDA
    {
        public List<Caj_LibroCajaBE> ListarLibroCaja( int _case , string filtro )
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Caj_LibroCajaBE> objListLibroCaja = new List<Caj_LibroCajaBE>();
                Caj_LibroCajaBE objLibroCaja;          //sp_list_Caj_LibroCaja_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Caj_LibroCaja_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objLibroCaja = new Caj_LibroCajaBE();
                    objLibroCaja.in_idLibroCaja = (int)objSqlDataReader["i_idLibroCaja"];
                    objLibroCaja.dt_fchDesde = (DateTime)objSqlDataReader["dt_fchDesde"];
                    objLibroCaja.dt_fchHasta = (DateTime)objSqlDataReader["dt_fchHasta"];
                    objLibroCaja.dt_fchRegistro = (DateTime)objSqlDataReader["dt_fchRegistro"];
                    objLibroCaja.fl_mntSdoCaja = (float)(double)objSqlDataReader["f_mntSdoCaja"];
                    objLibroCaja.fl_mntCajChica = (float)(double)objSqlDataReader["f_mntCajChica"];
                    objLibroCaja.fl_totIngreso = (float)(double)objSqlDataReader["f_totIngreso"];
                    objLibroCaja.fl_totEgreso = (float)(double)objSqlDataReader["f_totEgreso"];
                    objListLibroCaja.Add(objLibroCaja);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListLibroCaja;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}