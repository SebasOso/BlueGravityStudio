using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datsumo.Inventories;
using Datsumo.Shops;

public class Shop : MonoBehaviour
{
    public void SelectFilter(ItemCategory category){}
    public event Action OnChange;
    IEnumerable<ShopItem> GetFilteredItems()
    {
        yield return new ShopItem(InventoryItem.GetFromID("20fc5297-21d0-4934-af6b-1ea83139dc7f"), 1, 50);
        yield return new ShopItem(InventoryItem.GetFromID("dd37daf4-4ade-41fc-a659-d4d158d521df"), 1, 50);
        yield return new ShopItem(InventoryItem.GetFromID("90cda3a4-24f7-42f4-898a-54d526c68eac"), 1, 50);
        yield return new ShopItem(InventoryItem.GetFromID("ef5b0f35-f514-4feb-8333-80b5f9d98f10"), 1, 50);
    }
    public void ConfirmTransaction()
    {

    }
    public void SelectMode(bool isBuying)
    {

    }
    public bool IsBuyingMode()
    {
        return true;
    }
    public bool CanTransact()
    {
        return true;
    }
    public float TransactionTotal()                                      
    {
        return 0;
    }
}
