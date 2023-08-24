using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    [SerializeField] private GameObject sellAxe;
    [SerializeField] private GameObject sellPouch;
    [SerializeField] private GameObject sellSword;
    [SerializeField] private GameObject sellOldSkin;
    [SerializeField] private List<GameObject> objSell = new List<GameObject>();
    [SerializeField] Money money;
    [SerializeField] InventoryAvailableManager invNumbers;

    private void Update() 
    {
        for (int i = 0; i < invNumbers.objNumbers.Length; i++)
        {
            if(invNumbers.objNumbers[i] == 1)
            {
                objSell[i].SetActive(true);
            }
            else if(invNumbers.objNumbers[i] == 0)
            {
                objSell[i].SetActive(false);
            }
        }
    }
    public void SellAxe()
    {
        sellAxe.SetActive(false);
        money.AddMoney(50);
        invNumbers.objNumbers[0] = 0;
    }
    public void SellOldSkin()
    {
        sellOldSkin.SetActive(false);
        money.AddMoney(220);
        invNumbers.objNumbers[1] = 0;
    }
    public void SellSword()
    {
        sellSword.SetActive(false);
        money.AddMoney(50);
        invNumbers.objNumbers[2] = 0;
    }
    public void SellPouch()
    {
        sellPouch.SetActive(false);
        money.AddMoney(50);
        invNumbers.objNumbers[3] = 0;
    }
}
