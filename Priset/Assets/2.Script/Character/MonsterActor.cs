using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sang;


public class MonsterActor : Acter
{
    public int MonsterIndex;


    float EnermyFollowSpeed = 6f;
    float EnermyStopDistance = 1f;
    float ReseauchSpeed = 1f;
    float ReseauchStopDistance = 1f;
    float LongDistance;
    bool isHpBarExist;
    Vector3 StartPos;

    bool ReseauchEnd=true;

    public MonsterParty partyCommander = null;

    public MonsterParty GetPartyCommader
    {
        get { return partyCommander; }
    }
    public MonsterParty SetPartyCommader
    {
        set { partyCommander = value; }
    }
    public bool GetHpBarExist
    {
        get { return isHpBarExist; }
    }
    public bool SetHpBarExist
    {
        set { isHpBarExist = value; }
    }

    new void Awake()
    {
        //isHpBarExist = false;
        base.Awake();
        LongDistance = RangeArea.radius;
    }
    public void SetStartPos(Vector3 value)
    {
        StartPos = value;
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

        if(Target==null)
        { 
            RangeRefresh();
            EnermyResearch();
        }
        else if (Target != null)
        {
            Attackact();
        }
    }

    void EnermyResearch()          //적군 찾는 행위
    {
        if (ReseauchEnd == true)
        {
            float range = 3f;
            Vector3 FindPos;

            float XRanagevalue = Random.Range(-range, range);
            float ZRanagevalue = Random.Range(-range, range);


            FindPos = new Vector3(XRanagevalue, 0, ZRanagevalue);
            FindPos += StartPos;


            navMesh.speed = ReseauchSpeed;
            navMesh.stoppingDistance = ReseauchStopDistance;
            NavMove(FindPos);
            ReseauchEnd = false;
        }
        else if (ReseauchEnd == false)
        {
            if (navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                ReseauchEnd = true;
            }
        }
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
        navMesh.speed = EnermyFollowSpeed;

        if (haveCharacter.Attacktype == CharacterAttackType.SHORT)
            navMesh.stoppingDistance = EnermyStopDistance;
        else
            navMesh.stoppingDistance = LongDistance;
        Attackwork();
    }

    protected override void TargetSet(Acter _target)
    {
        if (_target == Target)
            return;

        //플레이어가 나(몬스터)를 인식했으면 HPBar On
        if (haveCharacter.Life == Sang.DeadorLive.LIVE)
        {
            if(isHpBarExist == false)
            {
                UIWarManager.instance.HpBarReceiver(this);
                isHpBarExist = true;
            }
        }
        Target = _target;
        //Attackwork();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            partyCommander.PartyTargetSet(other.GetComponent<Acter>());
            //TargetSet(other.GetComponent<Acter>());
        }
    }

    public override void ProjectileOwnerFind(Vector3 TargetPos)
    {
        navMesh.speed = EnermyFollowSpeed;
        NavMove(TargetPos);
    }
}
