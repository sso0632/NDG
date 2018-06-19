using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIWarFriendlyRoom : MonoBehaviour, IPointerClickHandler
{
    Image partyFriendlyImage;
    BattleCharacter roomCharacter;
    int roomIndex;

    void Awake()
    {
       partyFriendlyImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
       roomIndex = int.Parse(name.ToString());
    }
    private void OnEnable()
    {
        UIPartyButton.PartySelectEvent += WarRoomSet;
    }
    
    void WarRoomSet()
    {
        if (roomIndex == -1)
            return;

        PlayerParty tempParty = GameManager.instance.PM.GetPlayerParty;

        roomCharacter = tempParty.GetPartyMember(roomIndex);

        if(roomCharacter == null)
        {
            Debug.Log("UI__WAR__FRIENDLY BATTLE CHARACTER NULL____");
            return;
        }
        int index = roomCharacter.Index;

        partyFriendlyImage.sprite = DataSet.CharacterImageResources[index];
    }
    public void OnPointerClick(PointerEventData pointer)
    {
        UIWarManager.instance.FriendlyRoom.RepresentFriendly(roomCharacter.Index);
    }
}
