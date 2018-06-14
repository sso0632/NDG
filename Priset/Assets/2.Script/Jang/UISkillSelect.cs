using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISkillSelect : MonoBehaviour {

    public Transform SkillFieldParent;
    GameObject SkillField;
    UISkillField SkillFieldData;

    private void Awake()
    {
        Init();
    }
    void Init()
    {
        SkillField = (GameObject)Resources.Load("PrePab/UIObjectPrepab/Skillbar");
        SkillSelectSet();
    }

	void SkillSelectSet()
    {
        for (int i = 0; i < GameManager.instance.PM.SkillSpace.SkillCount(); ++i)
        {
            SkillFieldData=Instantiate(SkillField, SkillFieldParent).GetComponent<UISkillField>();
            SkillFieldData.SetSkill(GameManager.instance.PM.SkillSpace.SkillGet(i));
        }
    }
}
