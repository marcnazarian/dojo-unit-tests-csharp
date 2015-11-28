﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingBasket.cs" company="Persistent Systems">
//   Persistent Systems
// </copyright>
// <summary>
//   Shopping basket
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShoppingBasket
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Shopping basket
    /// </summary>
    public class ShoppingBasket
    {
        /// <summary>
        /// The shipping charges.
        /// </summary>
        private const double ShippingCharges = 10;

        /// <summary>
        /// The items.
        /// </summary>
        private readonly List<ShoppingItem> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingBasket"/> class.
        /// </summary>
        public ShoppingBasket()
        {
            this.items = new List<ShoppingItem>();    
        }

        /// <summary>
        /// Add an item into the shopping basket
        /// </summary>
        /// <param name="shoppingItem">
        /// The shopping item to add into basket
        /// </param>
        public void AddItem(ShoppingItem shoppingItem)
        {
            InventoryService inventoryService = new InventoryService();

            if (!inventoryService.IsItemAvailable(shoppingItem))
            {
                throw new Exception("Item is not available anymore.");
            }
            
            this.items.Add(shoppingItem);
        }

        /// <summary>
        /// Returns the number of items into the shopping basket
        /// </summary>
        /// <returns>
        /// The number of Items into the shopping basket
        /// </returns>
        public int GetNumberOfItems()
        {
            return this.items.Count;
        }

        /// <summary>
        /// The is empty.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsEmpty()
        {
            return this.GetNumberOfItems() == 0;
        }

        /// <summary>
        /// The get price.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetPrice()
        {
            double totalPrice = 0;

            foreach (ShoppingItem item in this.items)
            {
                totalPrice += item.Price;
            }

            return totalPrice + ShippingCharges;
        }

        /// <summary>
        /// The get content description.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetContentDescription()
        {
            string contentDescription = string.Empty;

            foreach (ShoppingItem item in this.items)
            {
                string itemDescription = string.Format("{0}: ${1}", item.Name, item.Price);

                contentDescription += itemDescription;
            }

            return contentDescription;
        }
    }
}