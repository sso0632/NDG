using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CSpeedItem : CItem
{
    float speedAmount;

    public float SpeedAmount
    {
        get { return speedAmount; }
        set { speedAmount = value; }
    }
}

public class SpeedItem : Item
{
    public override void EatItem()
    {
                
    }
}
