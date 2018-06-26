using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDamageText : MonoBehaviour
{
    Text damageText;
    bool isEvent;

    float force;
    float colorAlpha;
    int fontForce;

    RectTransform rectField;
    Vector3 showPoint;
    Vector3 drawPoint;

    float showTimer;

    private void Awake()
    {
        damageText = GetComponent<Text>();
        rectField = GetComponent<RectTransform>();
        isEvent = false;
    }

    public void SetDamageText(Vector3 point,string damage)
    {
        damageText.text = damage;
        showPoint = point;
    }
    public void OpenTextUI()
    {
        if(!isEvent)
        {
            isEvent = true;
            ShowTextDataInit();
            StartCoroutine(DamageAnimation());
        }
    }
    void ShowTextDataInit()
    {
        damageText.gameObject.SetActive(true);
        damageText.color = new Color(1, 1, 1, 1);
        damageText.fontSize = 25;

        rectField.position = Camera.main.WorldToScreenPoint(showPoint);
    }
    void AnimStart()
    {
        colorAlpha = 0.5f;
        force = 150;
        showTimer = 0;
        fontForce = 1;

        damageText.color = new Color(1, 0, 0, 1);
        damageText.fontSize = 5;
        colorAlpha = 1;
        force = 50;

        rectField.position = Camera.main.WorldToScreenPoint(showPoint);
        drawPoint = rectField.position;
    }

    IEnumerator DamageAnimation()
    {
        AnimStart();
      
        while (showTimer <= 0.5f)
        {
            showTimer += Time.deltaTime;

            drawPoint.y += Time.deltaTime * force;

            drawPoint.z = 0;

            if (colorAlpha <= 1)
                colorAlpha += Time.deltaTime;
            
            if (force < 300)
                force += Time.deltaTime * 200;
            else if (force > 300)
                force -= Time.deltaTime * 100;

            if (damageText.fontSize <= 55)
                damageText.fontSize += 2;

            damageText.color = new Color(1, 1, 1, colorAlpha);
            rectField.position = drawPoint;
            yield return null;
        }

        isEvent = false;
        UIWarManager.instance.PushDamageText(this);
    }
}
