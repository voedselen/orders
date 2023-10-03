using BusinessLayer;

namespace DBLayer
{
    public interface IDB_AccessOrder
    {
        bool AddOrderDB(Order order);
        List<Order>? ReadOrdersDB();
    }
}