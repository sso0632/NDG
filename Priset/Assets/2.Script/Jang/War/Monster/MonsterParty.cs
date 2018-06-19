using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParty : MonoBehaviour
{
    public static int PartyCount;
    public delegate void PartyPurposeChange(Acter actor);
    public event PartyPurposeChange PurposeEvent;

    List<MonsterActor> monsterList;

    private void Awake()
    {
        PartyCount = 0;
    }
    public void MakeParty()
    {
        ++PartyCount;
        monsterList = new List<MonsterActor>();

        GameObject newPartyObj = new GameObject(PartyCount.ToString());
        newPartyObj.transform.SetParent(DungeonManager.instance.MonsterPartyManager);
        Monster haveData;
        for (int i = 0; i < 4; ++i)
        {
            int index = Random.Range(0, DungeonManager.instance.GetMonsterTypeMax);
            GameObject obj = DungeonManager.instance.PopMonster((MONSTER_TYPE)index);
            MonsterActor monster = obj.GetComponentInChildren<MonsterActor>();
            haveData = new Monster(index);
            monster.RegistCharacter(haveData);
            obj.transform.SetParent(newPartyObj.transform);
            monster.SetPartyCommader = this;
            monster.TargetEventAdd();
            monster.MonsterIndex = index;
            monsterList.Add(monster);
        }

        monsterList[0].transform.parent.position =
            new Vector3(transform.position.x - 0.25f, 0, transform.position.z + 0.25f);

        monsterList[1].transform.parent.position =
            new Vector3(transform.position.x + 0.25f, 0, transform.position.z + 0.25f);

        monsterList[2].transform.parent.position =
           new Vector3(transform.position.x - 0.25f, 0, transform.position.z - 0.25f);

        monsterList[3].transform.parent.position =
            new Vector3(transform.position.x + 0.25f, 0, transform.position.z - 0.25f);
    }



    public void PartyDestory()
    {
        monsterList.Clear();
    }
    public void PartyTargetSet(Acter _target)
    {
        PurposeEvent(_target);
    }
}
