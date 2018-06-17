using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParty : MonoBehaviour
{ 
    List<MonsterActor> monsterList;
    
    public void MakeParty()
    {
        monsterList = new List<MonsterActor>();

        for (int i = 0; i < 4; ++i)
        {
            int index = Random.Range(0, DungeonManager.instance.GetMonsterTypeMax);
            GameObject obj = DungeonManager.instance.PopMonster((MONSTER_TYPE)index);
            MonsterActor monster = obj.GetComponentInChildren<MonsterActor>();
            obj.transform.SetParent(transform);
            monster.SetPartyCommader = this;
            monster.MonsterIndex = index;
            monsterList.Add(monster);
        }

        monsterList[0].transform.position =
            new Vector3(transform.position.x - 0.25f, 1, transform.position.z + 0.25f);

        monsterList[1].transform.position =
            new Vector3(transform.position.x + 0.25f, 1, transform.position.z + 0.25f);

        monsterList[2].transform.position =
           new Vector3(transform.position.x - 0.25f, 1, transform.position.z - 0.25f);

        monsterList[3].transform.position =
            new Vector3(transform.position.x + 0.25f, 1, transform.position.z - 0.25f);
    }
    public void PartyDestory()
    {
        monsterList.Clear();
    }

    public void PartyInMonsterCall()
    {

    }


}
