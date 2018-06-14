using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHighPriestPanel : MonoBehaviour {

    public GameObject SkillSetObject;
    //public GameObject SkillUpObject;


    private void Awake()
    {
        SelectView();
    }

    public void SkillSetOpen()
    {
        SkillSetObject.SetActive(true);
        //SkillUpObject.SetActive(false);
    }

    public void SkillUpOpen()
    {
        SkillSetObject.SetActive(false);
        //SkillUpObject.SetActive(true);
    }

    public void SelectView()
    {
        SkillSetObject.SetActive(false);
       // SkillUpObject.SetActive(false);
    }
}
