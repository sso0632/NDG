using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataSet : MonoBehaviour
{
    Dictionary<string, List<BattleCharacter>> CharacterStatData;

    private void Awake()
    {
        CharacterStatLoad();
    }

    void DebugList()
    {
        for(int i=0; i < CharacterStatData["characterstat"].Count; ++i)
        {
            Debug.Log(CharacterStatData["characterstat"][i].Attack);
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
