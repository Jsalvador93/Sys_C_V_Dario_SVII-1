using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sys_C_V_Dario_SVII.Models.Sys_Conexion
{
    public class Conexion
    {
        public static SqlConnection GetConexion()
        {
            string lStrCadConex = ConfigurationManager.ConnectionStrings["cnnDb_C_V_DarioF"].ConnectionString;
            SqlConnection connexion = new SqlConnection(lStrCadConex);
            return connexion;
        }
    }
}