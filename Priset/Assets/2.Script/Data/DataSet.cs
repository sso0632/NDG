﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
public class DataSet : MonoBehaviour
{
    Dictionary<string, List<BattleCharacter>> CharacterStatData;
    Dictionary<string, List<BattleCharacter>> MonsterStatData;
    Dictionary<string, List<Priest>> PriestStatData;
    Dictionary<string, List<Skill>> SkillData;

    public static Sprite[] CharacterImageResources;
    public static Sprite[] SkillImageResources;


    public static GameObject[] SkillParicle;
    public void Init()
    {
        PriestStatLoad();
        CharacterStatLoad();
        CharacterSpriteLoad();
        SkillDataLoad();
        SkillSpriteLoad();
        SkillPartcleLoad();
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
    void SkillPartcleLoad()
    {
        int count = Resources.LoadAll("PrePab/SkillPartcle", typeof(GameObject)).Length;
        SkillParicle = new GameObject[count];
        for (int PartcleNumber = 0; PartcleNumber < count; ++PartcleNumber)
        {
            SkillParicle[PartcleNumber] = (GameObject)Resources.Load("PrePab/SkillPartcle/" + string.Format("s{0}", PartcleNumber));
        }
    }

    void CharacterStatLoad()
    {
        TextAsset Characterstatjson = (TextAsset)Resources.Load("Json/CharacterStat", typeof(TextAsset));
        CharacterStatData = JsonConvert.DeserializeObject<Dictionary<string, List<BattleCharacter>>>(Characterstatjson.text);

        Characterstatjson = (TextAsset)Resources.Load("Json/MonsterStat", typeof(TextAsset));
        MonsterStatData = JsonConvert.DeserializeObject<Dictionary<string, List<BattleCharacter>>>(Characterstatjson.text);
    }
    void PriestStatLoad()
    {
        TextAsset Prieststatjson = (TextAsset)Resources.Load("Json/PriestStat", typeof(TextAsset));
        PriestStatData = JsonConvert.DeserializeObject<Dictionary<string, List<Priest>>>(Prieststatjson.text);


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

    public void PriestStatSet(Priest target, int indexNum)
    {
        target.MAXHEATH = PriestStatData["prieststat"][indexNum].MAXHEATH;
        target.HOLYPOWER = PriestStatData["prieststat"][indexNum].HOLYPOWER;
        target.MOVESPEED = PriestStatData["prieststat"][indexNum].MOVESPEED;
        target.INDEX = PriestStatData["prieststat"][indexNum].INDEX;
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


