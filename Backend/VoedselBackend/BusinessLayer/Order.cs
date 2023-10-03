using System.Security.AccessControl;

namespace BusinessLayer
{
    public class Order
    {
        private int iD;
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
            this.iD = iD;
            this.OrderItems = orderItems;
            this.orderTable = orderTable;
            this.totalPrice = totalPrice;
        }
    }
}