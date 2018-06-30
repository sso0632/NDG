using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPartyMember : MonoBehaviour
{
    Image memberImage;

    RectTransform rectField;

    int memberIndex;

    public int MemberIndex
    {
        get { return memberIndex; }
        set { memberIndex = value; }
    }
    
    public void MemberInit()
    {
        memberImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        rectField = GetComponent<RectTransform>();
    }
    public RectTransform GetRectField()
    {
        return rectField;
    }
    public void AddEvent()
    {
        UIParty.PartyMemberCallEvent += MemberCompare;
    }
    public void RemoveEvent()
    {
        UIParty.PartyMemberCallEvent -= MemberCompare;
    }
    public void SetBatlleData(int index)
    {
        memberIndex = index;
        memberImage.sprite = DataSet.CharacterImageResources[index];
    }

    //멤버 힐 하는 부분
    public void MemberHeal()
    {
       PriestActor tempActor = PlayerManager.instance.GetNowPriest();

        if (tempActor == null)
            return;

        Debug.Log("멤버 번호 : " + memberIndex + " - 힐링");

        tempActor.havePriest.SkillActive(memberIndex);        

    }

    void MemberCompare(UIPartyMember member)
    {
        if (member != this)
            return;
        



    }



    


}
