using System.Collections;
using System.Collections.Generic;
using Datsumo.Shops;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] Transform listRoot;
    [SerializeField] RowUI rowPrefab;
    Shop currenShop = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RefreshUI()
    {
        foreach(Transform child in listRoot)
        {
            Destroy(child.gameObject);
        }
        foreach(ShopItem in curr)
    }
}
