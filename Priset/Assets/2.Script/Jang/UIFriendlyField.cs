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

    int m_characterIndex;

    BattleCharacter haveCharacter;          //생성할 캐릭터

    tdelgate<BattleCharacter> CreateFunction;   //생성함수 

    public int CharacterIndex
    {
        get
        {
            return m_characterIndex; 
        }
        set
        {
            if (value < 0)
                m_characterIndex = 0;
            else if (value > UIManager.instance.CharacterImage.Length - 1)
                m_characterIndex = UIManager.instance.CharacterImage.Length - 1;
            else
                m_characterIndex = value;            
        }
    }

    private void Awake()
    {
        characterImage = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        employButton = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        contentText = transform.GetChild(0).GetChild(2).GetComponent<Text>();
    }
    public void FieldSet()
    { 
        CreateFunction = GameManager.instance.CreateCharacter.FieldCraete;
    }
    private void OnEnable()
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

