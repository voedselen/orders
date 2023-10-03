using System.Security.AccessControl;

namespace BusinessLayer
{
    public class Order
    {
        public int ID;
        private double totalPrice;
        public List<MenuItem> OrderItems = new List<MenuItem>();
        private int orderTable;
        public int OrderTable
        {
            get { return orderTable; }
            set { orderTable = value; }
        }
        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public Order(int iD, double totalPrice, List<MenuItem> orderItems, int orderTable)
        {
            this.ID = iD;
            this.OrderItems = orderItems;
            this.orderTable = orderTable;
            this.totalPrice = totalPrice;
        }
        public void AddMenuItem(string name, int price)
        {
            OrderItems.Add(new MenuItem(name, (double)price));
        }
    }
}