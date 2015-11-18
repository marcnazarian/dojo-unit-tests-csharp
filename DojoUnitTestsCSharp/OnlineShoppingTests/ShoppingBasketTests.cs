// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingBasketTests.cs" company="Persistent Systems">
//   Persistent Systems
// </copyright>
// <summary>
//   The shopping basket tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OnlineShoppingTests
{
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
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.shoppingBasket = new ShoppingBasket();
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
        public void CanAddAnItemIntoMyBasket()
        {
            // arrange
            ShoppingItem myItem = new ShoppingItem();

            // act
            this.shoppingBasket.AddItem(myItem);

            // assert
            Assert.That(this.shoppingBasket.GetNumberOfItems(), Is.EqualTo(1), "Basket should contain 1 item");
        }
    }
}