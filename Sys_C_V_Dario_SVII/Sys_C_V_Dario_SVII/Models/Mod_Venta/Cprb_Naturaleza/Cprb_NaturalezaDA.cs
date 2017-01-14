using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Naturaleza
{
    public class Cprb_NaturalezaDA
    {
        public List<Cprb_NaturalezaBE> ListaRegistroNaturaleza(string dato)
        {
            List<Cprb_NaturalezaBE> oListCprb_NaturalezaBE = new List<Cprb_NaturalezaBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_NATURALEZA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_NaturalezaBE oCprb_Naturaleza = new Cprb_NaturalezaBE();
                                oCprb_Naturaleza.i_idNaturaleza = (int)(oSqlDataReader["i_idNaturaleza"]);
                                oCprb_Naturaleza.vc_dscpNaturaleza = (string)(oSqlDataReader["vc_dscpNaturaleza"]);
                                oListCprb_NaturalezaBE.Add(oCprb_Naturaleza);
                            }

                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCprb_NaturalezaBE;
                }

                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}