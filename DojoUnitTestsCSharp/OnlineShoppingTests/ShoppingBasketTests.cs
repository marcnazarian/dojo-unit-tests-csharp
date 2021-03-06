﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingBasketTests.cs" company="Persistent Systems">
//   Persistent Systems
// </copyright>
// <summary>
//   The shopping basket tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OnlineShoppingTests
{
    using Moq;

    using NUnit.Framework;

    using ShoppingBasket;

    /// <summary>
    /// The shopping basket tests.
    /// </summary>
    [TestFixture]
    public class ShoppingBasketTests
    {
        /// <summary>
        /// The shopping basket.
        /// </summary>
        private ShoppingBasket shoppingBasket;

        /// <summary>
        /// The inventory service mock.
        /// </summary>
        private Mock<IInventoryService> inventoryServiceMock;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.inventoryServiceMock = new Mock<IInventoryService>();
            this.inventoryServiceMock.Setup(inventory => inventory.IsItemAvailable(It.IsAny<ShoppingItem>())).Returns(true);

            this.shoppingBasket = new ShoppingBasket(this.inventoryServiceMock.Object);
        }

        /// <summary>
        /// The basket should contain 0 items after initialization.
        /// </summary>
        [Test]
        public void BasketShouldContainZeroItemsAfterInitialization()
        {
            // arrange
            
            // act
            int numberOfItems = this.shoppingBasket.GetNumberOfItems();

            // assert
            Assert.That(numberOfItems, Is.EqualTo(0), "Number of items into basket should be 0");
        }

        /// <summary>
        /// The basket should be empty after initialization.
        /// </summary>
        [Test]
        public void BasketShouldBeEmptyAfterInitialization()
        {
            // arrange

            // act
            bool isBasketEmpty = this.shoppingBasket.IsEmpty();

            // assert
            Assert.That(isBasketEmpty, Is.True, "Basket should be empty");
        }

        /// <summary>
        /// The can add an item into my basket.
        /// </summary>
        [Test]
        public void CanAddAnItemIntoMyBasketWhenItemIsAvailable()
        {
            // arrange
            ShoppingItem myItem = new ShoppingItem();
            
            // act
            this.shoppingBasket.AddItem(myItem);

            // assert
            Assert.That(this.shoppingBasket.GetNumberOfItems(), Is.EqualTo(1), "Basket should contain 1 item");

            // verify
            this.inventoryServiceMock.Verify(i => i.RemoveItem(myItem), Times.Once());
        }

        /// <summary>
        /// The should not add item into basket when item is not available.
        /// </summary>
        [Test]
        public void ShouldNotAddItemIntoBasketWhenItemIsNotAvailable()
        {
            // arrange
            ShoppingItem myItem = new ShoppingItem();
            this.inventoryServiceMock.Setup(inventory => inventory.IsItemAvailable(myItem)).Returns(false);

            // act 
            this.shoppingBasket.AddItem(myItem);

            // assert
            Assert.That(this.shoppingBasket.GetNumberOfItems(), Is.EqualTo(0), "Basket should not contain any item because item was not available");

            // verify
            this.inventoryServiceMock.Verify(i => i.RemoveItem(myItem), Times.Never);
        }

        /// <summary>
        /// The should not add item into basket when item is not available.
        /// </summary>
        [Test]
        public void ShouldOnlyAddAvailableItemsIntoBasket()
        {
            // arrange
            ShoppingItem availableItem1 = new ShoppingItem();
            this.inventoryServiceMock.Setup(inventory => inventory.IsItemAvailable(availableItem1)).Returns(true);

            ShoppingItem availableItem2 = new ShoppingItem();
            this.inventoryServiceMock.Setup(inventory => inventory.IsItemAvailable(availableItem2)).Returns(true);

            ShoppingItem outOfStockItem3 = new ShoppingItem();
            this.inventoryServiceMock.Setup(inventory => inventory.IsItemAvailable(outOfStockItem3)).Returns(false);

            ShoppingItem outOfStockItem4 = new ShoppingItem();
            this.inventoryServiceMock.Setup(inventory => inventory.IsItemAvailable(outOfStockItem4)).Returns(false);
            
            // act 
            this.shoppingBasket.AddItem(availableItem1);
            this.shoppingBasket.AddItem(availableItem2);
            this.shoppingBasket.AddItem(outOfStockItem3);
            this.shoppingBasket.AddItem(outOfStockItem4);

            // assert
            Assert.That(this.shoppingBasket.GetNumberOfItems(), Is.EqualTo(2), "Basket should contain only 2 items because other 2 are out of stock");

            // verify
            this.inventoryServiceMock.Verify(i => i.RemoveItem(It.IsAny<ShoppingItem>()), Times.Exactly(2));
        }

        /// <summary>
        /// I can get the number of items in my basket.
        /// </summary>
        [Test]
        public void CanGetTheNumberOfItemsInMyBasket()
        {
            // arrange
            ShoppingItem myItem1 = new ShoppingItem();
            ShoppingItem myItem2 = new ShoppingItem();
            ShoppingItem myItem3 = new ShoppingItem();

            // act
            this.shoppingBasket.AddItem(myItem1);
            this.shoppingBasket.AddItem(myItem2);
            this.shoppingBasket.AddItem(myItem3);

            // assert
            Assert.That(this.shoppingBasket.GetNumberOfItems(), Is.EqualTo(3), "Basket should contain 3 items");
        }

        /// <summary>
        /// The can get the price of a single item.
        /// </summary>
        /// <param name="itemPrice">
        /// The item Price.
        /// </param>
        /// <param name="expectedTotalBasketPrice">
        /// The expected Total Basket Price.
        /// </param>
        [TestCase(1.23, 11.23)]
        [TestCase(154.22, 164.22)]
        [TestCase(9.99, 19.99)]
        public void CanGetThePriceOfASingleItem(double itemPrice, double expectedTotalBasketPrice)
        {
            // arrange
            ShoppingItem myItem = new ShoppingItem { Price = itemPrice };

            // act
            this.shoppingBasket.AddItem(myItem);

            // assert
            Assert.That(this.shoppingBasket.GetPrice(), Is.EqualTo(expectedTotalBasketPrice).Within(0.0001), "Total price of the basket should be " + expectedTotalBasketPrice);
        }

        /// <summary>
        /// The can get the price of several items.
        /// </summary>
        [Test]
        public void CanGetThePriceOfSeveralItems()
        {
            // arrange
            ShoppingItem item1 = new ShoppingItem { Price = 5.21 };
            ShoppingItem item2 = new ShoppingItem { Price = 0.18 };
            ShoppingItem item3 = new ShoppingItem { Price = 145 };

            // act
            this.shoppingBasket.AddItem(item1);
            this.shoppingBasket.AddItem(item2);
            this.shoppingBasket.AddItem(item3);

            // assert
            Assert.That(this.shoppingBasket.GetPrice(), Is.EqualTo(160.39).Within(0.0001), "Total price of the basket should be 160.39 (150.39 + 10 for shipping)");
        }

        /// <summary>
        /// The can get the description of my basket.
        /// </summary>
        [Test]
        public void CanGetTheDescriptionOfMyBasket()
        {
            // arrange
            ShoppingItem item1 = new ShoppingItem { Price = 5.21, Name = "banana" };
            ShoppingItem item2 = new ShoppingItem { Price = 0.18, Name = "apple" };
            ShoppingItem item3 = new ShoppingItem { Price = 145, Name = "orange" };

            // act
            this.shoppingBasket.AddItem(item1);
            this.shoppingBasket.AddItem(item2);
            this.shoppingBasket.AddItem(item3);

            // assert
            Assert.That(this.shoppingBasket.GetContentDescription(), Is.StringContaining("banana: $5.21"));
            Assert.That(this.shoppingBasket.GetContentDescription(), Is.StringContaining("apple: $0.18"));
            Assert.That(this.shoppingBasket.GetContentDescription(), Is.StringContaining("orange: $145"));
        }
    }
}