using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public class ShopItem
    {
        //InventoryItem item;
        int price;
    }

    public event Action OnChange;
    IEnumerable<ShopItem> GetFilteredItems(){return null;}
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
