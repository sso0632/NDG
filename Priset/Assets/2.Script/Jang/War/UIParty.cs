using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParty : MonoBehaviour
{
    UIPartyMember[] partyMembers;

    public delegate void UIPartyMemberCall(UIPartyMember memeber);
    public static event UIPartyMemberCall PartyMemberCallEvent;

    private void Awake()
    {
        partyMembers = new UIPartyMember[transform.childCount];

        for (int i = 0; i < partyMembers.Length; ++i)
        {
            partyMembers[i] = transform.GetChild(i).GetComponent<UIPartyMember>();
        }
    }
    public void DataInit()
    {
        for (int i = 0; i < partyMembers.Length; ++i)
        {
            partyMembers[i].AddEvent();
        }
    }

}
