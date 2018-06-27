using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;
public class SkillManager : MonoBehaviour
{ 
    List<Skill> SkillBox;
    
    public void Init()
    {
        SkillBox = GameManager.instance.Data.SkillSet();
        SkillFuctionSet();
    }

    public int SkillCount()
    {
        return SkillBox.Count;
    }
    public Skill SkillGet(int index)
    {
        return SkillBox[index];
    }

    void SkillFuctionSet()
    {
        for(int i=0; i< SkillBox.Count; ++i)
        {
            switch (SkillBox[i].SkillIndex)
            {
                case 0:
                    SkillBox[i].SKillSet();
                    break;
                case 1:
                    SkillBox[i].SKillSet(Attup);
                    break;
            }
        }
    }


    void Attup(Skill self, BattleCharacter target)
    {
        StartCoroutine(self.AttUpBuffTimer(target));
    }
    void Defup(Skill self, BattleCharacter target)
    {
        StartCoroutine(self.AttUpBuffTimer(target));
    }
}

public class Skill
{
    string name;                      //스킬 이름
    float SkilActiveTime;             //스킬 지속 시간
    float Skillvalue;                 //스킬 량
    int Index;                   //스킬 인덱스 번호
    int Needvalue;                  //스킬 필요한 량
    string Content;                   //스킬 설정
    bool SelfSkillCheck;                   //프리스트 대상

    SkillDelgate<BattleCharacter> TimerActive=null;
    tdelgate<BattleCharacter> SkillActive = null;
    tdelgate<Priest> SkillPriestActive = null;

    GameObject skillParticle;

    public int SkillNeedValue
    {
        get { return Needvalue; }
        set { Needvalue = value; }
    }
    public float SkillValue
    {
        set { Skillvalue = value; }
        get { return Skillvalue; }
    }
    public float SkillTime
    {
        set { SkilActiveTime = value; }
        get { return SkilActiveTime; }
    }
    public int SkillIndex
    {
        set { Index = value; }
        get { return Index; }
    }
    public string SkillContent
    {
        set { Content = value; }
        get { return Content; }
    }
    public string SkillName
    {
        set { name = value; }
        get { return name; }
    }
    public bool SelfSkill
    {
        set { SelfSkillCheck = value; }
        get { return SelfSkillCheck; }
    }
    public void SetParticle(GameObject obj)
    {
        skillParticle = obj;
    }
    public Skill(int index, string _name, string _content, float value, int Nvalue, float Time, bool _check)
    {
        name = _name;
        Content = _content;
        SkillIndex = index;
        Skillvalue = value;
        SkilActiveTime = Time;
        SelfSkillCheck = _check;
        Needvalue = Nvalue;
    }

    public void SKillSet()
    {
        if(Index==0)
            SkillActive = Heailng;
    }
    public void SKillSet(SkillDelgate<BattleCharacter> skillFuction)
    {
        TimerActive = skillFuction;
    }
    public void SKillSet(tdelgate<BattleCharacter> skillFuction)
    {
        SkillActive = skillFuction;
    }
    public void SKillSet(tdelgate<Priest> skillFuction)
    {
        SkillPriestActive = skillFuction;
    }

    public void SetActive(BattleCharacter target)
    {
        if(SkillActive!=null)
            SkillActive(target);
        if(TimerActive!=null)
            TimerActive(this, target);
    }
    public void SetActive(Priest target)
    {
        if(SkillPriestActive!=null)
            SkillPriestActive(target);
    }

    void Heailng(BattleCharacter target)
    {
        target.HP += (int)SkillValue;
    }

    public IEnumerator AttUpBuffTimer(BattleCharacter target)
    {
        target.Attack += (int)Skillvalue;
        yield return new WaitForSeconds(SkilActiveTime);
        target.Attack -= (int)Skillvalue;
    }
    public IEnumerator DefUpBuff(BattleCharacter target)
    {
        target.Defence += (int)Skillvalue;
        yield return new WaitForSeconds(SkilActiveTime);
        target.Defence -= (int)Skillvalue;
    }
    public IEnumerator PriestSpeedUpTimer(Priest self)
    {
        self.MoveSpeed += (int)Skillvalue;
        yield return new WaitForSeconds(SkilActiveTime);
        self.MoveSpeed -= (int)Skillvalue;
    }
}