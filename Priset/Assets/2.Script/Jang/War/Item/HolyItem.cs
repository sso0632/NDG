using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CHolyItem : CItem
{
    float holyAmount;

    public float HolyAmount
    {
        get { return holyAmount; }
        set { holyAmount = value; }
    }

}
public class HolyItem : Item
{
    public override void EatItem()
    {
         



    }

}

