using BusinessLayer;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;
using System.Collections;
using System.Data;

namespace DBLayer
{
    public class DB_AccessOrder : IDB_AccessOrder
    {
        private const string CONNECTION_STRING = "Server=mssqlstud.fhict.local;Database=dbi507545_voedseldb;User Id=dbi507545_voedseldb;Password=Voedsel1!;TrustServerCertificate=True;";
        //add order into db
        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
        public bool AddOrderDB(Order order)
        {
            try
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Orders (TableNumber, Message, Paid) OUTPUT INSERTED.id " +
                    "VALUES (@TableNumber, @Message, @Paid)", connection);
                insertCommand.Parameters.AddWithValue("@TableNumber", order.OrderTable);
                insertCommand.Parameters.AddWithValue("@Message", order.OrderMsg);
                insertCommand.Parameters.AddWithValue("@Paid", order.paid);
                int orderID = Convert.ToInt32(insertCommand.ExecuteScalar());

                if (order.OrderItems.Count != 0)
                {
                    foreach (MenuItem menuItem in order.OrderItems)
                    {
                        SqlCommand insertItemCommand = new SqlCommand("INSERT INTO order_items (order_id, menu_item, price)" +
                    "VALUES (@Order_id, @Menu_item, @Price)", connection);
                        insertItemCommand.Parameters.AddWithValue("@Order_id", orderID);
                        insertItemCommand.Parameters.AddWithValue("@Menu_item", menuItem.name);
                        insertItemCommand.Parameters.AddWithValue("@Price", menuItem.price);
                        insertItemCommand.ExecuteNonQuery();
                    }
                }
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
                string deleteItemCommand = ("Delete from order_items where order_id = " + id.ToString() + ";");
                SqlCommand sqlItemCommand = new SqlCommand(deleteItemCommand, connection);
                sqlItemCommand.ExecuteNonQuery();
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
                    int table = (int)readerCommand["TableNumber"];
                    bool? isPaid = null;
                    if (readerCommand["paid"] != DBNull.Value)
                    {
                        byte paidByte = (byte)readerCommand["paid"];
                        isPaid = paidByte != 0; // Assuming 0 means false, any other value means true
                    }
                    string? message = readerCommand["message"] as string;
                    if (readerCommand["message"] != DBNull.Value)
                    {
                        message = (string)readerCommand["message"];
                    }
                    Order order = new Order(ID, new List<MenuItem>(), table, message, isPaid);
                    orders.Add(order);
                }
                readerCommand.Close();
                foreach (Order order in orders)
                {
                    SqlCommand readItemsCommand = new SqlCommand("SELECT * from order_items where order_ID = " + order.ID.ToString() + ";", connection);
                    //read items
                    SqlDataReader readerItemsCommand = readItemsCommand.ExecuteReader();
                    while (readerItemsCommand.Read())
                    {
                        int price = (int)readerItemsCommand["price"];
                        string name = (string)readerItemsCommand["menu_item"];
                        order.AddMenuItem(name, price);
                    }
                    readerItemsCommand.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            return orders;            
        }

        public List<MenuItem>? ReadMenuItemsDb(int orderId)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            List<MenuItem> menuItems = new List<MenuItem>();
            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        // Gets orders that are set as unpaid and the 
        public List<Order> GetUnpaidOrdersByTableNumber(int tableNumber)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    using (SqlCommand readOrderItemCommand = new SqlCommand("select id from Orders where tableNumber=@tableNumber AND paid = 0", connection))
                    {
                        readOrderItemCommand.Parameters.AddWithValue("@tableNumber", tableNumber);

                        using (SqlDataReader reader = readOrderItemCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderId = (int)reader["id"];
                                orders.Add(new Order(orderId, orderItems: ReadMenuItemsDb(orderId), tableNumber, false));
                            }
                        }
                    }
                }

                return orders;
            }
            catch (Exception)
            {
                throw new Exception("The backend-server could not fetch the requested data.");
            }
        }
    }
}