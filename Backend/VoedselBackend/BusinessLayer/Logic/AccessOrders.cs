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
            return dB_AccessOrder.AddOrderDB(order);
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
