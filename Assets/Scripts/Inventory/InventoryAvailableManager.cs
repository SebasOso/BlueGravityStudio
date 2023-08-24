using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAvailableManager : MonoBehaviour
{
    public int[] objNumbers;

    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject pouch;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject oldSkin;
    [SerializeField] private GameObject currentSkin;
    private void Update() 
    {
        UpdateClothes();
    }
    private void UpdateClothes()
    {
        if(objNumbers[0] == 0)
        {
            axe.SetActive(false);
        }
        if(objNumbers[1] == 0)
        {
            oldSkin.SetActive(false);
            currentSkin.SetActive(true);
        }
        if(objNumbers[2] == 0)
        {
            sword.SetActive(false);
        }
        if(objNumbers[3] == 0)
        {
            pouch.SetActive(false);
        }
    }
}
