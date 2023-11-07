using BusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        //test if adding correct orders works
        [TestMethod]
        public void TestCorrectAddOrder()
        {
            AccessOrders accessOrders = new AccessOrders(new FakeDB_AccessOrder());
            Order order = new Order(2, 23,
                new List<MenuItem>()
                {
                    new MenuItem("Item1", 23)
                }, 2);
            Assert.IsTrue(accessOrders.AddOrderDB(order));
        }
        //test if adding an order with an incorrect id returns an error
        [TestMethod]
        public void TestIncorrectAddOrder()
        {
            AccessOrders accessOrders = new AccessOrders(new FakeDB_AccessOrder());
            Order order = new Order(-2, 23,
                new List<MenuItem>()
                {
                    new MenuItem("Item1", 23)
                }, 2);
            Assert.IsFalse(accessOrders.AddOrderDB(order));
        }
    }
}