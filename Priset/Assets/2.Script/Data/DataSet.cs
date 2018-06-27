using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
public class DataSet : MonoBehaviour
{
    Dictionary<string, List<BattleCharacter>> CharacterStatData;
    Dictionary<string, List<BattleCharacter>> MonsterStatData;
    Dictionary<string, List<Skill>> SkillData;

    public static Sprite[] CharacterImageResources;
    public static Sprite[] SkillImageResources;

    public void Init()
    {
        CharacterStatLoad();
        CharacterSpriteLoad();
        SkillDataLoad();
        SkillSpriteLoad();
    }

    void DebugList()
    {
        for(int i=0; i < CharacterStatData["characterstat"].Count; ++i)
        {
            Debug.Log(CharacterStatData["characterstat"][i].Attack);
        }
    }
    void SkillSpriteLoad()
    {
        int count = Resources.LoadAll("SkillImage", typeof(Sprite)).Length;

        SkillImageResources = new Sprite[count];

        for(int spriteNumber = 0; spriteNumber < SkillImageResources.Length; ++spriteNumber)
        {
            SkillImageResources[spriteNumber] = (Sprite)Resources.Load("SkillImage/" + spriteNumber.ToString(), typeof(Sprite));
        }
    }
    void CharacterSpriteLoad()
    {
        int count = Resources.LoadAll("CharacterImage", typeof(Sprite)).Length;

        CharacterImageResources = new Sprite[count];
        for (int spriteNumber = 0; spriteNumber < count; ++spriteNumber)
        {
            CharacterImageResources[spriteNumber] = (Sprite)Resources.Load("CharacterImage/" + spriteNumber.ToString(), typeof(Sprite));
        }
    }
    void CharacterStatLoad()
    {
        TextAsset Characterstatjson = (TextAsset)Resources.Load("Json/CharacterStat", typeof(TextAsset));
        CharacterStatData = JsonConvert.DeserializeObject<Dictionary<string, List<BattleCharacter>>>(Characterstatjson.text);

        Characterstatjson = (TextAsset)Resources.Load("Json/MonsterStat", typeof(TextAsset));
        MonsterStatData = JsonConvert.DeserializeObject<Dictionary<string, List<BattleCharacter>>>(Characterstatjson.text);
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
    public void MonsterStatSet(BattleCharacter target)
    {
        target.Attack = MonsterStatData["Monsterstat"][target.Index].Attack;
        target.MHeath = MonsterStatData["Monsterstat"][target.Index].MHeath;
        target.ASpeed = MonsterStatData["Monsterstat"][target.Index].ASpeed;
        target.Attacktype = MonsterStatData["Monsterstat"][target.Index].Attacktype;
        target.Defence = MonsterStatData["Monsterstat"][target.Index].Defence;
    }

    public List<Skill> SkillSet()
    {
        return SkillData["Skill"];
    }
}
