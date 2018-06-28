using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CHealthItem : CItem
{
    float healAmount;

    public float HealAmount
    {
        get { return healAmount; }
        set { healAmount = value; }
    }
}
public class HealthItem : Item
{
    public override void EatItem()
    {
        Debug.Log("체력 아이템");
    }

}
