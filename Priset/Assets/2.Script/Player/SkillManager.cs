using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;
public class SkillManager : MonoBehaviour
{
    List<Skill> SkillBox;


    private void Awake()
    {
        SkillBox = new List<Skill>();
        SkillAdd();
    }
    public int SkillCount()
    {
        return SkillBox.Count;
    }
    public Skill SkillGet(int index)
    {
        return SkillBox[index];
    }
    void SkillAdd()
    {
        //액셀로 만든 스킬을 리스트에 넣는다
        Skill skill1 = new Skill(0, 1, 0f);
        SkillBox.Add(skill1);
    }
}

public class Skill
{
    float SkilActiveTime;         //스킬 지속 시간
    float Skillvalue;                 //스킬 량
    int SkillIndex;                     //스킬 인덱스 번호
    string Content;                 //스킬 설정

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
    public string CONTENT
    {
        set { Content = value; }
        get { return Content; }
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