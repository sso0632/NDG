using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPriestChageView : MonoBehaviour {

    UIPriesthaveField[] Priestmagevalue; 

    public void Init()
    {
        Priestmagevalue = new UIPriesthaveField[10];
        ComponentSet();
    }
    void ComponentSet()
    {
        int count = this.gameObject.transform.GetChild(0).GetChildCount();
        int startindex=0;
        Transform parent= this.gameObject.transform.GetChild(0);

        for (int i=0; i< count*2; i++)
        {
            if(i>=count)
            {
                parent = this.gameObject.transform.GetChild(1);
                Priestmagevalue[i] = parent.GetChild(startindex).GetComponent<UIPriesthaveField>();
                startindex++;
            }
            else
            {
                Priestmagevalue[i] = parent.GetChild(i).GetComponent<UIPriesthaveField>();
            }
            Priestmagevalue[i].Init();
        }
    }
    public void CharacterUnlock(int _Index)
    {
        Priestmagevalue[_Index].UnLockFunction();
    }
}
