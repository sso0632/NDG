﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItem
{
    int itemCode;

    public int ItemCode
    {
        get { return itemCode; }
        set { itemCode = value; }
    }
}

public class Item : MonoBehaviour
{
    public virtual void EatItem() { }

    private void OnTriggerEnter(Collider other)
    { 
       
                

    }
    
}


