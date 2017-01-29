using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Sys_C_V_Dario_SVII.Models.Sys_Conexion;

namespace Sys_C_V_Dario_SVII.Models.Rp_ReporteProducto
{
    public class ReporteProductoDA
    {
        public List<ReporteProductoBE> ListarProductoReporte(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<ReporteProductoBE> objListReporteProducto = new List<ReporteProductoBE>();
                ReporteProductoBE objReporteProducto;          //sp_list_Caj_Denominacion_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Rp_Producto_listar_1", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objReporteProducto = new ReporteProductoBE();
                    objReporteProducto.objProRgtrProductoBE.dt_fchRegistro = (DateTime)objSqlDataReader["dt_fchRgtrProducto"];
                    objReporteProducto.objProProductoBE.c_codProducto = (string)objSqlDataReader["c_codProducto"];
                    objReporteProducto.objProProductoBE.oSeccionBE.vc_dscpSeccion = (string)objSqlDataReader["vc_dscpSeccion"];
                    objReporteProducto.objProProductoBE.oTipoProductoBE.vc_dscpTipProducto = (string)objSqlDataReader["vc_dscpTipProducto"];
                    objReporteProducto.objProProductoBE.oMarcaBE.vc_dscpMarca = (string)objSqlDataReader["vc_dscpMarca"];
                    objReporteProducto.objProPrecioBE.f_prcCompra = (float)objSqlDataReader["f_prcCompra"];
                    objReporteProducto.objProPrecioBE.f_prcVenta= (float)objSqlDataReader["f_prcVenta"];
                    objListReporteProducto.Add(objReporteProducto);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListReporteProducto;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}