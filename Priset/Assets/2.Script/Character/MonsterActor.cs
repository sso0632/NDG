using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterActor : Acter
{
    public delegate MonsterActor InDistanceCheck();
    public static event InDistanceCheck InDistacneEvent;

    public int MonsterIndex;
    Monster monsterData;
    
    private MonsterParty partyCommander = null;

    public MonsterParty GetPartyCommader
    {
        get { return partyCommander; }
    }
    public MonsterParty SetPartyCommader
    {
        set { partyCommander = value; }
    }

    new void Awake()
    {
        base.Awake();
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //TargetSet(other.GetComponent<Acter>());
        }
    }
}
