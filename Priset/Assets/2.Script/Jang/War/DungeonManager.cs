using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum MONSTER_TYPE
{
    Orc,
    OrcShamman,
    OrcWarrior,
}
public class DungeonManager : MonoBehaviour
{
    public static DungeonManager instance;
    public static int CurrentMonsterPartyCount;
    public Transform MonsterDropPoint;
    public Transform MonsterPartyManager;
    public GameObject[] MonsterPrefabs;

    MonsterDropPoint[] monsterDropList;    
    List<GameObject>[] monsterList;

    public int GetMonsterTypeMax
    {
        get { return MonsterPrefabs.Length; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        MakeMonsterList();
        GetDropPoint();
    }
    private void Start()
    {
        CurrentMonsterPartyCount = 0;
        StartCoroutine(MonsterDropSystem());
    }

    void MakeMonsterList()              //생성
    {        
        int monsterMax = MonsterPrefabs.Length;
        monsterList = new List<GameObject>[monsterMax];

        for (int i =0; i < monsterMax; ++i)
        {
            monsterList[i] = new List<GameObject>();
            for(int j = 0; j < 5; ++j)
            {
                GameObject obj = Instantiate(MonsterPrefabs[i]);

                obj.name = MonsterPrefabs[i].name;
                obj.gameObject.SetActive(false);
                obj.transform.SetParent(transform);
                monsterList[i].Add(obj);
            }
        }
    }
    public GameObject PopMonster(MONSTER_TYPE type)
    {
        int index = (int)type;
        
        if(monsterList[index].Count > 0)
        {
            GameObject obj = monsterList[index][0];
            obj.SetActive(true);
            monsterList[index].Remove(obj);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(MonsterPrefabs[index]);
            obj.name = MonsterPrefabs[index].name;
            obj.SetActive(true);
            return obj;
        }
    }
    public void PushMonster(GameObject obj)
    {

    }
    void GetDropPoint()
    {
        monsterDropList = new MonsterDropPoint[MonsterDropPoint.childCount];

        for(int i =0; i<monsterDropList.Length; ++i)
        {
            monsterDropList[i] = MonsterDropPoint.GetChild(i).GetComponent<MonsterDropPoint>();
        }
    }

    //파티 생성 후 DropPoint에 
    IEnumerator MonsterDropSystem()
    {
        while(gameObject.activeSelf)
        {
            if (CurrentMonsterPartyCount <= monsterDropList.Length - 30)
            {
                yield return StartCoroutine(MakeMonster());
            }
            else if(CurrentMonsterPartyCount > monsterDropList.Length - 30)
            {
                yield return new WaitForEndOfFrame();
            }

            yield return null;
        }
    }

    IEnumerator MakeMonster()
    {
        ++CurrentMonsterPartyCount;

        int rand = Random.Range(0, monsterDropList.Length);
        while(monsterDropList[rand].GetDropExist)
        {
            //Debug.Log("___Rand"+ rand +"______" + monsterDropList[rand].GetDropExist);
            rand = Random.Range(0, monsterDropList.Length);
            yield return null;
        }
        monsterDropList[rand].MonsterPartyMake();
    }
}
