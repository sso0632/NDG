using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character {
    //모든 캐릭터들이 가지고 있어야하는 것
    protected int index;              //캐릭터의 고유 번호  1~18 친구 18~ 30 몬스터 100~ 사제

    public int Index
    {
        get{ return index;}
    }
}
