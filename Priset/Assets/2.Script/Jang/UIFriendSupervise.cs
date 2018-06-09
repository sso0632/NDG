using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIFriendSupervise : MonoBehaviour
{
    Button superviseButton;

    private void Awake()
    {
        superviseButton = GetComponent<Button>();
        superviseButton.onClick.AddListener(SupervisePress);
    }

    void SupervisePress()
    {
        UIManager.instance.FriendlySupervise();
    }

}
