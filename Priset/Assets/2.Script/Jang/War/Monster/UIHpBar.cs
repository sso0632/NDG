using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpBar : MonoBehaviour
{
    Acter nowActor;
    Text barText;
    RectTransform rectField;
    Vector2 viewPortVector;

    int minValue = 0;
    int maxValue = 0;
    int currentValue = 0;

    private void Awake()
    {
        barText = GetComponent<Text>();
        rectField = GetComponent<RectTransform>();
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
        minValue = 0;
        maxValue = nowActor.HChacter.MHeath;
        currentValue = maxValue;
        barText.text = string.Format("{0}", currentValue);
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
        viewPortVector.y += 80f;
        rectField.position = viewPortVector;
    }

    public void HealthChange(BattleCharacter actor)
    {
        if (actor == null)
            return;
        if (actor != nowActor.HChacter)
            return;

        currentValue = nowActor.HChacter.HP;
        barText.text = string.Format("{0}", currentValue);
        if(currentValue <= minValue)
            OptionChange();
    }
    void OptionChange()
    {
        UIWarManager.instance.PushHpBar(this);
        switch (nowActor.tag)
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
    }



}
