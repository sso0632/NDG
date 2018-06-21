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
    }
    private void Update()
    {
        if (nowActor == null)
            return;

        viewPortVector = Camera.main.WorldToScreenPoint(nowActor.transform.position);
        viewPortVector.y += 60f;
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

        if (nowActor.HChacter.HP <= 0)
        {
            nowActor = null;
            UIWarManager.instance.PushHpBar(this);
            return;

        }
        hpSlider.value = nowActor.HChacter.HP / nowActor.HChacter.MHeath;
    }

  
}
