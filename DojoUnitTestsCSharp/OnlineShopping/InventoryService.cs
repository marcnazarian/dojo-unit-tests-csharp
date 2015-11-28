// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Persistent Systems" file="InventoryService.cs">
//   Persistent Systems
// </copyright>
// <summary>
//   The inventory service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShoppingBasket
{
    using System.Linq;

    /// <summary>
    /// The inventory service.
    /// </summary>
    public class InventoryService : IInventoryService
    {
        /// <summary>
        /// The is item available.
        /// </summary>
        /// <param name="shoppingItem">
        /// The shopping item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsItemAvailable(ShoppingItem shoppingItem)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            return databaseContext.Inventory.Any(item => item.Id == shoppingItem.Id);
        }
    }
}
