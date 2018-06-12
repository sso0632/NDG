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

    Button nextBtn;
    Button previousBtn;

    bool isPress;
    bool isRetain;
    public int viewIndex = 0;


    private void Awake()
    {
        currentSelectObj = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        currentFriendlyImage = transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();

        nextBtn = transform.GetChild(2).GetComponent<Button>();
        previousBtn = transform.GetChild(3).GetComponent<Button>();

        nextBtn.onClick.AddListener(NextPress);
        previousBtn.onClick.AddListener(PreviousPress);

        gameObject.SetActive(false);
        currentSelectObj.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        MakeCompleteFriendlyField();
    }   
    void MakeCompleteFriendlyField()
    {
        if (GameManager.instance.PM.EmployCharacter.Count <= 0)
            return;

        currentBattleCharacter = GameManager.instance.PM.EmployCharacter[viewIndex];

        int index = currentBattleCharacter.Index;

        currentFriendlyImage.sprite = UIManager.instance.CharacterImage[index];
    }
    void NextPress()
    {
        currentSelectObj.gameObject.SetActive(false);

        isPress = false;
        isRetain = false;

        ++viewIndex;

        if (viewIndex > GameManager.instance.PM.EmployCharacter.Count - 1)
            viewIndex = 0;

        MakeCompleteFriendlyField();
    }
    void PreviousPress()
    {
        currentSelectObj.gameObject.SetActive(false);

        isPress = false;
        isRetain = false;
        --viewIndex;

        if (viewIndex < 0)
            viewIndex = GameManager.instance.PM.EmployCharacter.Count - 1;

        MakeCompleteFriendlyField();
    }
    public void OnPointerClick(PointerEventData point)
    {
        if (currentBattleCharacter == null)
            return;
        isRetain = true;
        if (!isPress)
            StartCoroutine(PressFriendlyRoom());
    }
    IEnumerator PressFriendlyRoom()
    {
        currentSelectObj.gameObject.SetActive(true);
        float alphaValue = 0.0f;
        float force = 1;

        while (isRetain)
        {
            if (alphaValue > 0.75f)
                force = -Time.deltaTime;
            else if (alphaValue < 0.35f)
                force = Time.deltaTime;

            alphaValue += force;

            currentSelectObj.color = new Color(0.2f, 0, 0, alphaValue);
            yield return null;
        }
    }


}
