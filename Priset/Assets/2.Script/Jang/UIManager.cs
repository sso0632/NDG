using System.Collections;
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

    public Sprite[] CharacterImage;

    public EventSystem currentEvents;

    public GameObject CaveSupervisePanel;
    public GameObject FriendlyManagerPanel;
    public GameObject PriestManagerPanel;

    public Text FriendlyResetTimerText;

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
        PriestPanel.Init();
    }
    public void CaveSupervise()
    {
        PriestManagerPanel.SetActive(false);
        FriendlyManagerPanel.SetActive(false);
        CaveSupervisePanel.SetActive(true);        
    }
    public void FriendlySupervise()
    {
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(true);
        PriestManagerPanel.SetActive(false);
    }
    public void PriestSupervise()
    {
        PriestManagerPanel.SetActive(true);
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(false);
    }
    public void FriendlyResetTextSet(int min, float second)
    {
        FriendlyResetTimerText.text = 
            string.Format("{0:D2} : {1:D2}", min, (int)second);
    }
    
}
