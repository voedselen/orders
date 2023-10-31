using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccessOrders
    {
        readonly IDB_AccessOrder dB_AccessOrder;
        public AccessOrders(IDB_AccessOrder dB_AccessOrder) 
        {
            this.dB_AccessOrder = dB_AccessOrder;
        }
        public bool AddOrder(int id, double totalprice, List<MenuItem> menuItems, int orderTable)
        {
            Order order = new Order(id, totalprice, menuItems, orderTable);
            return dB_AccessOrder.AddOrderDB(order);
        }
        public bool DeleteOrder(int id)
        {
            return dB_AccessOrder.DeleteOrderDB(id);
        }
        public List<Order>? ReadOrders()
        {
            return dB_AccessOrder.ReadOrdersDB();
        }
    }
}
