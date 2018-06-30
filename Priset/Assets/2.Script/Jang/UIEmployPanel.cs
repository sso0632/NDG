using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sang;

public class UIEmployPanel : MonoBehaviour {

    Image employCharacterImage;
    Button employButton;
    Button closeButton;

    BattleCharacter employCharacter;
    tdelgate<BattleCharacter> CreateFunction;   //생성함수 
    UIFriendlyField currentFieldyField;

    Text GoldText;
    Text FoodText;

    private void Awake()
    {
        employCharacterImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        employButton = transform.GetChild(1).GetComponent<Button>();
        closeButton = transform.GetChild(2).GetComponent<Button>();

        GoldText = transform.GetChild(3).GetChild(0).GetComponent<Text>();
        //FoodText = transform.GetChild(3).GetChild(1).GetComponent<Text>();

        ButtonDataInit();
    }
    void ButtonDataInit()
    {
        employButton.onClick.AddListener(EmployPress);
        closeButton.onClick.AddListener(ClosePress);
    }
    private void Start()
    {
        CreateFunction = GameManager.instance.CreateCharacter.FieldCraete;
    }
    void ClosePress()
    {
        gameObject.SetActive(false);
    }
    void EmployPress()
    {
        if(PlayerManager.instance.GoldTraid(employCharacter.NeedMoney))
        { 
            CreateFunction(employCharacter);
            currentFieldyField.SuccessEmploy();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("돈이 부족 합니다");
        }
    }
    public void ContentSet(BattleCharacter character)
    {
        employCharacterImage.sprite = DataSet.CharacterImageResources[character.Index];
        employCharacter = character;
        InfoSet();
    }
    public void EmployFrieldyField(UIFriendlyField friendly)
    {
        currentFieldyField = friendly;
    }

    void InfoSet()
    {
        GoldText.text = employCharacter.NeedMoney.ToString();
        //돈 정보 주입
    }
}
