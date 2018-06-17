using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sang;

public class Acter : MonoBehaviour {

    protected BattleCharacter haveCharacter;
    protected Animator ActerAni;
    protected NavMeshAgent navMesh;
    protected Transform ActorTransform;
    protected voiddelgate AniFuction;     //애니 저장
    protected Transform navMeshObject;

    protected Acter Target;               //공격 대상

    protected void init()
    {
        ActerAni = this.GetComponent<Animator>();
        ActorTransform = this.GetComponent<Transform>();
        navMesh = this.transform.parent.GetComponent<NavMeshAgent>();
        navMeshObject = this.transform.parent;

        //if (GameManager.instance.NowScene != SceneNum.War)
        //{
        //    navMesh.enabled = false;
        //}
    }
    protected void Awake()
    {
        init();
    }

    virtual protected void Start()
    {
       
    }

    public void RegistCharacter(BattleCharacter _Character)
    {
        haveCharacter = _Character;
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

    void NavMove(Vector3 TargetPos)     //대상으로 이동
    {
        navMesh.SetDestination(TargetPos);
    }

    protected void TargetSet(Acter _target)
    {
        Target = _target;
        Attackwork();
    }
     void Attackwork()
    {
        NavMove(Target.ActorTransform.position);

        if (navMesh.stoppingDistance >= Vector3.Distance(ActorTransform.position, Target.ActorTransform.position))
        {
            Attack();
        }
    }

    void Attack()
    {
        AttackAni();
        //Target.haveCharacter.HeathDamage(haveCharacter.Attack);
    }
}
