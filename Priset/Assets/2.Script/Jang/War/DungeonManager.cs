using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DungeonManager : MonoBehaviour
{
    public static DungeonManager instance;
    public GameObject[] MonsterPrefabs;

    List<GameObject>[] monsterList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        MakeMonsterList();
    }
    void MakeMonsterList()
    {
        int monsterMax = MonsterPrefabs.Length;
        monsterList = new List<GameObject>[monsterMax];

        for(int i =0; i< monsterMax; ++i)
        {
            monsterList[i] = new List<GameObject>();
            for(int j = 0; j < 5; ++i)
            {
                GameObject obj = Instantiate(MonsterPrefabs[i]);
                obj.name = MonsterPrefabs[i].name;
                obj.gameObject.SetActive(false);
                obj.transform.SetParent(transform);

                monsterList[i].Add(obj);
            }
        }
    }




    



}
