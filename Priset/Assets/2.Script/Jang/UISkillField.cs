using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillField : MonoBehaviour {
    UISkillIcon haveIcon;
    Text SkillContent;
    Skill haveSkill;
        
    private void Awake()
    {
        haveIcon = this.transform.GetChild(0).GetComponent<UISkillIcon>();
        haveIcon.Init();
        SkillContent = this.transform.GetChild(1).GetComponent<Text>();
    }

    public void SetSkill(Skill targetSkill)
    {
        haveSkill = targetSkill;
        SkillFieldSet();
    }

    void SkillFieldSet()
    {
        haveIcon.SkillSet(haveSkill.SKILLINDEX);
        SkillContent.text = haveSkill.CONTENT;
    }
}
