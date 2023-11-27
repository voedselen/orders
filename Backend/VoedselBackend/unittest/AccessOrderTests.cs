using BusinessLayer;
using BusinessLayer.DB_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BusinessLayer.Tests
{
    [TestClass]
    public class AccessOrdersTests
    {
        private Mock<IDB_AccessOrder> mockDBAccessOrder;
        private AccessOrders accessOrders;

        [TestInitialize]
        public void Initialize()
        {
            mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            accessOrders = new AccessOrders(mockDBAccessOrder.Object);
        }
        [TestMethod]
        public void AddOrderDB_ValidOrder_ReturnsTrue()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var order = new Order
            {
                ID = 1,
                OrderItems = new List<MenuItem> { new MenuItem("Item1", 10), new MenuItem("Item2", 15) },
                OrderTable = 2,
                TotalPrice = 3
            };

            mockDBAccessOrder.Setup(db => db.AddOrderDB(It.IsAny<Order>())).Returns(true);

            // Act
            var result = accessOrders.AddOrderDB(order);

            // Assert
            Assert.IsTrue(result);
            mockDBAccessOrder.Verify(db => db.AddOrderDB(It.IsAny<Order>()), Times.Once);
        }

        [TestMethod]
        public void AddOrderDB_InvalidOrder_ReturnsFalse()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var order = new Order(); // Invalid order

            // Act
            var result = accessOrders.AddOrderDB(order);

            // Assert
            Assert.IsFalse(result);
            mockDBAccessOrder.Verify(db => db.AddOrderDB(It.IsAny<Order>()), Times.Never);
        }

        [TestMethod]
        public void DeleteOrderDB_ValidOrderId_ReturnsTrue()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var orderId = 1;

            mockDBAccessOrder.Setup(db => db.DeleteOrderDB(orderId)).Returns(true);

            // Act
            var result = accessOrders.DeleteOrderDB(orderId);

            // Assert
            Assert.IsTrue(result);
            mockDBAccessOrder.Verify(db => db.DeleteOrderDB(orderId), Times.Once);
        }

        [TestMethod]
        public void ReadOrdersDB_ValidOrders_ReturnsOrdersWithItems()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var ordersFromDb = new List<Order>
            {
                new Order { ID = 1, OrderTable = 2 },
                new Order { ID = 2, OrderTable = 3 }
            };

            mockDBAccessOrder.Setup(db => db.ReadOrdersDB()).Returns(ordersFromDb);
            mockDBAccessOrder.Setup(db => db.ReadMenuItemsDb(It.IsAny<int>()))
                            .Returns(new List<MenuItem> { new MenuItem("Item1", 10), new MenuItem("Item2", 15) });

            // Act
            var result = accessOrders.ReadOrdersDB();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ordersFromDb.Count, result.Count);

            foreach (var order in result)
            {
                Assert.IsNotNull(order.OrderItems);
                Assert.AreEqual(2, order.OrderItems.Count);
            }

            mockDBAccessOrder.Verify(db => db.ReadOrdersDB(), Times.Once);
            mockDBAccessOrder.Verify(db => db.ReadMenuItemsDb(It.IsAny<int>()), Times.Exactly(ordersFromDb.Count));
        }

        [TestMethod]
        public void ReadOrdersDB_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            mockDBAccessOrder.Setup(db => db.ReadOrdersDB()).Returns(new List<Order>());

            // Act
            var result = accessOrders.ReadOrdersDB();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);

            mockDBAccessOrder.Verify(db => db.ReadOrdersDB(), Times.Once);
            mockDBAccessOrder.Verify(db => db.ReadMenuItemsDb(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void AddOrderDB_NullOrder_ReturnsFalse()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            Order order = null;

            // Act
            var result = accessOrders.AddOrderDB(order);

            // Assert
            Assert.IsFalse(result);
            mockDBAccessOrder.Verify(db => db.AddOrderDB(It.IsAny<Order>()), Times.Never);
        }

        [TestMethod]
        public void AddOrderDB_NegativeOrderId_ReturnsFalse()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var order = new Order { ID = -1, OrderItems = new List<MenuItem>(), OrderTable = 1 };

            // Act
            var result = accessOrders.AddOrderDB(order);

            // Assert
            Assert.IsFalse(result);
            mockDBAccessOrder.Verify(db => db.AddOrderDB(It.IsAny<Order>()), Times.Never);
        }

        [TestMethod]
        public void AddOrderDB_EmptyOrderItems_ReturnsFalse()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var order = new Order { ID = 1, OrderItems = new List<MenuItem>(), OrderTable = 1 };

            // Act
            var result = accessOrders.AddOrderDB(order);

            // Assert
            Assert.IsFalse(result);
            mockDBAccessOrder.Verify(db => db.AddOrderDB(It.IsAny<Order>()), Times.Never);
        }

        [TestMethod]
        public void AddOrderDB_NullOrderItems_ReturnsFalse()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var order = new Order { ID = 1, OrderTable = 1 };

            // Act
            var result = accessOrders.AddOrderDB(order);

            // Assert
            Assert.IsFalse(result);
            mockDBAccessOrder.Verify(db => db.AddOrderDB(It.IsAny<Order>()), Times.Never);
        }

        [TestMethod]
        public void AddOrderDB_ValidOrderWithItems_ReturnsTrue()
        {
            // Arrange
            var mockDBAccessOrder = new Mock<IDB_AccessOrder>();
            var accessOrders = new AccessOrders(mockDBAccessOrder.Object);

            var order = new Order
            {
                ID = 1,
                OrderItems = new List<MenuItem> { new MenuItem("Item1", 10), new MenuItem("Item2", 15) },
                OrderTable = 2,
                TotalPrice = 5
            };

            mockDBAccessOrder.Setup(db => db.AddOrderDB(It.IsAny<Order>())).Returns(true);

            // Act
            var result = accessOrders.AddOrderDB(order);

            // Assert
            Assert.IsTrue(result);
            mockDBAccessOrder.Verify(db => db.AddOrderDB(It.IsAny<Order>()), Times.Once);
        }
    }
}
