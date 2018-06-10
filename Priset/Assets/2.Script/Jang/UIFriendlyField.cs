using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sang;

public class UIFriendlyField : MonoBehaviour
{
    Image  characterImage;
    Button employButton;
    Text contentText;

    GameObject EmployObj;

    BattleCharacter haveCharacter;          //생성할 캐릭터

    tdelgate<BattleCharacter> CreateFunction;   //생성함수 

    private void Awake()
    {
        characterImage = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        employButton = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        contentText = transform.GetChild(0).GetChild(2).GetComponent<Text>();

        EmployObj = transform.GetChild(1).gameObject;
        CreateFunction = GameManager.instance.CreateCharacter.FieldCraete;
    }
    private void OnEnable()
    {
        EmployObj.SetActive(false);
    }

    public void FieldSet()  //이미지 변경 및 설정
    {

    }

   public void characterSet(BattleCharacter character)      //어디선가 에서 받아와야함
    {
        haveCharacter = character;
    }

    public void Create()            //섭외 버튼에 들어가는 기눙
    {
        CreateFunction(haveCharacter);
    }
}

