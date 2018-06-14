using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillIcon : MonoBehaviour {

    Image SkillIcon;

    public void Init()
    {
        SkillIcon= this.transform.GetChild(0).GetComponent<Image>();
    }

    public void SkillSet(int skillindex)
    { 
        ImageView(skillindex);
    }
    void ImageView(int skillindex)
    {
        SkillIcon.sprite = LoadImage(skillindex);
    }

    Sprite LoadImage(int skillindex)
    {
        string Path = null;
        switch(skillindex)
        {
            case 0:
                Path = "SkillImage/healing";
                return Resources.Load<Sprite>(Path);
                break;
        }
       
        return null;
    }
}
