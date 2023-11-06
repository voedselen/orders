using BusinessLayer;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;
using System.Collections;

namespace DBLayer
{
    public class DB_AccessOrder : IDB_AccessOrder
    {
        private const string CONNECTION_STRING = "Server=mssqlstud.fhict.local;Database=dbi507545_voedseldb;User Id=dbi507545_voedseldb;Password=Voedsel1!;TrustServerCertificate=True;";
        //add order into db
        public bool AddOrderDB(Order order)
        {
            try
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Orders (TotalPrice, TableNumber) " +
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
        //deletes order based on the order id
        public bool DeleteOrderDB(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
                string deleteCommand = ("Delete from Orders where ID = " + id.ToString() + ";");
                SqlCommand sqlCommand = new SqlCommand(deleteCommand, connection);
                int rowsAffected = sqlCommand.ExecuteNonQuery();
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
            List<Order> orders = new List<Order>();
            try
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            return orders;            
        }

        public List<MenuItem> ReadMenuItemsDb(int orderId)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            List<MenuItem> menuItems = new List<MenuItem>();

            connection.Open();
            SqlCommand readOrderItemCommand = new SqlCommand("select * from order_items where order_id=@order_id", connection);
            readOrderItemCommand.Parameters.AddWithValue("@order_id", orderId);
      
            SqlDataReader itemReaderCommand = readOrderItemCommand.ExecuteReader();
            while (itemReaderCommand.Read())
            {
                int ID = (int)itemReaderCommand["order_id"];
                string menuItem = (string)itemReaderCommand["menu_item"];
                int price = (int)itemReaderCommand["price"];
                MenuItem itemToAdd = new MenuItem(menuItem, price);
                menuItems.Add(itemToAdd);
            }

            connection.Close();
            return menuItems;
        }
    }
}