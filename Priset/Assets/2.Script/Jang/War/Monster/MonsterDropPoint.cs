using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDropPoint : MonoBehaviour
{
    public MonsterParty currentLocateParty;
    bool isDropOn;

    private void Awake()
    {
        currentLocateParty = GetComponent<MonsterParty>();
        isDropOn = false;
    }
    public void Init()
    {
    }
    public bool GetDropExist
    {
        get { return isDropOn; }
    }
    
    public MonsterParty GetParty
    {
        get { return currentLocateParty; }
    }
    
    public void MonsterPartyMake()
    {
        if (isDropOn)
            return;

        isDropOn = true;
        currentLocateParty.MakeParty();
    }
    public void MonsterPartyDestory()
    {
        isDropOn = false;
    }



   

}
