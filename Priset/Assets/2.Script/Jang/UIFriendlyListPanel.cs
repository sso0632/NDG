using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendlyListPanel : MonoBehaviour
{
    int Count;
    RectTransform contentRect;
    Transform viewCotentList;


    private void Awake()
    {
        contentRect = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        ListHeight();
    } 
    public void ListHeight()
    {
        Count = transform.GetChild(0).GetChild(0).childCount;
        contentRect.sizeDelta = new Vector2(0 , contentRect.rect.height + Count * 50);
    }



    public void MakeCharacterField()
    {
        GameObject field = Instantiate(UIManager.instance.CharacterField);
        UIFriendlyField fieldData = field.GetComponent<UIFriendlyField>();




    }



}
