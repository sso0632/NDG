using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class FriendActor : Acter {

    bool CheckLeftAndRigth;     //왼쪽 오른쪽 체크 
    voiddelgate HomeMoveFuction; //집에서 이동
    HomeActNum homeactkind;     //집에서 행동 

    Quaternion LeftDirect = new Quaternion(0, 180, 0, 0);

   override protected void Start()
    {
        StartCoroutine("decisionHomeAct");
    }

    private void Update()
    {
        HomeAct();
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
        StartCoroutine("decisionHomeAct");
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
