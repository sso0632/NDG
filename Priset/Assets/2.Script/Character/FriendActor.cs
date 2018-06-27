using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class FriendActor : Acter {

    protected bool CheckLeftAndRigth;     //왼쪽 오른쪽 체크 
    protected voiddelgate HomeMoveFuction; //집에서 이동
    protected HomeActNum homeactkind;     //집에서 행동 

    PlayerParty Party;                  //속해있는 파티
    Quaternion LeftDirect = new Quaternion(0, 180, 0, 0);
    PartyPos formationNum;

    float MonsterFollowSpeed=6f;
    float MonsterStopDistance=1f;
    float LongDistance;
    float HomeMoveLimite=4.5f;

    int AttackCount=0;                    //공격한 횟수 
    bool AttackendBack=false;                   //공격 완료 돌아가기

    private void Awake() 
    {
        base.Awake();
        LongDistance = RangeArea.radius;
    }
    override protected void Start()
    {
        if (GameManager.instance.NowScene != SceneNum.War)
        {
            StartCoroutine("decisionHomeAct");
        }
    }

    protected void Update()
    {
        if (GameManager.instance.NowScene == SceneNum.Home)
            HomeAct();
        else if (GameManager.instance.NowScene == SceneNum.War)
            if(haveCharacter!=null)
            { 
                if (haveCharacter.Life == DeadorLive.LIVE)
                    WarAct();
            }
    }

    public void StopDecision()
    {
        StopCoroutine("decisionHomeAct");
    }

    void decisionAct()
    {
        switch (homeactkind)
        {
            case HomeActNum.RightWalk:
                right();
                MoveAni();
                HomeMoveFuction = HomeMove;
                break;
            case HomeActNum.LeftWalk:
                Left();
                MoveAni();
                HomeMoveFuction = HomeMove;
                break;
            case HomeActNum.Idle:
                IdleAni();
                HomeMoveFuction = null;
                break;
        }
    }
    IEnumerator decisionHomeAct()
    {
        homeactkind = (HomeActNum)Random.Range(0, 3);
        decisionAct();
        yield return new WaitForSeconds(2f);
        if (GameManager.instance.NowScene != SceneNum.War)
        {
            StartCoroutine("decisionHomeAct");
        }
    }
    protected virtual void WarAct()
    {
        //공격 중이 아닐때 만
        if (Party != null)
        {
            if (ActorTransform.position.x < navMesh.destination.x)
                right();
            if (ActorTransform.position.x > navMesh.destination.x)
                Left();
            if (navMesh.remainingDistance > navMesh.stoppingDistance)
                MoveAni();
            else
                IdleAni();

            if (Target == null)
                FollowLeader();
            else if (Target != null)
                Attackact();
        }
    }

    void Attackact()
    {
        navMesh.speed = MonsterFollowSpeed;

        if(!AttackendBack)
        {
            if (haveCharacter.Attacktype == CharacterAttackType.SHORT)
                navMesh.stoppingDistance = MonsterStopDistance;
           else 
                navMesh.stoppingDistance = LongDistance;
            Attackwork();
        }
        else
        {
            NavMove(Party.GetPos((int)formationNum));
            navMesh.stoppingDistance = 0;
            if (checkBack())
            {
                AttackendBack = false;
                Target = null;
            }
        }
    }

    void FollowLeader()
    {
        navMesh.stoppingDistance = 0;
        navMesh.speed = Party.LeaderSpeed()+3;
        NavMove(Party.GetPos((int)formationNum));
        RangeRefresh();
    }

    void HomeMoveFuctionWork()      //집에서 이동 작동
    {
        if (HomeMoveFuction != null)
            HomeMoveFuction();
    }
    protected void HomeAct()
    {
        AniWork();
        HomeMoveFuctionWork();
    }
    void HomeMove()     //집에서 이동
    {
        if(HomeMoveLimite > 0)
        {
            if (ActorTransform.localPosition.x < HomeMoveLimite)
                ActorTransform.Translate(Vector3.right * Time.deltaTime);
            else
            {
                homeactkind = HomeActNum.LeftWalk;
                decisionAct();
            }
        }
        else if(HomeMoveLimite < 0)
        {
            if (ActorTransform.localPosition.x > HomeMoveLimite)
                ActorTransform.Translate(Vector3.right * Time.deltaTime);
            else
            {
                homeactkind = HomeActNum.RightWalk;
                decisionAct();
            }
        }
    }
    protected void Left()   
    {
        if (GameManager.instance.NowScene != SceneNum.War)
        {
            HomeMoveLimite = -4.5f;
            ActorTransform.rotation = LeftDirect;
        }
        else if (GameManager.instance.NowScene != SceneNum.Home)
        {
            warLeftDirect.x = -1;
            ActorTransform.localScale = warLeftDirect;
        }
    }
    protected void right()
    {
        if (GameManager.instance.NowScene != SceneNum.War)
        {
            HomeMoveLimite = 4.5f;
            ActorTransform.rotation = Quaternion.identity;
        }
        else if (GameManager.instance.NowScene != SceneNum.Home)
        {

            warLeftDirect.x = 1;
            ActorTransform.localScale = warLeftDirect;
        }
    }

    public void SetFormationPos(PartyPos _formationNum) //나의 포메이션 위치
    {
        formationNum = _formationNum;
    }
    public void SetParty(PlayerParty _Party)           //리더 설정
    {
        Party = _Party;
        navMesh.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            if (Target == null)
            {
                TargetSet(other.GetComponent<Acter>());
            }
        }
    }


    protected override void AttackEnd()
    {
        if (ActerAni.GetCurrentAnimatorStateInfo(0).IsName("Humanoid_Strike") &&
        ActerAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
        {
            attackEnable = true;

            if (haveCharacter.Attacktype == CharacterAttackType.SHORT)
            {
                if (navMesh.remainingDistance <= navMesh.stoppingDistance && Target.HChacter.Life == DeadorLive.LIVE)
                {
                    AttackCount++;
                    Target.HChacter.HeathDamage(haveCharacter.Attack);
                    UIWarManager.SetAmountChange(Target.HChacter);
                    UIWarManager.instance.ShowDamageText(Target.transform.position, haveCharacter.Attack);
                    Target.StartHitEffect(navMeshObject.position);
                }
            }
            else
            {
                AttackCount++;
                haveCharacter.Bullet.CreateClone(FirePos.position, haveCharacter.Attack, 3f, Target.NObject.position, Target.tag);
            }

            if (haveCharacter.ASpeed <= AttackCount)
            {
                AttackCount = 0;
                AttackendBack = true;
            }
        }
    }

    bool checkBack()
    {
        if ((int)Vector3.Distance(Party.GetPos((int)formationNum), ActorTransform.position) == 0)
            return true;
        else
            return false;
    }
        
}
