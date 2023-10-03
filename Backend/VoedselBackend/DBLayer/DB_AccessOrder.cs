using BusinessLayer;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

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
        public List<Order>? ReadOrdersDB()
        {
            try
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
                List<Order> orders = new List<Order>();
                SqlCommand readOrderCommand = new SqlCommand("SELECT * FROM Orders", connection);
                //read orders
                SqlDataReader readerCommand = readOrderCommand.ExecuteReader();
                while (readerCommand.Read())
                {
                    int ID = (int)readerCommand["ID"];
                    int price = (int)readerCommand["TotalPrice"];
                    int table = (int)readerCommand["TableNumber"];
                    Order order = new Order(ID, price, new List<MenuItem>(), table);
                    orders.Add(order);
                }
                readerCommand.Close();
                //reads orders but not the menuitems relevant to them, add code for this
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}