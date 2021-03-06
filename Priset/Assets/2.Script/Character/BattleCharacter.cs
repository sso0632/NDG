﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class BattleCharacter : Character {

    protected float HomeMoveSpeed;        //집 캐릭터 이동 속도
    protected float WarMoveSpeed;        //전쟁 캐릭터 이동 속도
    protected float AttackSpeed;          //공격 

    protected int AttackPoint;        //공격력
    protected int DefPoint;           //방어력 

    protected int MaxHeath;           //최대 체력
    protected int Heath;              //체력

    protected CharacterAttackType attacktype;   //공격 유형 
    protected DeadorLive life;        //죽음 여부
    protected Projectiles haveBullet;   //가지고 있는 총알

    protected int NeedGold;

    public BattleCharacter()         //배틀 캐릭터 생성
    {

    }
    
    public BattleCharacter(int _index)         //배틀 캐릭터 생성
    {
        index = _index;

    }
    protected virtual void indexValueSet()
    {

    }

    public CharacterAttackType Attacktype
    {
        set
        {
            attacktype = value;
            SetProjecttile();
        }
        get { return attacktype; }
    }
    public float HMSpeed
    {
        set { HomeMoveSpeed = value; }
        get { return HomeMoveSpeed; }
    }
    public float WMSpeed
    {
        set { WarMoveSpeed = value; }
        get { return WarMoveSpeed; }
    }
    public int MHeath
    {
        set { MaxHeath = value; }
        get { return MaxHeath; }
    }
    public int Attack
    {
        set { AttackPoint = value; }
        get { return AttackPoint; }
    }
    public float ASpeed
    {
        set { AttackSpeed = value; }
        get { return AttackSpeed; }
    }
    public int Defence
    {
        set { DefPoint = value; }
        get { return DefPoint; }
    }

    public int HP
    {
        set { Heath = value; }
        get { return Heath; }
    }

    public int NeedMoney
    {
        get { return NeedGold; }
    }

    public Projectiles Bullet
    {
        get { return haveBullet; }
    }

    public DeadorLive Life
    {
        get { return life; }
    }

    protected void HeathFull()      //체력을 최대로 채워주는 함수
    {
        Heath = MaxHeath;
    }

    public void HeathDamage(int Damage)      //데미지 입는 함수
    {
        Heath -= Damage;

        if(Heath<=0)
        {
            Die();
        }
    }

    protected void Die()
    {
        life = DeadorLive.DEAD;
    }

    protected void Live()
    {
        life = DeadorLive.LIVE;
    }
    protected void Resurrection()           //부활
    {
        Live();
        HeathFull();
    }

    void SetProjecttile()
    {
        switch(attacktype)
        {
            case CharacterAttackType.ARROW:
                haveBullet =Resources.Load<GameObject>("PrePab/Projectile/Arrow").GetComponent<Projectiles>();
                break;
            case CharacterAttackType.FIREBULL:
                haveBullet = Resources.Load<GameObject>("PrePab/Projectile/Fireball").GetComponent<Projectiles>();
                break;
            case CharacterAttackType.BOLT:
                haveBullet = Resources.Load<GameObject>("PrePab/Projectile/CrossbowBolt").GetComponent<Projectiles>();
                break;
            case CharacterAttackType.MANABALL:
                haveBullet = Resources.Load<GameObject>("PrePab/Projectile/Manaball").GetComponent<Projectiles>();
                break;
            case CharacterAttackType.SKULL:
                haveBullet = Resources.Load<GameObject>("PrePab/Projectile/Skull").GetComponent<Projectiles>();
                break;
            case CharacterAttackType.SLIMEBALL:
                haveBullet = Resources.Load<GameObject>("PrePab/Projectile/Slimeball").GetComponent<Projectiles>();
                break;
        }
    }

    protected void GoldSet()
    {
        switch (attacktype)
        {
            case CharacterAttackType.SHORT:
                NeedGold = (int)(AttackPoint * AttackSpeed) + (Heath);
                break;
            case CharacterAttackType.ARROW:
                NeedGold = (int)(AttackPoint * AttackSpeed) + (Heath * 2);
                break;
            case CharacterAttackType.BOLT:
                NeedGold = (int)(AttackPoint * AttackSpeed) + (Heath * 2);
                break;
            case CharacterAttackType.FIREBULL:
                NeedGold = (int)(AttackPoint * AttackSpeed) + (Heath * 2);
                break;
            case CharacterAttackType.MANABALL:
                NeedGold = (int)(AttackPoint * AttackSpeed) + (Heath * 2);
                break;
            case CharacterAttackType.SKULL:
                NeedGold = (int)(AttackPoint * AttackSpeed) + (Heath * 2);
                break;
        }
    }
}