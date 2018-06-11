using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : MonoBehaviour {

    Transform Parent;
    List<BattleCharacter> CreateAbleFriend;

    int AbleFriendCount=10;

    private void Awake()
    {
        Parent = GameObject.Find("Friend").transform;
        CreateAbleFriend = new List<BattleCharacter>();
    }

    public BattleCharacter GetCreateAbleFriend(int ableindex)
    {
        return CreateAbleFriend[ableindex];
    }

    public BattleCharacter FriendCreate(int CreateIndex)          //캐릭터 생성
    {
        BattleCharacter targetCharacter;
        targetCharacter = new BattleCharacter(CreateIndex);

        return targetCharacter;
    }

    void AbleFriendCreate()             //생성 가능한 친구를 생성
    {
        int Randomindex;
        for(int i=0; i< AbleFriendCount; ++i)
        {
            Randomindex=Random.Range(1, 19);
            CreateAbleFriend.Add(FriendCreate(Randomindex));
        }
    }

    public void Craete(GameObject Actor, Vector3 Pos, Transform parent)
    {
        Instantiate(Actor, Pos, Quaternion.identity, parent);
    }

    public void FieldCraete(BattleCharacter CCharacter)
    {
        GameObject targetObject;
        Acter targetActer;

        Vector3 pos = new Vector3(0, -1, 0);

        string CharacterPath = string.Format("PrePab/FriendPrepab/Friend{0}", CCharacter.Index);

        targetObject = (GameObject)Resources.Load(CharacterPath);

        targetActer = targetObject.GetComponent<FriendActor>();
        targetActer.RegistCharacter(CCharacter);


        Craete(targetObject, pos, Parent);
        GameManager.instance.PM.Employ(CCharacter);
    }
}
