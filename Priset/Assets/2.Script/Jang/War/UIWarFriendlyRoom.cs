using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIWarFriendlyRoom : MonoBehaviour, IPointerClickHandler
{
    BattleCharacter friendlyBattle;
    Image partyFriendlyImage;

    public BattleCharacter GetBattleFriendlyData
    {
        get { return friendlyBattle; }
    }
    void Awake()
    {
       partyFriendlyImage = transform.GetChild(0).GetComponent<Image>();
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    public void OnPointerClick(PointerEventData pointer)
    {
        
    }
}
