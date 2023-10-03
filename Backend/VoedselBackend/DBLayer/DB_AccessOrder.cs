using BusinessLayer;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class DB_AccessOrder
    {
        private const string CONNECTION_STRING = "Server=mssqlstud.fhict.local;Database=dbi507545_voedseldb;User Id=dbi507545_voedseldb;Password=Voedsel1!;";
        //add order into db
        public bool AddOrderDB(Order order)
        {
            try
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Order (TotalPrice, TableNumber) " +
                    "VALUES (@TotalPrice, @TableNumber)", connection);
                insertCommand.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                insertCommand.Parameters.AddWithValue("@TableNumber", order.OrderTable);
                insertCommand.ExecuteNonQuery();
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