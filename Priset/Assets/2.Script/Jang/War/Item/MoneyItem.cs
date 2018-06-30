using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CMoney : CItem
{
    int moneyAmount;
   
    public int MoneyAmount
    {
        get { return moneyAmount; }
        set { moneyAmount = value; }
    }
}


public class MoneyItem : Item
{
    CMoney moneyData;

    private void Awake()
    {
        moneyData = new CMoney();
    }
    public override void EatItem()
    {
        PlayerManager.instance.AddMoney(moneyData.MoneyAmount);
    }
}
