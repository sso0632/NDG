﻿using System.Collections;
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

    bool FirstSkillActive;  //스킬 처음사용
    private void Awake()
    {
        SlotCount = 2;
        PriestPower = 2;
        SkillSlot = new Skill[SlotCount];
        FirstSkillActive = false;
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
        { 
            if(CheckPower())
            {
                nowSkill.SetActive(GameManager.instance.PM.GetPlayerParty.GetPartyMember(targetnum));
                SkillParticleActive(GameManager.instance.PM.GetPlayerParty.GetPartyActor(targetnum));
            }
        }
        else
        {
            if (CheckPower())
            {
                nowSkill.SetActive(this);
                SkillParticleActive(GameManager.instance.PM.GetPlayerParty.GetPartyActor(targetnum));
            }
        }
    }


   public void NowSkillSet(int skillindex)
    {
        nowSkill = SkillSlot[skillindex];

        for (int i=0; i< 4; ++i)
        {
            if (GameManager.instance.PM.GetPlayerParty.GetPartyActor(i)!=null)
            {
                SkillParticleSet(GameManager.instance.PM.GetPlayerParty.GetPartyActor(i));
            }
        }
    }
    void PowerMinuce()
    {
        PriestPower -= nowSkill.SkillNeedValue;
    }

    bool CheckPower()
    {
        if (PriestPower >= nowSkill.SkillNeedValue)
        {
            PowerMinuce();
            return true;
        }
        else
            return true;
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

    void SkillParticleSet(Acter targetacter)
    {
        skillParticle temp = new skillParticle();
        temp.Particle = (GameObject)Instantiate(nowSkill.Particle, targetacter.transform);
        temp.Index = nowSkill.SkillIndex;

        targetacter.SkillParticleSet(temp);
    }
    void SkillParticleActive(Acter targetacter)
    {
        targetacter.haveParticlePlay(nowSkill.SkillIndex);
    }
}
