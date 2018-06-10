using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIFriendlyField : MonoBehaviour
{
    Image  characterImage;
    Button employButton;
    Text contentText;


    int m_characterIndex;

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

    }

}
