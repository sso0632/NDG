using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class FriendActor : Acter {

    protected bool CheckLeftAndRigth;     //왼쪽 오른쪽 체크 
    protected voiddelgate HomeMoveFuction; //집에서 이동
    protected HomeActNum homeactkind;     //집에서 행동 

    Quaternion LeftDirect = new Quaternion(0, 180, 0, 0);

   
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
        Debug.Log("!!");
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
    void WarAct()
    {
        transform.position += JoyStick.MoveDir * Time.deltaTime;
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
    void Left()
    {
       ActorTransform.rotation = LeftDirect;
    }
    void right()
    {
        ActorTransform.rotation = Quaternion.identity;
    }
    void HomeMoveFuctionWork()      //집에서 이동 작동
    {
        if (HomeMoveFuction != null)
            HomeMoveFuction();
    }
}
