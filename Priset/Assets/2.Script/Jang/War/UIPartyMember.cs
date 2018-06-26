using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPartyMember : MonoBehaviour
{
    Image memberImage;
    RectTransform rectField;
    private void Awake()
    {
        memberImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        rectField = GetComponent<RectTransform>();
    }
    public void AddEvent()
    {
        UIParty.PartyMemberCallEvent += MemberCompare;
    }
    public void RemoveEvent()
    {
        UIParty.PartyMemberCallEvent -= MemberCompare;
    }
    public void UIPartyMemberSet(int _index)
    {
        memberImage.sprite = DataSet.CharacterImageResources[_index];
    }
    void MemberCompare(UIPartyMember member)
    {
        if (member != this)
            return;
    }



    


}
