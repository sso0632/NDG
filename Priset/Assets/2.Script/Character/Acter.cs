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
    protected bool attackEnable;
    protected bool NoDamageTime=false;         //무적 시간

    protected void init()
    {
        ActerAni = this.GetComponent<Animator>();
        ActorTransform = this.GetComponent<Transform>();
        navMesh = this.transform.parent.GetComponent<NavMeshAgent>();
        navMeshObject = this.transform.parent;
        attackEnable = true;

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

    public BattleCharacter HChacter
    {
        get { return haveCharacter; }
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

    protected void DieAni()
    {
        ActerAni.SetBool("walk", false);
        ActerAni.SetBool("idle", false);
        ActerAni.SetBool("die", true);
    }
    protected void HitAni()
    {
        AniFuction = null;
        ActerAni.SetTrigger("hit");

        if (haveCharacter.Life == DeadorLive.DEAD)
        {
            DieAni();
        }
    }

    protected void NavMove(Vector3 TargetPos)     //대상으로 이동
    {
        if (!navMesh.enabled)
            navMesh.enabled = true;

        navMesh.SetDestination(TargetPos);
    }

    protected virtual void TargetSet(Acter _target)
    {
        if (_target == Target)
            return;

        if(_target.HChacter.Life==DeadorLive.LIVE)
            Target = _target;
    }
    protected void Attackwork()
    {
        NavMove(Target.ActorTransform.position);
        if (attackEnable == true)
        {
            if(navMesh.remainingDistance <= navMesh.stoppingDistance) 
            {
                if (Target.HChacter.Life == DeadorLive.LIVE)
                    Attack();
                else
                    Target = null;
            }
        }
        else if(attackEnable == false)
            AttackEnd();
    }

    protected void Attack()
    {
        if (!ActerAni.GetCurrentAnimatorStateInfo(0).IsName("Humanoid_Strike"))
        {
            AttackAni();
            attackEnable = false;
        }
    }

    protected virtual void AttackEnd()
    {
        if(ActerAni.GetCurrentAnimatorStateInfo(0).IsName("Humanoid_Strike") &&
        ActerAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.65f)
        {
            attackEnable = true;
            if (navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                Target.HChacter.HeathDamage(haveCharacter.Attack);
                Target.HitAni();
            }
        }
    }
    public void StartHitEffect(Vector3 AttackPos)
    {
        if(NoDamageTime==false)
        {
            StartCoroutine("HitEffect", AttackPos);
        }

    }
    IEnumerator HitEffect(Vector3 AttackPos)
    {
        if(Target!=null)
        {
            HitAni();
            NoDamageTime = true;

            Vector3 Distance = (navMeshObject.position - AttackPos).normalized;

            float value=0.1f;

            for(int i=0; i<10;++i)
            {
                navMeshObject.Translate(value * Distance);
                yield return new WaitForEndOfFrame();
            }
            NoDamageTime = false;

        }
    }
}
