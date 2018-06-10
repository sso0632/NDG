using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
public class DataSet : MonoBehaviour
{
    Dictionary<string, List<BattleCharacter>> CharacterStatData;

    private void Awake()
    {
        CharacterStatLoad();
        CharacterSpriteLoad();
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
        string tempSpriteIndex = null;
        UIManager.instance.CharacterImage = new Sprite[count];
        for(int i =0; i<count; ++i)
        {
            tempSpriteIndex = i.ToString();
            UIManager.instance.CharacterImage[i] = (Sprite)Resources.Load("CharacterImage/" + tempSpriteIndex, typeof(Sprite));
        }
    }



    void CharacterStatLoad()
    {
        TextAsset Characterstatjson = (TextAsset)Resources.Load("Json/CharacterStat", typeof(TextAsset));
        CharacterStatData = JsonConvert.DeserializeObject<Dictionary<string, List<BattleCharacter>>>(Characterstatjson.text);
    }

    public void CharacterStatSet(BattleCharacter target)
    {
        target.Attack= CharacterStatData["characterstat"][target.Index-1].Attack;
        target.MHeath = CharacterStatData["characterstat"][target.Index - 1].MHeath;
        target.ASpeed = CharacterStatData["characterstat"][target.Index - 1].ASpeed;
        target.Attacktype = CharacterStatData["characterstat"][target.Index - 1].Attacktype;
    }
}
