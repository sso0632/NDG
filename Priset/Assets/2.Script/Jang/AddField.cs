using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddField : MonoBehaviour {

    RectTransform thisTransform;
    VerticalLayoutGroup VerticalGroup;
    public float FieldHeight;       //요소의 높이

    Vector2 value;

    private void Awake()
    {
        VerticalGroup = GetComponent<VerticalLayoutGroup>();
        thisTransform = GetComponent<RectTransform>();
        value = new Vector2();
    }

    private void OnEnable()
    {
        SetField();
    }
    void SetField()
    {
        value.y = (FieldHeight + VerticalGroup.spacing)*this.transform.childCount;
        thisTransform.sizeDelta = value;
    }
}
