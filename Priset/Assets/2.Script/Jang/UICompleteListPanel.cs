using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UICompleteListPanel : MonoBehaviour, IPointerClickHandler
{
    Image currentFriendlyImage;
    Image currentSelectObj;

    BattleCharacter currentBattleCharacter;
    bool isPress;

    Button nextBtn;
    Button previousBtn;
    Button dungeonBtn;

    bool isRetain;

    public  bool Press
    {
        get { return isPress; }
        set { isPress = value; }
    }

    public int viewIndex = 0;

    public  BattleCharacter GetBattleCharacter
    {
        get { return currentBattleCharacter; }
    }
    private void Awake()
    {
        currentSelectObj = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        currentFriendlyImage = transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();

        nextBtn = transform.GetChild(2).GetComponent<Button>();
        previousBtn = transform.GetChild(3).GetComponent<Button>();
        dungeonBtn = transform.GetChild(transform.childCount - 1).GetComponent<Button>();

        nextBtn.onClick.AddListener(NextPress);
        previousBtn.onClick.AddListener(PreviousPress);
        dungeonBtn.onClick.AddListener(DungeonPress);

        gameObject.SetActive(false);
        currentSelectObj.gameObject.SetActive(false);
        currentFriendlyImage.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        FriendlyFieldSet();
        Check();
    }
    void DungeonPress()
    {
        int length = GameManager.instance.PM.havePriestCharacter.Length;
        for (int i =0; i < length; ++i)
        {
            PriestActor tempActor;
            tempActor = GameManager.instance.PM.havePriestCharacter[i];
            tempActor.StopDecision();
        }
        GameManager.instance.GoWarScene();
    }
    void FriendlyFieldSet()
    {
        if (GameManager.instance.PM.EmployCharacter.Count <= 0)
        {
            NoneFriendlyField();
            return;
        }
          
        currentBattleCharacter = GameManager.instance.PM.EmployCharacter[viewIndex];

        int index = currentBattleCharacter.Index;

        if (!currentFriendlyImage.gameObject.activeSelf)
            currentFriendlyImage.gameObject.SetActive(true);

        currentFriendlyImage.sprite = UIManager.instance.CharacterImage[index];
    }
    void NextPress()
    {
        if (GameManager.instance.PM.EmployCharacter.Count <= 0)
        {
            NoneFriendlyField();
            return;
        };

        currentSelectObj.gameObject.SetActive(false);
        isRetain = false;

        ++viewIndex;

        if (viewIndex > GameManager.instance.PM.EmployCharacter.Count - 1)
            viewIndex = 0;

        FriendlyFieldSet();
    }
    void Check()
    {
        if(GameManager.instance.PM.EmployCharacter.Count > 0)
        {
            nextBtn.interactable = true;
            previousBtn.interactable = true;
            FriendlyFieldSet();
        }
        else 
        {
            nextBtn.interactable = false;
            previousBtn.interactable = false;
        }
    }
    void PreviousPress()
    {
        if (GameManager.instance.PM.EmployCharacter.Count <= 0)
        {
            NoneFriendlyField();
            return;
        }
            
        currentSelectObj.gameObject.SetActive(false);
        isRetain = false;

        --viewIndex;

        if (viewIndex < 0)
            viewIndex = GameManager.instance.PM.EmployCharacter.Count - 1;

        FriendlyFieldSet();
    }
    void NoneFriendlyField()
    {
        isRetain = false;
        currentFriendlyImage.gameObject.SetActive(false);
        nextBtn.interactable = false;
        previousBtn.interactable = false;
    }
    IEnumerator PressFriendlyRoom()
    {
        isPress = true;
        currentSelectObj.gameObject.SetActive(true);
        float alphaValue = 0.0f;
        float force = 0.8f;

        while (isRetain)
        {
            if (alphaValue > 0.75f)
                force = -Time.deltaTime;
            else if (alphaValue < 0.35f)
                force = Time.deltaTime;

            alphaValue += force;
            currentSelectObj.color = new Color(0, 0.7f, 0.45f, alphaValue);
            yield return null;
        }

        currentSelectObj.gameObject.SetActive(false);
        isPress = false;
    }
    
    public void SuccessRoomPress()
    {
        if (GameManager.instance.PM.EmployCharacter.Count <= 0)
        {
            NoneFriendlyField();
            return;
        }
        
        GameManager.instance.PM.EmployCharacter.Remove(currentBattleCharacter);
        currentBattleCharacter = null;
        nextBtn.interactable = true;
        previousBtn.interactable = true;

        isRetain = false;
        
        ++viewIndex;
        currentSelectObj.gameObject.SetActive(false);

        if (viewIndex > GameManager.instance.PM.EmployCharacter.Count - 1)
            viewIndex = 0;
        
        FriendlyFieldSet();
    }
    public void OnPointerClick(PointerEventData point)
    {
        if (currentBattleCharacter == null)
            return;

        isRetain = true;
        if (!isPress)
            StartCoroutine(PressFriendlyRoom());
    }

}
