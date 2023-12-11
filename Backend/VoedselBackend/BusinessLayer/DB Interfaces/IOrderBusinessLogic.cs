using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DB_Interfaces
{
    public interface IOrderBusinessLogic
    {
        bool AddOrderDB(Order order);
        List<Order>? ReadOrdersDB();
        bool DeleteOrderDB(int id);
        List<Order> GetUnpaidOrdersByTableNumber(int tableNumber);
    }
}
