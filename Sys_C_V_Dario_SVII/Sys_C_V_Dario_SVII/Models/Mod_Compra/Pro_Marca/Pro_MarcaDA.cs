using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Compra.Pro_Marca
{
    public class Pro_MarcaDA
    {
        
        public List<Pro_MarcaBE> ListaRegistroMarca(string dato)
        {
            List<Pro_MarcaBE> oListPro_MarcaBE = new List<Pro_MarcaBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_PRO_LC_MARCA", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Pro_MarcaBE oPro_MarcaBE = new Pro_MarcaBE();
                                oPro_MarcaBE.i_idMarca = (int)(oSqlDataReader["i_idMarca"]);
                                oPro_MarcaBE.vc_dscpMarca = (string)(oSqlDataReader["vc_dscpMarca"]);
                                oListPro_MarcaBE.Add(oPro_MarcaBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListPro_MarcaBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}