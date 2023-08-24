using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopAxe;
    [SerializeField] private GameObject shopPouch;
    [SerializeField] private GameObject shopSword;
    [SerializeField] private GameObject shopOldSkin;
    [SerializeField] private List<GameObject> objShop = new List<GameObject>();
    [SerializeField] Money money;
    [SerializeField] InventoryAvailableManager invNumbers;
    private void Update() 
    {
        for (int i = 0; i < invNumbers.objNumbers.Length; i++)
        {
            if(invNumbers.objNumbers[i] == 1)
            {
                objShop[i].SetActive(false);
            }
            else if(invNumbers.objNumbers[i] == 0)
            {
                objShop[i].SetActive(true);
            }
        }
    }
    public void BuyAxe()
    {
        shopAxe.SetActive(false);
        money.SubtractMoney(50);
        invNumbers.objNumbers[0] = 1;
    }
    public void BuyOldSkin()
    {
        shopOldSkin.SetActive(false);
        money.SubtractMoney(220);
        invNumbers.objNumbers[1] = 1;
    }
    public void BuySword()
    {
        shopSword.SetActive(false);
        money.SubtractMoney(50);
        invNumbers.objNumbers[2] = 1;
    }
    public void BuyPouch()
    {
        shopPouch.SetActive(false);
        money.SubtractMoney(50);
        invNumbers.objNumbers[3] = 1;
    }

}
