using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Motivo_Traslado
{
    public class Cprb_Motivo_TrasladoDA
    {
        public List<Cprb_Motivo_TrasladoBE> ListaMotivoTraslado(string dato)
        {
            List<Cprb_Motivo_TrasladoBE> oListMotivoTrasladoBE = new List<Cprb_Motivo_TrasladoBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_MOTIVO_TRASLADO", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read()) 
                            {
                                Cprb_Motivo_TrasladoBE oCprb_Motivo_TrasladoBE = new Cprb_Motivo_TrasladoBE();
                                oCprb_Motivo_TrasladoBE.i_idMtvTraslado = (int)(oSqlDataReader["i_idMtvTraslado"]);
                                oCprb_Motivo_TrasladoBE.vc_dscpMtvTraslado = (string)(oSqlDataReader["vc_dscpMtvTraslado"]);
                                oListMotivoTrasladoBE.Add(oCprb_Motivo_TrasladoBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListMotivoTrasladoBE;
                }

                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}