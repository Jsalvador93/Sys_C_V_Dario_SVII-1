using Sys_C_V_Dario_SVII.Models.Sys_Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Emp_PtoVenta
{
    public class Emp_PtoVentaDA
    {
        public List<Emp_PtoVentaBE> ListarPtoVenta( int _case , string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Emp_PtoVentaBE> objListPtoVenta = new List<Emp_PtoVentaBE>();
                Emp_PtoVentaBE objPtoVenta;          //sp_list_Emp_Sucursal_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Emp_Punto_Venta_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {

                    objPtoVenta = new Emp_PtoVentaBE();
                    objPtoVenta.in_idPtoVenta = (int)objSqlDataReader["i_idPtoVenta"];
                    objPtoVenta.st_dscpPtoVenta = (string)objSqlDataReader["vc_dscpPtoVenta"];
                    objPtoVenta.objSucursal.in_idSucursal = (int)objSqlDataReader["ti_idSucursal"];
                    objPtoVenta.objSucursal.st_dscpSucursal = (string)objSqlDataReader["vc_dscpSucursal"];
                    objPtoVenta.dt_fchRegistro = (DateTime)objSqlDataReader["dt_fchRegistro"];
                    objListPtoVenta.Add(objPtoVenta);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListPtoVenta;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}