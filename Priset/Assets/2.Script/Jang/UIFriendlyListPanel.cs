using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendlyListPanel : MonoBehaviour
{
    RectTransform contentRect;
    List<UIFriendlyField> currentFieldList;

    Button refreshFriendlyBtn;

    
    private void Start()
    {
        MakeCharacterField();
        ResetDataField();
    }
    public void Init()
    {
        currentFieldList = new List<UIFriendlyField>();
        contentRect = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
        refreshFriendlyBtn = transform.GetChild(3).GetComponent<Button>();
        refreshFriendlyBtn.onClick.AddListener(RefeshPress);
    }

    public void RefreshOn()
    {
        refreshFriendlyBtn.interactable = true;
    }
    void RefeshPress()
    {        
        MakeCharacterField();
        ResetDataField();
        refreshFriendlyBtn.interactable = false;
        TimeManager.instance.isResetFriendly = false;
        TimeManager.instance.RestartFriendlyTimer();
    }
    void ResetDataField()
    {
        for(int i =0; i< currentFieldList.Count; ++i)
        {
            int rand = Random.Range(0, UIManager.instance.CharacterImage.Length);
            currentFieldList[i].FieldSet(rand);

            Friendly tempCharacter = new Friendly(rand);
            currentFieldList[i].CharacterSet(tempCharacter);
            currentFieldList[i].InitSet();
        }
        contentRect.sizeDelta = new Vector2(0, currentFieldList.Count * 100);

    }
    void MakeCharacterField()
    {
        int genCount = Random.Range(4, 10);

        if (currentFieldList.Count > genCount)
        {
            int disCount = currentFieldList.Count - genCount;
            int currentAllCount = currentFieldList.Count;

            for (int i = currentAllCount - 1 ; i >= (currentAllCount - disCount) - 1; --i)
            {
                GameObject obj = currentFieldList[i].gameObject;
                Destroy(obj);
                currentFieldList.RemoveAt(i);
            }
        }
        else if (currentFieldList.Count < genCount)
        {
            int disCount = genCount - currentFieldList.Count;
            
            for(int i =0; i < disCount; ++i)
            {
                GameObject field = Instantiate(UIManager.instance.CharacterField);
                field.name = UIManager.instance.CharacterField.name;

                UIFriendlyField fieldData = field.GetComponent<UIFriendlyField>();
                field.transform.SetParent(contentRect);

                field.transform.localScale = Vector3.one;
                field.transform.position = Vector3.one;

                currentFieldList.Add(fieldData);
            }
        }
    }

    
    



}
