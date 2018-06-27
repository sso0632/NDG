using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISkillSelect : MonoBehaviour {

    public UISkillIcon[] SkillSlot;
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
        for (int i = 0; i < SkillSlot.Length; ++i)
            SkillSlot[i].Init();
    }

	void SkillSelectSet()
    {
        for (int i = 0; i < GameManager.instance.SkillSpace.SkillCount(); ++i)
        {
            SkillFieldData =Instantiate(SkillField, SkillFieldParent).GetComponent<UISkillField>();
            SkillFieldData.SetSkill(GameManager.instance.SkillSpace.SkillGet(i));
            SkillFieldData.SetButtonAcitve(SlotSet);
        }
    }

    void SlotSet()
    {
        Skill[] IndexSkill = GameManager.instance.PM.NowPriestSkillGet();

        for (int i = 0; i < SkillSlot.Length; ++i)
        {
            if (IndexSkill[i] != null)
            {
                SkillSlot[i].SkillSet(IndexSkill[i].SkillIndex);
            }
        }
    }
    
}
