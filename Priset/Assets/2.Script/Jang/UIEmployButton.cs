using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIEmployButton : MonoBehaviour {

    Button employButton;

    private void Awake()
    {
        employButton = GetComponent<Button>();
        employButton.onClick.AddListener(EmployPress);
 
    }
    void EmployPress()
    {

    }
}
