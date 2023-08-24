using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] private int moneyAmount;

    private void Update() 
    {
        UpdateMoney();
    }
    public void SubtractMoney(int moneyToSubtract)
    {
        if(moneyAmount <= 0){return;}

        moneyAmount = Mathf.Max(moneyAmount - moneyToSubtract, 0);
        UpdateMoney();
        Debug.Log(moneyToSubtract);
    }
    public void AddMoney(int moneyToAdd)
    {
        if(moneyAmount <= 0){return;}

        moneyAmount = Mathf.Max(moneyAmount + moneyToAdd, 0);
        UpdateMoney();
        Debug.Log(moneyToAdd);
    }
    private void UpdateMoney()
    {
        moneyTxt.text = moneyAmount.ToString();
    }
}
