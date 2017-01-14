using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Guia_Remision
{
    public class Cprb_Guia_RemisionDA
    {
        public List<Cprb_Guia_RemisionBE> ListaRegistroGuiaRemision(string dato)
        {
            List<Cprb_Guia_RemisionBE> oListCprb_Guia_Remision = new List<Cprb_Guia_RemisionBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_GUIA_REMISION", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_Guia_RemisionBE oCprb_Guia_RemisionBE = new Cprb_Guia_RemisionBE();
                                oCprb_Guia_RemisionBE.oComprobanteBE.i_idComprobante = (int)(oSqlDataReader["i_idComprobante"]);
                                oCprb_Guia_RemisionBE.oMotivo_TrasladoBE.i_idMtvTraslado = (int)(oSqlDataReader["i_idMtvTraslado"]);
                                oListCprb_Guia_Remision.Add(oCprb_Guia_RemisionBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCprb_Guia_Remision;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }

    }
}