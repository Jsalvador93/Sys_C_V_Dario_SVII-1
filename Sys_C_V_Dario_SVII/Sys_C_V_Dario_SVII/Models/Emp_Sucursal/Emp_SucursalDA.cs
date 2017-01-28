using Sys_C_V_Dario_SVII.Models.Sys_Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Emp_Sucursal
{
    public class Emp_SucursalDA
    {
        public List<Emp_SucursalBE> ListarSucursal(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Emp_SucursalBE> objListSucursal = new List<Emp_SucursalBE>();
                Emp_SucursalBE objSucursal;          //sp_list_Emp_Sucursal_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Emp_Sucursal_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {

                    objSucursal = new Emp_SucursalBE();
                    objSucursal.in_idSucursal = (int)objSqlDataReader["ti_idSucursal"];
                    objSucursal.st_dscpSucursal = (string)objSqlDataReader["vc_dscpSucursal"];
                    objListSucursal.Add(objSucursal);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListSucursal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Emp_SucursalBE> ListarSucursalPtoVenta(string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Emp_SucursalBE> objListSucursal = new List<Emp_SucursalBE>();
                Emp_SucursalBE objSucursal;          //sp_list_Emp_Sucursal_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Emp_Sucursal_Emp_Punto_Venta_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {

                    objSucursal = new Emp_SucursalBE();
                    objSucursal.in_idSucursal = (int)objSqlDataReader["ti_idSucursal"];
                    objSucursal.st_dscpSucursal = (string)objSqlDataReader["vc_dscpSucursal"];
                    objListSucursal.Add(objSucursal);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListSucursal;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}