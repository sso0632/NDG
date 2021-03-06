﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sang;
public class UICompleteRoom : MonoBehaviour , IPointerClickHandler
{
    Image roomCharacter;
    int roomIndex;

    private void Awake()
    {
        roomIndex = int.Parse(name);
        roomCharacter = transform.GetChild(0).GetComponent<Image>();
        roomCharacter.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData point)
    {
        if (!UIManager.instance.CompleteListPanel.Press)
            return;

        int index = UIManager.instance.CompleteListPanel.GetBattleCharacter.Index;

        roomCharacter.gameObject.SetActive(true);
        roomCharacter.sprite
             = DataSet.CharacterImageResources[index];

        SetRoom(UIManager.instance.CompleteListPanel.GetBattleCharacter);
        UIManager.instance.CompleteListPanel.SuccessRoomPress();
    }

    void SetRoom(BattleCharacter character)
    {
        switch(roomIndex)
        {
            case (int)PartyPos.LEFT_UP:
                PlayerManager.instance.GetPlayerParty.SetLeftUp(character);
                break;
            case (int)PartyPos.RIGHT_UP:
                PlayerManager.instance.GetPlayerParty.SetRightUp(character);
                break;
            case (int)PartyPos.RIGHT_DOWN:
                PlayerManager.instance.GetPlayerParty.SetRightDown(character);
                break;
            case (int)PartyPos.LEFT_DOWN:
                PlayerManager.instance.GetPlayerParty.SetLeftDown(character);
                break;
        }
    }
}
