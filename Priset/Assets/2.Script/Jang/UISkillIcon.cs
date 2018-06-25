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
        if (DataSet.SkillImageResources[skillindex] == null)
        {
            ImageNone();
            return null;
        }
        else
            return DataSet.SkillImageResources[skillindex];
    }
}
