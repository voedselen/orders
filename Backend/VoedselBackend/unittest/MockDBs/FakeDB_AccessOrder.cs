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

        public List<MenuItem> ReadMenuItemsDb(int orderId)
        {
            if (orderId == 1)
            {
                return new List<MenuItem>()
                {
                    new MenuItem("Food1", 1),
                    new MenuItem("Food2", 2)
                };
            }
            else if (orderId == 2)
            {
                return new List<MenuItem>()
                {
                    new MenuItem("Food1", 1),
                    new MenuItem("Food2", 2)
                };
            }
            else if (orderId == 3)
            {
                return new List<MenuItem>()
                {
                    new MenuItem("Food1", 1),
                    new MenuItem("Food2", 2)
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
                new Order(1, 21, ReadMenuItemsDb(1), 2),
                new Order(2, 34, ReadMenuItemsDb(2), 3),
                new Order(3, 22, ReadMenuItemsDb(3), 1)
            };
        }
    }
}
