using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class BattleCharacter : Character {

    protected float HomeMoveSpeed;        //집 캐릭터 이동 속도
    protected float WarMoveSpeed;        //전쟁 캐릭터 이동 속도
    protected float AttackSpeed;      //공격 속도
    protected int AttackPoint;        //공격력
    protected int DefPoint;           //방어력 
    protected int MaxHeath;           //최대 체력
    protected int Heath;              //체력
    protected CharacterAttackType attacktype;   //공격 유형 
    protected DeadorLive lift;        //죽음 여부

    public BattleCharacter()         //배틀 캐릭터 생성
    {

    }
    
    public BattleCharacter(int _index)         //배틀 캐릭터 생성
    {
        index = _index;
        indexValueSet();
    }

    void indexValueSet()
    {
        GameManager.instance.Data.CharacterStatSet(this);
    }

    public CharacterAttackType Attacktype
    {
        set { attacktype = value; }
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
    protected void HeathFull()      //체력을 최대로 채워주는 함수
    {
        Heath = MaxHeath;
    }

    protected void HeathDamage(int Damage)      //데미지 입는 함수
    {
        Heath -= Damage;
    }

    protected void Die()
    {
        lift = DeadorLive.DEAD;
    }

    protected void Live()
    {
        lift = DeadorLive.LIVE;
    }
    protected void Resurrection()           //부활
    {
        Live();
        HeathFull();
    }
}