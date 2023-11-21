using BusinessLayer.DB_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool AddOrderDB(Order order)
        {
            try
            {
                if (order == null || order.ID < 0 || order.OrderItems.Count <= 0 || order.TotalPrice == 0)
                {
                    return false;
                }
                else
                {
                    return dB_AccessOrder.AddOrderDB(order);
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
            List<Order> orders = dB_AccessOrder.ReadOrdersDB();
            foreach(Order order in orders)
            {
                order.OrderItems = dB_AccessOrder.ReadMenuItemsDb(order.ID);
            }

            return orders;
        }
    }
}
