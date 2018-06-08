using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sang;

public class Acter : MonoBehaviour {

    protected Character haveCharacter;
    protected Animator ActerAni;
    protected NavMeshAgent navMesh;
    protected Transform ActorTransform;
    protected voiddelgate AniFuction;     //애니 저장

    protected void init()
    {
        ActerAni = this.GetComponent<Animator>();
        ActorTransform = this.GetComponent<Transform>();
    }

    virtual protected void Start()
    {
        Debug.Log("actor");
    }

    protected void Awake()
    {
        init();
    }

    protected void AniWork()      //애니 관리
    {
        if (AniFuction != null)
        {
            AniFuction();
        }
    }

    protected void IdleAni()
    {
        AniFuction = null;
        ActerAni.SetBool("idle", true);
        ActerAni.SetBool("walk", false);
        AniFuction = IdleAni;
    }

    protected void MoveAni()
    {
        AniFuction = null;
        ActerAni.SetBool("walk", true);
        ActerAni.SetBool("idle", false);
        AniFuction = MoveAni;
    }

    protected void AttackAni()
    {
        AniFuction = null;
        ActerAni.SetTrigger("attack");
    }


}
