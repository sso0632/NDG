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
        //DefUp = new Skill(1, 10f);
        //AttUp = new Skill(1, 10f);
        //Healing = new Skill(1, 0f);
    }
}

class Skill
{
    float SkilActiveTime;         //스킬 지속 시간
    float Skillvalue;                 //스킬 량
    int SkillIndex;                     //스킬 인덱스 번호

    public float VALUE
    {
        set { Skillvalue = value; }
        get { return Skillvalue; }
    }
    public float TIME
    {
        set { SkilActiveTime = value; }
        get { return SkilActiveTime; }
    }
    public int SKILLINDEX
    {
        set { SkillIndex = value; }
        get { return SkillIndex; }
    }

    public Skill (int index, float value, float Time)
    {
        SkillIndex = index;
        Skillvalue = value;
        SkilActiveTime = Time;
    }

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

    public void Heailng(BattleCharacter target)
    {
        target.HP += (int)Skillvalue;
    }

    public IEnumerator PriestSpeedUpTimer(Priest self)
    {
        self.MoveSpeed += (int)Skillvalue;
        yield return new WaitForSeconds(SkilActiveTime);
        self.MoveSpeed -= (int)Skillvalue;
    }

}