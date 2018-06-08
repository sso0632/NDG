using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class Monster : BattleCharacter
{
    Monster(int _index, float _MoveSpeed, float _AttackSpeed, int _AttackPoint, int _MaxHeath, CharacterAttackType _attacktype)
    {
        index = _index;
        WarMoveSpeed = _MoveSpeed;
        AttackSpeed = _AttackSpeed;
        AttackPoint = _AttackPoint;
        MaxHeath = _MaxHeath;
        attacktype = _attacktype;
    }
}
