using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class Priest : MonoBehaviour
{
    int index;             //사제 번호
    int HeathMax;          //체력 게임의 최대 지속 시간
    int PriestPowerMax;    //최대 신성력 == 엠피
    int Heath;             //현재 게임의 지속 시간
    int PriestPower;       //현재 신성력 == 엠피
    int SlotCount;         //스킬 슬롯 갯수
    Skill[] SkillSlot;
    Skill nowSkill;        //현재 스킬
    public int MoveSpeed;  //프리스트 이동 속도

    PlayerManager pm;

    private void Awake()
    {
        SlotCount = 2;
        SkillSlot = new Skill[SlotCount];
    }

    public void SetSkill(Skill getSkill)
    {
        for(int i=0; i< SlotCount; ++i)
        {
            if(SkillSlot[i]==null)
            {
                SkillSlot[i] = getSkill;
                return;
            }
        }
    }
    public void SkillActive(int targetnum)
    {
        if (nowSkill.SelfSkill == false)
            nowSkill.SetActive(pm.GetPlayerParty.GetPartyMember(targetnum));
        else
            nowSkill.SetActive(this);
    }

    public Skill[] GetSkill()
    {
        return SkillSlot;
    }

    public void HeathFull()
    {
        Heath = HeathMax;
    }
    public void init()
    {
        HeathFull();
    }
}
