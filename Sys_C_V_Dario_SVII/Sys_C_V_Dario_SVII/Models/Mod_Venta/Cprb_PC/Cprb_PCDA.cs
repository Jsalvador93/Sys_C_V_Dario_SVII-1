using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_PC
{
    public class Cprb_PCDA
    {
        public List<Cprb_PCBE> ListaRegistroPC(string dato)
        {
            List<Cprb_PCBE> oListCprb_PCBE = new List<Cprb_PCBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_PC", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_PCBE oCprb_PCBE = new Cprb_PCBE();
                                oCprb_PCBE.i_idPc = (int)(oSqlDataReader["i_idPc"]);
                                oCprb_PCBE.vc_ip = (string)(oSqlDataReader["vc_ip"]);
                                oListCprb_PCBE.Add(oCprb_PCBE);
                            }

                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCprb_PCBE;
                }

                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}