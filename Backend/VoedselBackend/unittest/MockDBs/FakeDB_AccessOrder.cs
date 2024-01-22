using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace UnitTests
{
    public class FakeDB_AccessOrder : IDB_AccessOrder
    {
        public bool AddOrderDB(Order order)
        {
            if (order != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteOrderDB(int id)
        {
            if (id !< 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Order> GetUnpaidOrdersByTableNumber(int tableNumber)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> ReadMenuItemsDb(int orderId)
        {
            if (orderId == 1)
            {
                return new List<MenuItem>()
                {
                    new MenuItem(12, "Food1", 1),
                    new MenuItem(13, "Food2", 2)
                };
            }
            else if (orderId == 2)
            {
                return new List<MenuItem>()
                {
                    new MenuItem(15, "Food1", 1),
                    new MenuItem(17, "Food2", 2)
                };
            }
            else if (orderId == 3)
            {
                return new List<MenuItem>()
                {
                    new MenuItem(12, "Food1", 1),
                    new MenuItem(12, "Food2", 2)
                };
            }
            else
            {
                return new List<MenuItem>();
            }
        }

        public List<Order>? ReadOrdersDB()
        {
            return new List<Order>
            {
                new Order(1, new List<MenuItem>(), 1),
                new Order(2, new List<MenuItem>(), 2),
                new Order(3, new List < MenuItem >(), 3)
            };
        }
    }
}
