using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPriesthaveField : MonoBehaviour {
    Button thisbutton;
    Image thisImage;    
    bool Lock;

    public void Init(int num)
    {
        thisbutton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
        Lock = true;
        CheckLock();
        SetFunction(num);
    }

    void CheckLock()
    {
        if(Lock)
        {
            thisImage.color = Color.black;
            thisbutton.interactable = false;
        }
        else
        {
            thisImage.color = Color.white;
            thisbutton.interactable = true;
        }
    }

    public void UnLockFunction()
    {
        Lock = false;
        CheckLock();
    }
    public void SetFunction(int index)
    {
        thisbutton.onClick.AddListener(() => PlayerManager.instance.ChagePriest(index));
    }
}

