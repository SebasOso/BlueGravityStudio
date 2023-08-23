using System.Collections;
using System.Collections.Generic;
using Datsumo.Inventories;
using UnityEngine;

namespace Datsumo.Shops
{
    public class ShopItem
    {
        InventoryItem item;
        int availability;
        int price;

        public ShopItem(InventoryItem item, int availability, int price)
        {
            this.item = item;
            this.availability = availability;
            this.price = price;
        }
    }
}
