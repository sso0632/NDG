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

    
    private void Awake()
    {
        employCharacterImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        employButton = transform.GetChild(1).GetComponent<Button>();
        closeButton = transform.GetChild(2).GetComponent<Button>();
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
        CreateFunction(employCharacter);
        currentFieldyField.SuccessEmploy();
        gameObject.SetActive(false);
    }
    public void ContentSet(BattleCharacter character)
    {
        employCharacterImage.sprite = DataSet.CharacterImageResources[character.Index];
        employCharacter = character;
    }
    public void EmployFrieldyField(UIFriendlyField friendly)
    {
        currentFieldyField = friendly;
    }


}
