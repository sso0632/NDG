using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;
public class SkillManager : MonoBehaviour
{
    Skill DefUp;
    Skill AttUp;
    Skill Healing;

    private void Awake()
    {
        DefUp = new Skill(1, 10f);
        AttUp = new Skill(1, 10f);
        Healing = new Skill(1, 0f);
    }
    public void DefUpBuff(BattleCharacter target)           //방어력 상승 스킬
    {
        StartCoroutine(DefUp.DefUpBuff(target));
    }
    public void AttUpBuff(BattleCharacter target)           //공격력 상승 스킬
    {
        StartCoroutine(AttUp.AttUpBuffTimer(target));
    }
    public void Heal(BattleCharacter target)                //체력 회복 스킬
    {
        Healing.Healing(target);
    }
}

class Skill
{
    public float SkilActiveTime;         //스킬 지속 시간
    public float Skillvalue;                 //스킬 량

    public Skill (float value, float Time)
    {

        Skillvalue = value;
        SkilActiveTime = Time;
    }

    //스킬의 기능
    public IEnumerator DefUpBuff(BattleCharacter target)        
    {
        target.Defence += (int)Skillvalue;
        yield return new WaitForSeconds(SkilActiveTime);
        target.Defence -= (int)Skillvalue;
    }
    public IEnumerator AttUpBuffTimer(BattleCharacter target)
    {
        target.Attack += (int)Skillvalue;
        yield return new WaitForSeconds(SkilActiveTime);
        target.Attack -= (int)Skillvalue;
    }
    public void Healing(BattleCharacter target)
    {
        target.HP += (int)Skillvalue;
    }
}