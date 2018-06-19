using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class Monster : BattleCharacter
{
    public Monster(int _index) : base(_index) { indexValueSet(); }

    protected override void indexValueSet()
    {
        GameManager.instance.Data.MonsterStatSet(this);
        Resurrection();
    }
}
