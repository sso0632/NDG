using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sang;

public class UISkillField : MonoBehaviour {

    UISkillIcon haveIcon;
    Text SkillContent;
    Skill haveSkill;
    voiddelgate ButtonAcitve;

    private void Awake()
    {
        haveIcon = this.transform.GetChild(0).GetComponent<UISkillIcon>();
        SkillContent = this.transform.GetChild(1).GetComponent<Text>();
        haveIcon.Init();
    }

    public void SetSkill(Skill targetSkill)
    {
        haveSkill = targetSkill;
        SkillFieldSet();
    }
    public void SetButtonAcitve(voiddelgate fuction)
    {
        ButtonAcitve = fuction;
    }
    public void SetButton()     //스킬 셋팅 버튼 
    {
        GameManager.instance.PM.SkillSet(haveSkill);
        ButtonAcitve();
    }
    void SkillFieldSet()
    {
        haveIcon.SkillSet(haveSkill.SkillIndex);
        SkillContent.text = haveSkill.SkillContent;
    }
}
