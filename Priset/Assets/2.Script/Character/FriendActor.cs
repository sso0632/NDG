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
    Vector3 warLeftDirect = new Vector3(-1, 1, 1);
    PartyPos formationNum;

    float MonsterFollowSpeed=6f;
    float MonsterStopDistance=1f;

    int AttackCount=0;                    //공격한 횟수 
    bool AttackendBack=false;                   //공격 완료 돌아가기

    private void Awake() 
    {
        base.Awake();
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
    IEnumerator decisionHomeAct()
    {
        homeactkind = (HomeActNum)Random.Range(0, 3);

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
            navMesh.stoppingDistance = MonsterStopDistance;
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
        ActorTransform.Translate(Vector3.right * Time.deltaTime);
    }
    protected void Left()   
    {
        if (GameManager.instance.NowScene != SceneNum.War)
            ActorTransform.rotation = LeftDirect;
        else if (GameManager.instance.NowScene != SceneNum.Home)
        {
            warLeftDirect.x = -1;
            ActorTransform.localScale = warLeftDirect;
        }
    }
    protected void right()
    {
        if (GameManager.instance.NowScene != SceneNum.War)
            ActorTransform.rotation = Quaternion.identity;

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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            if(Target==null)
            {
                TargetSet(other.GetComponent<Acter>());
            }
        }
    }

    protected override void AttackEnd()
    {
        if (ActerAni.GetCurrentAnimatorStateInfo(0).IsName("Humanoid_Strike") &&
        ActerAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            attackEnable = true;

            //Debug.Log(haveCharacter.ASpeed + " " + AttackCount);
            if (navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                AttackCount++;
                Target.HChacter.HeathDamage(haveCharacter.Attack);
                Target.StartHitEffect(navMeshObject.position);

                if (haveCharacter.ASpeed <= AttackCount)
                {
                    AttackCount = 0;
                    AttackendBack = true;
                }
            }
        }
    }

    bool checkBack()
    {
        if ((int)Vector3.Distance(Party.GetPos((int)formationNum), ActorTransform.position) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        
}
