using BusinessLayer.Classes;
using BusinessLayer.DB_Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class DB_PaypalService : IDB_PaypalService
    {
        private const string CONNECTION_STRING = "Server=mssqlstud.fhict.local;Database=dbi507545_voedseldb;User Id=dbi507545_voedseldb;Password=Voedsel1!;TrustServerCertificate=True;";
        public bool UpdatePaymentStatus(Payments orderlist)
        {
            try
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();

                string listText = string.Join(',', orderlist.OrderIdList);
                Console.Write(listText);

                string query = $"UPDATE Orders SET paid = 1 WHERE id IN ({listText})";
                SqlCommand updatePaidCommand = new SqlCommand(query, connection);

                updatePaidCommand.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
