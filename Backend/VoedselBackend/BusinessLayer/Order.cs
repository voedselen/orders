using System.Security.AccessControl;

namespace BusinessLayer
{
    public class Order
    {
        private int iD;
        private double totalPrice;
        private List<MenuItem> orderItems = new List<MenuItem>();
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
    }
}