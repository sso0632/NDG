using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class MonsterActor : Acter
{
    public int MonsterIndex;
    
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
    private void OnEnable()
    {
        MonsterParty.PurposeEvent += TargetSet;
    }
    private void OnDisable()
    {
        MonsterParty.PurposeEvent -= TargetSet;
    }

    protected override void TargetSet(Acter _target)
    {
        if (_target == Target)
            return;

        Target = _target;
        Attackwork();
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            MonsterParty.PartyTargetSet(other.GetComponent<Acter>());
            //TargetSet(other.GetComponent<Acter>());
        }

    }
}
