using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIHealingButton : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    public static RectTransform RectField;
    public static RectTransform ColliderField;
    public RectTransform backPoint;

    UIPartyMember colliderPartyMember;

    float dragDis = 80f;
    bool isHealing = false;

    WaitForSeconds healingWaitDelay = new WaitForSeconds(0.5f);

    private void Awake()
    {
        RectField = GetComponent<RectTransform>();
    }
   
    public void OnDrag(PointerEventData eventData)
    {
        if (colliderPartyMember == null)
        {
            if (TwoBetweenDis() == true)
            {
                transform.position = eventData.position;
            }
            if (TwoBetweenDis() == false)
            {
                Vector2 currentPos = (eventData.position - (Vector2)backPoint.position).normalized;
                transform.position = (Vector2)backPoint.position + (currentPos * dragDis);
            }
        }
        else if(colliderPartyMember != null)
        {
            if (Vector2.Distance(eventData.position, colliderPartyMember.transform.position) >= 100f)
            {
                colliderPartyMember = null;
                return;
            }
            transform.position = colliderPartyMember.transform.position;

            if(!isHealing)
            {
                isHealing = true;
                StartCoroutine(Healing());
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = backPoint.position;
        colliderPartyMember = null;
    }
    IEnumerator Healing()
    {
        while(colliderPartyMember != null)
        {
            //힐링 부분 
            colliderPartyMember.MemberHeal();

            yield return healingWaitDelay;
        }
        isHealing = false;       
    }

    private bool TwoBetweenDis()
    {
        float dis = Vector2.Distance(backPoint.position, transform.position);
        if (dis >= dragDis)
            return false;
        else
            return true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (colliderPartyMember != null)
            return;
        if (collision.CompareTag("UIPartyMember"))
        {           
            UIPartyMember tempMember = collision.GetComponent<UIPartyMember>();
            if (tempMember == null)
                return;

            colliderPartyMember = tempMember;
        }
    }



}
