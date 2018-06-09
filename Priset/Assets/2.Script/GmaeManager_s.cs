using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmaeManager_s : MonoBehaviour {

    public static GmaeManager_s Current;
    public DataSet Data;
    
    void Awake()
    {
        Current = this;
        Data = this.GetComponent<DataSet>();
    }
}
