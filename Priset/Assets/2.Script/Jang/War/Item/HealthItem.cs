using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CHealthItem : CItem
{
    int healAmount;

    public int HealAmount
    {
        get { return healAmount; }
        set { healAmount = value; }
    }

}
public class HealthItem : Item
{
    CHealthItem healItem;

    public override void EatItem()
    {
        PriestActor tempActor = GameManager.instance.PM.GetNowPriest();
        tempActor.havePriest.HealthChange(healItem.HealAmount);
    }

}
