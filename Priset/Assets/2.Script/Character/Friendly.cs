using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class Friendly : BattleCharacter
{
    public Friendly(int _index) : base(_index) { indexValueSet(); }

    protected override void indexValueSet()
    {
        GameManager.instance.Data.CharacterStatSet(this);
        Resurrection();
        GoldSet();
    }   
}

