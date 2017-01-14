using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sys_C_V_Dario_SVII.Models.Mod_Venta.Cprb_Ticket
{
    public class Cprb_TicketDA
    {
        public List<Cprb_TicketBE> ListaRegistroTicket(string dato)
        {
            List<Cprb_TicketBE> oListCpr_TicketBE = new List<Cprb_TicketBE>();
            using (SqlConnection conexion = Sys_Conexion.Conexion.GetConexion())
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand oSqlCommand = new SqlCommand("SP_CPRB_LC_TICKET", conexion))
                    {
                        oSqlCommand.Parameters.Add("@pDato", SqlDbType.VarChar).Value = dato;
                        oSqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader())
                        {
                            while (oSqlDataReader.Read())
                            {
                                Cprb_TicketBE oCprb_TicketBE = new Cprb_TicketBE();
                                oCprb_TicketBE.f_opGravada = (double)(oSqlDataReader["f_opGravada"]);
                                oCprb_TicketBE.f_opNoGravada = (double)(oSqlDataReader["f_opNoGravada"]);
                                oCprb_TicketBE.f_impTotTicket = (double)(oSqlDataReader)["f_impTotTicket"];
                                oCprb_TicketBE.oComprobanteBE.i_idComprobante = (int)(oSqlDataReader["i_idComprobante"]);
                                oListCpr_TicketBE.Add(oCprb_TicketBE);
                            }
                            oSqlDataReader.Close();
                        }
                    }
                    conexion.Close();
                    return oListCpr_TicketBE;
                }
                catch (System.Exception e)
                {

                    return null;
                }
            }
        }
    }
}