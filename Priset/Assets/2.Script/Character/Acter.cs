﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sang;

public class Acter : MonoBehaviour
{
    protected SphereCollider RangeArea;       //인식
    protected BattleCharacter haveCharacter;
    protected Animator ActerAni;
    protected NavMeshAgent navMesh;
    protected Transform ActorTransform;
    protected voiddelgate AniFuction;     //애니 저장
    protected Transform navMeshObject;
    protected Transform FirePos;  
    protected Acter Target;               //공격 대상
    protected bool attackEnable;
    protected bool NoDamageTime=false;         //무적 시간

    protected SphereCollider HitArea;       //인식
    protected Vector3 warLeftDirect = new Vector3(-1, 1, 1);

    protected List<skillParticle> haveSkillParicle;

    protected void init()
    {
        haveSkillParicle = new List<skillParticle>();
        ActerAni = this.GetComponent<Animator>();
        ActorTransform = this.GetComponent<Transform>();
        navMesh = this.transform.parent.GetComponent<NavMeshAgent>();
        HitArea = this.GetComponent<SphereCollider>();
        RangeArea = transform.GetChild(0).GetComponent<SphereCollider>();
        navMeshObject = this.transform.parent;
        if (navMeshObject.childCount>1)
            FirePos = navMeshObject.GetChild(1);

        attackEnable = true;
        OnNavmesh();

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
    protected void FireAni()
    {
        AniFuction = null;
        ActerAni.SetTrigger("fire");
    }
    protected void HitAni()
    {
        AniFuction = null;
        ActerAni.SetTrigger("hit");

        if (haveCharacter.Life == DeadorLive.DEAD)
        {
            Dead();
            if(this.GetType()==typeof(MonsterActor))
            {
                PlayerManager.instance.HuntCountUp();
                UIWarManager.instance.SetScore(PlayerManager.instance.SCORE);
            }
        }
    }

    void Dead()
    {
        DieAni();
        RangeArea.enabled = false;
        HitArea.enabled = false;
        OffNavmesh();
    }

    protected void NavMove(Vector3 TargetPos)     //대상으로 이동
    {

        if (HChacter.Life == DeadorLive.LIVE)
        {
            if (!navMesh.enabled)
                navMesh.enabled = true;

            navMesh.SetDestination(TargetPos);
        }
        //if (Target != null)
        //    TargetView();
    }
   public virtual void ProjectileOwnerFind(Vector3 TargetPos)
    {
        NavMove(TargetPos);
    }

    protected virtual void TargetSet(Acter _target)
    {
        if (_target == Target)
            return;

        if (_target.HChacter.Life == DeadorLive.LIVE)
        {
            Target = _target;
            TargetView();
        }
    }
    protected void Attackwork()
    {
        MoveToAttack();
        if (Target != null)
            TargetView();
    }

    void MoveToAttack()
    {
        if (attackEnable == true)
        {
            NavMove(Target.ActorTransform.position);
            if (navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                if (Target.HChacter.Life == DeadorLive.LIVE)
                    Attack();
                else
                    Target = null;
            }
        }
        else if (attackEnable == false)
            AttackEnd();
    }

    protected void Attack()
    {
        if (!ActerAni.GetCurrentAnimatorStateInfo(0).IsName("Humanoid_Strike"))
        {
            if (haveCharacter.Attacktype == CharacterAttackType.SHORT)
            {
                AttackAni();
            }
            else
            {
                AttackAni();
            }

            attackEnable = false;
        }
    }

    protected virtual void AttackEnd()
    {
        if(ActerAni.GetCurrentAnimatorStateInfo(0).IsName("Humanoid_Strike") &&
        ActerAni.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.65f)
        {
            attackEnable = true;

            if (haveCharacter.Attacktype == CharacterAttackType.SHORT)
            { 
                if (navMesh.remainingDistance <= navMesh.stoppingDistance)
                {
                    Hit(Target);
                }
            }
            else
            {
                haveCharacter.Bullet.CreateClone(FirePos.position, haveCharacter.Attack, 3f, Target.NObject.position, Target.tag);
            }
        }
    }

    public void Hit(int Damage)                         //자신이 맞을때
    {
        HChacter.HeathDamage(haveCharacter.Attack);
        HitAni();
    }
    public virtual void Hit(Acter Target)                         //남을 때릴때
    {
        Target.HChacter.HeathDamage(haveCharacter.Attack);
        UIWarManager.SetAmountChange(Target.HChacter);
        Target.HitAni();
    }
    public void StartHitEffect(Vector3 AttackPos)
    {
        if(NoDamageTime ==false)
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

    public Transform NObject
    {
        get { return navMeshObject; }
    }

    protected void RangeRefresh()
    {
        RangeArea.enabled = false;
        RangeArea.enabled = true;
    }


    void TargetView()
    {
        if (navMeshObject.position.x < Target.navMeshObject.position.x)
            right();
        if (navMeshObject.position.x > Target.navMeshObject.position.x)
            Left();
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

    protected void OffNavmesh()
    {
        navMesh.enabled = false;
    }
    protected void OnNavmesh()
    {
        navMesh.enabled = true;
    }
    public skillParticle GethaveSkillParicle(int index)
    {
        return haveSkillParicle[index];
    }

    public void haveSkillParicleClear()
    {
        haveSkillParicle = null;
    }
    public virtual void SkillParticleSet(skillParticle value) { }
    public virtual void haveParticlePlay(int skillindex) { }
}
