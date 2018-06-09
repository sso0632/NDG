using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIFriendlyField : MonoBehaviour
{
    Image  characterImage;
    Button employButton;
    Text contentText;

    GameObject EmployObj;

    private void Awake()
    {
        characterImage = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        employButton = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        contentText = transform.GetChild(0).GetChild(2).GetComponent<Text>();

        EmployObj = transform.GetChild(1).gameObject;
    }
    private void OnEnable()
    {
        EmployObj.SetActive(false);
    }

    public void FieldSet()
    {

    }

}
