using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpBar : MonoBehaviour
{
    Slider hpSlider;
    Acter nowActor;

    RectTransform rectField;
    Vector2 viewPortVector;

    private void Awake()
    {
        hpSlider = GetComponent<Slider>();
        rectField = GetComponent<RectTransform>();
        hpSlider.maxValue = 1;
        hpSlider.minValue = 0;
    }
    public Acter GetBattleCharacter()
    {
        return nowActor;
    }    
    public void SetBattleCharacter(Acter _setChar)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        if (nowActor == _setChar)
            return;

        nowActor = _setChar;
        hpSlider.maxValue = nowActor.HChacter.MHeath;
        hpSlider.minValue = 0;
        hpSlider.value = nowActor.HChacter.HP;
    }
    public void AddEvent()
    {
        UIWarManager.ChangeBarAmountEvent += HealthChange;
    }
    public void RemoveEvent()
    {
        UIWarManager.ChangeBarAmountEvent -= HealthChange;

    }
    void Update()
    {
        if (nowActor == null)
            return;

        viewPortVector = Camera.main.WorldToScreenPoint(nowActor.transform.position);
        viewPortVector.y += 70f;
        rectField.position = viewPortVector;
    }

    public void HealthChange(BattleCharacter actor)
    {
        if (actor != nowActor.HChacter)
            return;

        hpSlider.value = actor.HP;
        if(hpSlider.value <= hpSlider.minValue)
        {
            OptionChange();
        }
    }
    void OptionChange()
    {
        switch(nowActor.tag)
        {
            case "Monster":
                MonsterActor tempMonster = (MonsterActor)nowActor;
                tempMonster.SetHpBarExist = false;
                nowActor = null;
                tempMonster = null;
                break;
            default:
                break;
        }
        UIWarManager.instance.PushHpBar(this);
    }



}
