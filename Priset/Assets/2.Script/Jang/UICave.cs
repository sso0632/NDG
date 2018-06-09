using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UICave : MonoBehaviour
{
    Button caveButton;
    Text superviseText;
    int sizeForce;


    private void Awake()
    {
         caveButton = GetComponent<Button>();
        caveButton.onClick.AddListener(CavePress);
        superviseText = GetComponentInChildren<Text>();
    }
    private void OnEnable()
    {
        superviseText.fontSize = 40;
        StartCoroutine(CaveSupervise());
    }
    IEnumerator CaveSupervise()
    {
        while (gameObject.activeSelf)
        {
            if (superviseText.fontSize >= 55)
                sizeForce = -1;
            else if (superviseText.fontSize <= 40)
                sizeForce = 1;

            superviseText.fontSize += sizeForce;
            yield return null;
        }
    }
    private void CavePress()
    {
        UIManager.instance.CaveSupervise();
    }
}
