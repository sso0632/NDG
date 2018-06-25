using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDamageText : MonoBehaviour
{
    Text damageText;
    bool isEvent;
    float delayTimer;
    float force;
    float colorAlpha;


    RectTransform rectField;
    Vector3 showPoint;


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
            damageText.gameObject.SetActive(true);
            StartCoroutine(DamageAnimation());
        }
    }

    IEnumerator DamageAnimation()
    {
        damageText.color = new Color(1, 0, 0, 1);
        damageText.fontSize = 5;
        delayTimer = 0;
        colorAlpha = 1;
        force = 50;
    
        rectField.position = Camera.main.WorldToScreenPoint(showPoint);
        
        while (delayTimer <= 1.2f)
        {
            delayTimer += Time.deltaTime;

            if (damageText.fontSize <= 55)
                damageText.fontSize += 1;

            rectField.position += Vector3.up * Time.deltaTime * force;

            force -= Time.deltaTime;

            if (colorAlpha >= 0.5f)
                colorAlpha -= Time.deltaTime * 2;

            damageText.color = new Color(1, 0, 0, colorAlpha);
            
            yield return null;
        }

        isEvent = false;
        UIWarManager.instance.PushDamageText(this);
        
        yield return null;
    }


    
    
	
}
