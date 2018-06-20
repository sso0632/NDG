using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class MonsterActor : Acter
{
    public int MonsterIndex;

    float FollowSpeed = 6f;
    float StopDistance = 2f;
    Vector3 warLeftDirect = new Vector3(-1, 1, 1);

    public MonsterParty partyCommander = null;

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

    public void TargetEventAdd()
    {
        partyCommander.PurposeEvent += TargetSet;
    }
    public void TargetEventRemove()
    {
        partyCommander.PurposeEvent -= TargetSet;
    }
    protected void Update()
    {
        if (haveCharacter != null)
        {
            if (haveCharacter.Life == Sang.DeadorLive.LIVE)
            {
                WarAct();
            }
        }
    }
    protected virtual void WarAct()
    {
        if (ActorTransform.position.x < navMesh.destination.x)
            right();
        if (ActorTransform.position.x > navMesh.destination.x)
            Left();
        if (navMesh.remainingDistance > navMesh.stoppingDistance)
            MoveAni();
        else
            IdleAni();

        if (Target != null)
            Attackact();
    }
    protected void Left()
    {
        warLeftDirect.x = -1;
        ActorTransform.localScale = warLeftDirect;
    }
    protected void right()
    {
        warLeftDirect.x = 1;
        ActorTransform.localScale = warLeftDirect;
    }

    void Attackact()
    {
        navMesh.speed = FollowSpeed;
        navMesh.stoppingDistance = StopDistance;
        Attackwork();
    }

    protected override void TargetSet(Acter _target)
    {
        if (_target == Target)
            return;

        Target = _target;
        //Attackwork();
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            partyCommander.PartyTargetSet(other.GetComponent<Acter>());
            TargetSet(other.GetComponent<Acter>());
        }
    }
}
