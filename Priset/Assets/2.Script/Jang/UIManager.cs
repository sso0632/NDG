using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UIEmployPanel EmployPanel;
    public GameObject CharacterField; // 용병 생성 리스트 필드 
    public Sprite[] CharacterImage;

    public EventSystem currentEvents;
    public GameObject CaveSupervisePanel;
    public GameObject FriendlyManagerPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Initialized();

    }
    
    private void Initialized()
    {
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(false);
        EmployPanel.gameObject.SetActive(false);
    }
    public void CaveSupervise()
    {
        FriendlyManagerPanel.SetActive(false);
        CaveSupervisePanel.SetActive(true);        
    }
    public void FriendlySupervise()
    {
        CaveSupervisePanel.SetActive(false);
        FriendlyManagerPanel.SetActive(true);
    }
    
}
