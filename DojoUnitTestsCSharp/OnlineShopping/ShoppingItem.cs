// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingItem.cs" company="Persistent Systems">
//   Persistent Systems
// </copyright>
// <summary>
//   Shopping item
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShoppingBasket
{
    /// <summary>
    /// Shopping item
    /// </summary>
    public class ShoppingItem
    {
        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double Price { get; set; }
    }
}
