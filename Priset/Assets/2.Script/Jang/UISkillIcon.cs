using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillIcon : MonoBehaviour {

    Image SkillIcon;

    public void Init()
    {
        SkillIcon= this.transform.GetChild(0).GetComponent<Image>();
        ImageNone();
    }

    public void SkillSet(int skillindex)
    { 
        ImageView(skillindex);
    }
    void ImageView(int skillindex)
    {
        SkillIcon.sprite = LoadImage(skillindex);
    }
    void ImageNone()
    {
        SkillIcon.color = new Color(1, 1, 1, 0);
    }
    Sprite LoadImage(int skillindex)
    {
        SkillIcon.color = new Color(1, 1, 1, 1);
        string Path = null;
        switch(skillindex)
        {
            case 0:
                Path = "SkillImage/healing";
                return Resources.Load<Sprite>(Path);
                break;
            case 1:
                Path = "SkillImage/AttUp";
                return Resources.Load<Sprite>(Path);
                break;
        }
        ImageNone();
        return null;
    }
}
