namespace BusinessLayer
{
    public interface IDB_AccessOrder
    {
        bool AddOrderDB(Order order);
        List<Order>? ReadOrdersDB();
    }
}