using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : MonoBehaviour {

    Transform FieldParent;
    List<BattleCharacter> CreateAbleFriend;

    int AbleFriendCount=10;

    private void Awake()
    {
        FieldParent = GameObject.Find("Friend").transform;
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

    public void Craete(Vector3 Pos, Transform parent, BattleCharacter CCharacter)
    {
        GameObject targetObject;
        Acter targetActer;

        string CharacterPath = string.Format("PrePab/FriendPrepab/Friend{0}", CCharacter.Index);

        targetObject = (GameObject)Resources.Load(CharacterPath);

        targetActer = targetObject.GetComponent<FriendActor>();
        targetActer.RegistCharacter(CCharacter);

        Instantiate(targetActer, Pos, Quaternion.identity, parent);
        GameManager.instance.PM.Employ(CCharacter);
    }
    public void Craete(Vector3 Pos, Transform parent, Quaternion Direct, BattleCharacter CCharacter)
    {
        GameObject targetObject;
        Acter targetActer;

        string CharacterPath = string.Format("PrePab/FriendPrepab/Friend{0}", CCharacter.Index);

        targetObject = (GameObject)Resources.Load(CharacterPath);

        targetActer = targetObject.GetComponent<FriendActor>();
        targetActer.RegistCharacter(CCharacter);

        Instantiate(targetActer, Pos, Direct, parent);
        GameManager.instance.PM.Employ(CCharacter);
    }

    public void FieldCraete(BattleCharacter CCharacter)
    {
        Vector3 pos = new Vector3(0, -1, 0);
        Craete(pos, FieldParent, CCharacter);
        GameManager.instance.PM.Employ(CCharacter);
    }

    public void PartyCreate()
    {
        PlayerParty temp = GameManager.instance.PM.GetPlayerParty;

        for (int i = 0; i < temp.PartyCount(); ++i)
        {
            if(temp.GetPartyMember(i) != null)
                Craete(temp.GetPos(i),GameManager.instance.PM.GetPartyParent().transform, temp.GetDirect(), FriendCreate(temp.GetPartyMember(i).Index));
        }
    }
}
