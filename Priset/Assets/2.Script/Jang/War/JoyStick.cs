using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    public static Vector3 MoveDir;
 
    public RectTransform JoyBack;

    public void OnDrag(PointerEventData eventData)
    {
        if (TwoBetweenDis() == true)
        {
            transform.position = eventData.position;
        }
        if (TwoBetweenDis() == false)
        {
            Vector2 currentPos = (eventData.position - (Vector2)JoyBack.position).normalized;

            MoveDir.x = currentPos.x;
            MoveDir.z = currentPos.y;

            transform.position = (Vector2)JoyBack.position + (currentPos * 50);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = JoyBack.position;
        MoveDir = Vector3.zero;
    }
    private bool TwoBetweenDis()
    {
        float dis = Vector2.Distance(JoyBack.position, transform.position);

        if (dis >= 50)
            return false;
        else
            return true;
    }
}
