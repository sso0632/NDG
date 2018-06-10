using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendlyListPanel : MonoBehaviour
{
    RectTransform contentRect;
    List<UIFriendlyField> currentFieldList;


    private void Awake()
    {
        currentFieldList = new List<UIFriendlyField>();
        contentRect = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        MakeCharacterField();
        ListHeight();
        ResetDataField();
    }
    public void ListHeight()
    {
        contentRect.sizeDelta = new Vector2(0 , currentFieldList.Count * 100);
    }
    public void ResetDataField()
    {
        for(int i =0; i< currentFieldList.Count; ++i)
        {
            int rand = Random.Range(0, UIManager.instance.CharacterImage.Length);
            currentFieldList[i].FieldSet(rand);

            BattleCharacter tempCharacter = new BattleCharacter(rand);
            currentFieldList[i].CharacterSet(tempCharacter);
        }
    }
    public void MakeCharacterField()
    {
        int genCount = Random.Range(1, 10);

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
