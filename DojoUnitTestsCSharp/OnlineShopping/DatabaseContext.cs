// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Persistent Systems" file="DatabaseContext.cs">
//   Persistent Systems
// </copyright>
// <summary>
//   The database context.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace ShoppingBasket
{
    using System.Data.Entity;

    /// <summary>
    /// The database context.
    /// </summary>
    public class DatabaseContext
    {
        /// <summary>
        /// Gets or sets the inventory.
        /// </summary>
        public DbSet<ShoppingItem> Inventory { get; set; }
    }
}
