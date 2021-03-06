﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    public UIEmployPanel EmployPanel;
    public UIFriendlyListPanel FriendlyListPanel;
    public UICompleteListPanel CompleteListPanel;
    public UIPriestChageView PriestPanel;

    public GameObject CharacterField; // 용병 생성 리스트 필드 
    public GameObject CompleteCharacteField;

    public EventSystem currentEvents;

    public GameObject CaveSupervisePanel;
    public GameObject FriendlyManagerPanel;
    public GameObject PriestManagerPanel;
    public GameObject HighPriestManagerPanel;

    public Text FriendlyResetTimerText;

    public GameObject LoadUI;
    public Image SliderImage;

    public Text TownGoldText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Initialized();

        FriendlyListPanel.Init();
    }
    private void Initialized()
    {
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(false);
        EmployPanel.gameObject.SetActive(false);
        PriestManagerPanel.SetActive(false);
        HighPriestManagerPanel.SetActive(false);
        LoadUI.SetActive(false);
        PriestPanel.Init();
    }
    public void CaveSupervise()
    {
        PriestManagerPanel.SetActive(false);
        FriendlyManagerPanel.SetActive(false);
        CaveSupervisePanel.SetActive(true);
        HighPriestManagerPanel.SetActive(false);
    }
    public void FriendlySupervise()
    {
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(true);
        PriestManagerPanel.SetActive(false);
        HighPriestManagerPanel.SetActive(false);
    }
    public void PriestSupervise()
    {
        PriestManagerPanel.SetActive(true);
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(false);
        HighPriestManagerPanel.SetActive(false);
    }
    public void HighPriestSupervise()
    {
        PriestManagerPanel.SetActive(false);
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(false);
        HighPriestManagerPanel.SetActive(true);
    }
    public void FriendlyResetTextSet(int min, float second)
    {
        FriendlyResetTimerText.text = string.Format("{0:D2} : {1:D2}", min, (int)second);
    }

    public void GoldView()
    {
        TownGoldText.text =string.Format("{0:D9}", PlayerManager.instance.Money);
    }
}
