using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEquip : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject pouch;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject oldSkin;
    [SerializeField] private GameObject currentSkin;
    [SerializeField] private List<GameObject> icons;
    [SerializeField] private InventoryAvailableManager invNumbers;

    private void Start() 
    {
        CleanObjectsEquipped();
    }
    private void Update() 
    {
        for (int i = 0; i < invNumbers.objNumbers.Length; i++)
        {
            if(invNumbers.objNumbers[i] == 1)
            {
                icons[i].SetActive(true);
            }
            else if(invNumbers.objNumbers[i] == 0)
            {
                icons[i].SetActive(false);
            }
        }
    }
    public void EquipAxe()
    {
        axe.SetActive(true);
        sword.SetActive(false);
    }
    public void EquipOldSkin()
    {
        oldSkin.SetActive(true);
        currentSkin.SetActive(false);
    }
    public void EquipSkin()
    {
        currentSkin.SetActive(true);
        oldSkin.SetActive(false);
    }
    public void EquipSword()
    {
        sword.SetActive(true);
        axe.SetActive(false);
    }
    public void EquipPouch()
    {
        pouch.SetActive(true);
    }
    public void CleanObjectsEquipped()
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
