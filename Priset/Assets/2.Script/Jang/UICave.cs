using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICave : MonoBehaviour
{

    Text superviseText;
    int sizeForce;

    private void Awake()
    {
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
}
