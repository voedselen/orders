using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace BusinessLayer
{
    public class Order
    {
        [JsonIgnore]
        public int ID { get; set; }
        private double totalPrice;
        private string? orderMsg;
        public string? OrderMsg
        {
            get; set;
        }
        public List<MenuItem> OrderItems { get; set; }
        private int orderTable;
        public bool? paid { get; private set; }

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

        public Order()
        {
        }

        public Order(int iD, List<MenuItem> orderItems, int orderTable, string? orderMsg, bool? isPaid)
        {
            this.ID = iD;
            this.OrderItems = orderItems;
            this.orderTable = orderTable;
            this.paid = isPaid;
            this.orderMsg = orderMsg;
        }

        public Order(int id, List<MenuItem> orderItems, int orderTable)
        {
            this.ID = id;
            this.OrderItems = orderItems;
            this.orderTable = orderTable;
            this.paid = paid;
            this.orderMsg = "";
        }

        public Order(int id, List<MenuItem> orderItems, int orderTable, bool? paid)
        {
            this.ID = id;
            this.OrderItems = orderItems;
            this.orderTable = orderTable;
            this.orderMsg = "";
            this.paid = paid;
        }

        public void AddMenuItem(string name, int price)
        {
            OrderItems.Add(new MenuItem(name, (double)price));
        }
    }
}