using BusinessLayer.DB_Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccessOrders : IOrderBusinessLogic
    {
        readonly IDB_AccessOrder dB_AccessOrder;
        public AccessOrders(IDB_AccessOrder dB_AccessOrder) 
        {
            this.dB_AccessOrder = dB_AccessOrder;
        }

        private bool SendOrderToStaffEnd(Order order)
        {
            try
            {
                    string url = "https://voedselen.nl/api/orders";

                    // Prepare the data to be sent in the POST request body
                    var requestData = new
                    {
                        restaurantId = order.RestaurantId,
                        tableId = order.OrderTable,
                        items = order.OrderItems.Select(item => new { menuItemId = item.id })
                    };

                    // Convert the requestData to JSON
                    string jsonBody = JsonConvert.SerializeObject(requestData);

                    // Create a WebClient to send the POST request
                    using (WebClient client = new WebClient())
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";

                        // Post the data to the specified endpoint
                        string response = client.UploadString(url, "POST", jsonBody);

                        // You can print or log the response if needed
                        Console.WriteLine(response);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }


        public bool AddOrderDB(Order order)
        {
            try
            {
                if (!order.OrderItems.Any())
                {
                    Console.WriteLine("No orderitems in this order!");
                    return false;
                }
                else
                {
                    if (order.paid == null)
                    {
                        order.paid = false;
                    }
                    
                    // Send order to staff database first
                    bool sendToStaffDatabase = SendOrderToStaffEnd(order);
                    if (sendToStaffDatabase)
                    {
                        // Add order to local database as well
                        return dB_AccessOrder.AddOrderDB(order);
                    }

                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //public bool AddOrder(int id, double totalprice, List<MenuItem> menuItems, int orderTable)
        //{
        //    Order order = new Order(id, totalprice, menuItems, orderTable);
        //    return dB_AccessOrder.AddOrderDB(order);
        //}
        public bool DeleteOrderDB(int id)
        {
            return dB_AccessOrder.DeleteOrderDB(id);
        }
        public List<Order>? ReadOrdersDB()
        {
            List<Order>? orders = dB_AccessOrder.ReadOrdersDB();
            return orders;
        }

        public List<Order> GetUnpaidOrdersByTableNumber(int tableNumber)
        {
            try
            {
                return dB_AccessOrder.GetUnpaidOrdersByTableNumber(tableNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
