using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIPartyButton : MonoBehaviour, IPointerClickHandler
{
    public delegate void FriendlyButtonGate();
    public static event FriendlyButtonGate PartySelectEvent;
    GameObject partyRoomUI;

    Image currentFriendlyRoom;
    Image currentFriendlyImage;

    List<UIWarFriendlyRoom> roomList;

    void Awake()
    {
        RoomSet();
        partyRoomUI = transform.GetChild(0).gameObject;

        currentFriendlyRoom = transform.GetComponent<Image>();
        currentFriendlyImage = transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }
    void Start()
    {
        partyRoomUI.SetActive(false);
    }

    void RoomSet()
    {
        roomList = new List<UIWarFriendlyRoom>();

        int count = transform.GetChild(0).childCount;
        for (int i = 0; i < count; ++i)
        {
            roomList.Add(transform.GetChild(0).GetChild(i).GetComponent<UIWarFriendlyRoom>());
        }
    }
    public void OnPointerClick(PointerEventData pointer)
    {
        if (partyRoomUI.activeSelf)
        {
            PartyUIExist(false);
        }
        else
        {
            PartyUIExist(true);
        }
    }


    void PartyUIExist(bool isExist)
    {
        if(!isExist)
        {
            partyRoomUI.SetActive(false);
            currentFriendlyRoom.color = new Color(1, 1, 1, 1);
            currentFriendlyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            partyRoomUI.SetActive(true);
            currentFriendlyRoom.color = new Color(1, 1, 1, 0.5f);
            currentFriendlyImage.color = new Color(1, 1, 1, 0.5f);
            PartySelectEvent();
        }
    }

    public void RepresentFriendly(int index)
    {
        PartyUIExist(false);
        currentFriendlyImage.sprite = DataSet.CharacterImageResources[index];
    }
}
