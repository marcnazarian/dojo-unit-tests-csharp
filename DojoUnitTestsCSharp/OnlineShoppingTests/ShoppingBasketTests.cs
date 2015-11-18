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
        /// The basket should contain 0 items after initialization.
        /// </summary>
        [Test]
        public void BasketShouldContainZeroItemsAfterInitialization()
        {
            // arrange
            ShoppingBasket shoppingBasket = new ShoppingBasket();
            
            // act
            int numberOfItems = shoppingBasket.GetNumberOfItems();

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
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            // act
            bool isBasketEmpty = shoppingBasket.IsEmpty();

            // assert
            Assert.That(isBasketEmpty, Is.True, "Basket should be empty");
        }
    }
}