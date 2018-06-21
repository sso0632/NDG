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
    private void Update()
    {
        if (nowActor == null)
            return;

        viewPortVector = Camera.main.WorldToScreenPoint(nowActor.transform.position);
        viewPortVector.y += 70f;
        rectField.position = viewPortVector;

    }
    public void EventAdd()
    {
        UIWarManager.BarHealthCall += HeathCall;
    }
    public void EventRemove()
    {
        UIWarManager.BarHealthCall -= HeathCall;
    }

    void HeathCall(Acter actor)
    {
        if (nowActor != actor)
            return;

        hpSlider.value = nowActor.HChacter.HP;
        if (nowActor.HChacter.HP > 0)
            return;

        MonsterActor temp = (MonsterActor)nowActor;
        temp.SetHpBarExist = false;
        temp = null; ;

        UIWarManager.instance.PushHpBar(this);
        nowActor = null;
    }

  
}
