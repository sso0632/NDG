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
    GameObject employSuccessObj;


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
    
        employSuccessObj = transform.GetChild(1).gameObject;
        employButton.onClick.AddListener(Create);

    }
    public void InitSet()
    {
        employSuccessObj.SetActive(false);
    }

    public void FieldSet(int index)
    {
        m_characterIndex = index;
        characterImage.sprite = UIManager.instance.CharacterImage[index];
    }

    public void CharacterSet(BattleCharacter character)      //어디선가 에서 받아와야함
    {
        haveCharacter = character;  
    }
    public void SuccessEmploy()
    {
        employSuccessObj.SetActive(true);
        haveCharacter = null;
    }

    private void Create()            //섭외 버튼에 들어가는 기눙
    {
        UIManager.instance.EmployPanel.gameObject.SetActive(true);
        UIManager.instance.EmployPanel.EmployFrieldyField(this);
        UIManager.instance.EmployPanel.ContentSet(haveCharacter);
    }
}

