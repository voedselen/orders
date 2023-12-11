namespace BusinessLayer
{
    public interface IDB_AccessOrder
    {
        bool AddOrderDB(Order order);
        List<Order>? ReadOrdersDB();
        bool DeleteOrderDB(int id);
        List<MenuItem> ReadMenuItemsDb(int orderId);
        List<Order> GetUnpaidOrdersByTableNumber(int tableNumber);
    }
}