using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class Priest : MonoBehaviour
{
    int index;              //사제 번호
    int HeathMax;          //체력 게임의 최대 지속 시간
    int PriestPowerMax;    //최대 신성력==엠피

    int Heath;          //현재 게임의 지속 시간
    int PriestPower;    //현재 신성력==엠피
    public int MoveSpeed;      //프리스트 이동 속도


    tdelgate<BattleCharacter> SkillSlot;


    public void ResistSkill(tdelgate<BattleCharacter> skill)
    {
        SkillSlot = skill;
    }

    public void SkillActive(BattleCharacter target)
    {
        SkillSlot(target);
    }
}
