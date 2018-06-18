using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class FriendActor : Acter {

    protected bool CheckLeftAndRigth;     //왼쪽 오른쪽 체크 
    protected voiddelgate HomeMoveFuction; //집에서 이동
    protected HomeActNum homeactkind;     //집에서 행동 
    

    Priest Leader;                      //사제 
    Quaternion LeftDirect = new Quaternion(0, 180, 0, 0);
    Vector3 warLeftDirect = new Vector3(-1, 1, 1);

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
            WarAct();
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
        if (Leader != null)
        {
            if (JoyStick.MoveDir.x < 0)
                Left();
            else if (JoyStick.MoveDir.x > 0)
                right();
            if (JoyStick.MoveDir!=Vector3.zero)
                MoveAni();
            else
                IdleAni();
            navMeshObject.position += (JoyStick.MoveDir * Leader.MoveSpeed) * Time.deltaTime;
        }
    }
    void HomeAct()
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
    void HomeMoveFuctionWork()      //집에서 이동 작동
    {
        if (HomeMoveFuction != null)
            HomeMoveFuction();
    }

    public void SetLeader(Priest _leader)
    {
        Leader = _leader;
        navMesh.enabled = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            TargetSet(other.GetComponent<Acter>());
        }
    }
}
