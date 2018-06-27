using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParty : MonoBehaviour
{
    UIPartyMember[] partyMembers;

    public delegate void UIPartyMemberCall(UIPartyMember memeber);
    public static event UIPartyMemberCall PartyMemberCallEvent;

    public void UIPartyInit()
    {
        partyMembers = new UIPartyMember[transform.childCount];

        for (int i = 0; i < partyMembers.Length; ++i)
        {
            partyMembers[i] = transform.GetChild(i).GetComponent<UIPartyMember>();
            partyMembers[i].MemberInit();
        }
    }
   
    public void DataInit()
    {
        UIPartyInit();
        PlayerParty tempParty = GameManager.instance.PM.GetPlayerParty;
        List<int> tempBatlleNumber = new List<int>();
        int activeCount = 0;
        int partyCount = tempParty.PartyCount();
        
        for (int i = 0; i < partyCount; ++i)
        {            
            if (tempParty.GetActors()[i] !=  null)
            {
                ++activeCount;
                tempBatlleNumber.Add(i);
            }
        }
        if (activeCount != 0)
        {
            for (int i = activeCount; i < partyMembers.Length; ++i)
            {
                partyMembers[i].gameObject.SetActive(false);                
            }
        }

        Vector2[] tempConvert = PartyMemberConvert(activeCount);


        for (int i = 0; i < activeCount; ++i)
        {
            partyMembers[i].gameObject.SetActive(true);
            partyMembers[i].GetRectField().localPosition = tempConvert[i];
            partyMembers[i].SetBatlleData(tempBatlleNumber[i]);
            partyMembers[i].AddEvent();
        }


        tempBatlleNumber.Clear();
    }
    Vector2[] PartyMemberConvert(int memberCount)
    {
        Vector2[] tempConvertPos = new Vector2[memberCount];

        switch (memberCount)
        {
            case 1:
                tempConvertPos[0] = new Vector2(386, -196);
                break;
            case 2:
                tempConvertPos[0] = new Vector2(385, -244);
                tempConvertPos[1] = new Vector2(436, -135);
                break;
            case 3:
                tempConvertPos[0] = new Vector2(422, -349);
                tempConvertPos[1] = new Vector2(385, -244);
                tempConvertPos[2] = new Vector2(436, -135);
                break;
            case 4:
                tempConvertPos[0] = new Vector2(422, -349);
                tempConvertPos[1] = new Vector2(385, -244);
                tempConvertPos[2] = new Vector2(436, -135);
                tempConvertPos[3] = new Vector2(552, -102);
                break;
        }
        return tempConvertPos;
    }





}
