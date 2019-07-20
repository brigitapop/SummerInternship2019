using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestClass]
    public class CartTests
    {
        private Mock<ITimeService> _timeService;

        public CartTests()
        {
            _timeService = new Mock<ITimeService>();
            _timeService.Setup(t => t.Now()).Returns(DateTime.Now);
        }

        [TestMethod]
        public void Add_WhenAnItemsIsAdded_TheQuantityShouldBeGreaterThanZero()
        {
            //Arrange
            Cart cart = new Cart(_timeService.Object);

            //Act && Assert
            Assert.ThrowsException<Exception>(
                () => cart.AddItem(new CartItem("Detergent", 0, 12, true)));
        }

        [TestMethod]
        public void Add_ForItemsThatCostLessThan1Dollar_TheQuantityShouldBeAtLeastTwo()
        {
            //Arrange
            Cart cart = new Cart(_timeService.Object);

            //Act && Assert
            Assert.ThrowsException<Exception>(
                () => cart.AddItem(new CartItem("Detergent", 1, 0.5, true)));
        }

        [TestMethod]
        public void Add_WhenAnItemIsAdded_TheCartDateIsUpdated()
        {
            //Arrange
            _timeService.Setup(t => t.Now()).Returns(new DateTime(2019, 7, 24));
            Cart cart = new Cart(_timeService.Object);

            //Act
            cart.AddItem(new CartItem("Detergent", 1, 1.5, true));

            //
            Assert.AreEqual(new DateTime(2019, 7, 24), cart.LastUpdate);
        }

        [TestMethod]
        public void Add_WhenAnItemIsAdded_TheTotalIsProperlyComputed()
        {
            //Arrange
            _timeService.Setup(t => t.Now()).Returns(new DateTime(2019, 7, 24));
            Cart cart = new Cart(_timeService.Object);

            //Act
            cart.AddItem(new CartItem("Detergent", 2, 1.5, true));
            cart.AddItem(new CartItem("Vegetables", 3, 0.5, true));
            cart.AddItem(new CartItem("Cafe", 1, 7, true));

            //
            Assert.AreEqual(11.5, cart.Total);
        }

        [TestMethod]
        public void Delete_WhenAnItemIsDeleted_TheCartDateIsUpdated()
        {
            //Arrange
            _timeService.Setup(t => t.Now()).Returns(new DateTime(2019, 7, 21));
            Cart cart = new Cart(_timeService.Object);
            cart.AddItem(new CartItem("Detergent", 2, 1.5, true));
            cart.AddItem(new CartItem("Vegetables", 3, 0.5, true));
            cart.AddItem(new CartItem("Cafe", 1, 7, true));

            _timeService.Setup(t => t.Now()).Returns(new DateTime(2019, 7, 22));

            //Act
            cart.DeleteItem("Detergent");

            //Assert
            Assert.AreEqual(new DateTime(2019, 7, 22), cart.LastUpdate);
        }


        [TestMethod]
        public void Delete_WhenAnItemIsDeleted_TheTotalIsProperlyComputed()
        {
            //Arrange
            _timeService.Setup(t => t.Now()).Returns(new DateTime(2019, 7, 24));
            Cart cart = new Cart(_timeService.Object);
            cart.AddItem(new CartItem("Detergent", 2, 1.5, true));
            cart.AddItem(new CartItem("Vegetables", 3, 0.5, true));
            cart.AddItem(new CartItem("Cafe", 1, 7, true));

            //Act
            cart.DeleteItem("Detergent");

            //Assert
            Assert.AreEqual(8.5, cart.Total);
        }

    }
}
