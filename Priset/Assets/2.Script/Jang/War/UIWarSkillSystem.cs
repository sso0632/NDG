using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIWarSkillSystem : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    Image currentSkillImage;
    int useIndex = 0;
    
    void Awake()
    {
        currentSkillImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }
    void Init()
    {
        Skill tempSkill = GameManager.instance.SkillSpace.SkillGet(useIndex);
        currentSkillImage.sprite = DataSet.SkillImageResources[tempSkill.SkillIndex];
    }
    public void OnDrag(PointerEventData point)
    {
    

    }
    public void OnPointerClick(PointerEventData point)
    {

    }
}
