using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class BattleCharacter : Character {

    protected float HomeMoveSpeed;        //집 캐릭터 이동 속도
    protected float WarMoveSpeed;        //전쟁 캐릭터 이동 속도
    protected float AttackSpeed;      //공격 속도
    protected int AttackPoint;        //공격력 
    protected int MaxHeath;           //최대 체력
    protected int Heath;              //체력
    protected CharacterAttackType attacktype;   //공격 유형 
    protected DeadorLive lift;        //죽음 여부

    protected float HMSpeed
    {
        set { HomeMoveSpeed = value; }
        get { return HomeMoveSpeed; }
    }
    protected float WMSpeed
    {
        set { WarMoveSpeed = value; }
        get { return WarMoveSpeed; }
    }
    protected float ASpeed
    {
        set { AttackSpeed = value; }
        get { return AttackSpeed; }
    }
    protected int MHeath
    {
        set { MaxHeath = value; }
        get { return MaxHeath; }
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
