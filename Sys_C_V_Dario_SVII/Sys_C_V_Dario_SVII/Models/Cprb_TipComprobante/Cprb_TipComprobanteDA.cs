using Sys_C_V_Dario_SVII.Models.Sys_Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Cprb_TipComprobante
{
    public class Cprb_TipComprobanteDA
    {
        public List<Cprb_TipComprobanteBE> ListarTipcomprobante(int _case, string filtro)
        {
            try
            {
                SqlConnection objSqlConnection = Conexion.GetConexion();
                objSqlConnection.Open();
                List<Cprb_TipComprobanteBE> objListTipComprobante = new List<Cprb_TipComprobanteBE>();
                Cprb_TipComprobanteBE objTipComprobante;          //sp_list_Caj_Turno_listar
                SqlCommand objSqlCommand = new SqlCommand("sp_list_Cprb_Tipo_Comprobante_listar", objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add(new SqlParameter("@case", _case));
                objSqlCommand.Parameters.Add(new SqlParameter("@filtro", filtro));
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    objTipComprobante = new Cprb_TipComprobanteBE();
                    objTipComprobante.st_codTipoComprobante = (string)objSqlDataReader["c_codTipComprobante"];
                    objTipComprobante.st_dscpTipComprobante = (string)objSqlDataReader["vc_dscpTipComprobante"];
                    objListTipComprobante.Add(objTipComprobante);
                }
                objSqlDataReader.Close();
                objSqlConnection.Close();
                return objListTipComprobante;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}