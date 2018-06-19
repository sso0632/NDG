using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
public class DataSet : MonoBehaviour
{
    Dictionary<string, List<BattleCharacter>> CharacterStatData;
    Dictionary<string, List<Skill>> SkillData;

    public static Sprite[] CharacterImageResources;


    public void Init()
    {
        CharacterStatLoad();
        CharacterSpriteLoad();
        SkillDataLoad();
    }

    void DebugList()
    {
        for(int i=0; i < CharacterStatData["characterstat"].Count; ++i)
        {
            Debug.Log(CharacterStatData["characterstat"][i].Attack);
        }
    }
    
    void CharacterSpriteLoad()
    {       
        int count = (int)(Resources.LoadAll("CharacterImage").Length * 0.5f);
        CharacterImageResources = new Sprite[count];

        string tempSpriteIndex = null;
        for(int i =0; i<count; ++i)
        {
            tempSpriteIndex = i.ToString();
            CharacterImageResources[i] = (Sprite)Resources.Load("CharacterImage/" + tempSpriteIndex, typeof(Sprite));
        }
    }

    void CharacterStatLoad()
    {
        TextAsset Characterstatjson = (TextAsset)Resources.Load("Json/CharacterStat", typeof(TextAsset));
        CharacterStatData = JsonConvert.DeserializeObject<Dictionary<string, List<BattleCharacter>>>(Characterstatjson.text);
    }
    void SkillDataLoad()
    {
        TextAsset Skilljson = (TextAsset)Resources.Load("Json/Skill", typeof(TextAsset));
        SkillData = JsonConvert.DeserializeObject<Dictionary<string, List<Skill>>>(Skilljson.text);
    }
    public void CharacterStatSet(BattleCharacter target)
    {
        target.Attack= CharacterStatData["characterstat"][target.Index].Attack;
        target.MHeath = CharacterStatData["characterstat"][target.Index].MHeath;
        target.ASpeed = CharacterStatData["characterstat"][target.Index].ASpeed;
        target.Attacktype = CharacterStatData["characterstat"][target.Index].Attacktype;
        target.Defence = CharacterStatData["characterstat"][target.Index].Defence;
    }

    public List<Skill> SkillSet()
    {
        return SkillData["Skill"];
    }
}
