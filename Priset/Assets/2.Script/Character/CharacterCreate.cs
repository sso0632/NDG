using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;
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
        Friendly targetCharacter;
        targetCharacter = new Friendly(CreateIndex);

        return targetCharacter;
    }

    public GameObject Craete(Vector3 Pos, Transform parent, BattleCharacter CCharacter)
    {
        GameObject targetObject;
        Acter targetActer;

        string CharacterPath = string.Format("PrePab/FriendPrepab/Friend{0}", CCharacter.Index);

        targetObject = (GameObject)Resources.Load(CharacterPath);

        targetActer = targetObject.transform.GetChild(0).GetComponent<FriendActor>();
        targetActer.RegistCharacter(CCharacter);

        return Instantiate(targetObject, Pos, Quaternion.identity, parent);
    }
    public GameObject Craete(Vector3 Pos, Transform parent, Quaternion Direct, BattleCharacter CCharacter)
    {
        GameObject targetObject;
        Acter targetActer;

        string CharacterPath = string.Format("PrePab/FriendPrepab/Friend{0}", CCharacter.Index);

        targetObject = (GameObject)Resources.Load(CharacterPath);

        targetActer = targetObject.transform.GetChild(0).GetComponent<FriendActor>();
        targetActer.RegistCharacter(CCharacter);

        return Instantiate(targetObject, Pos, Direct, parent);
    }

    public void FieldCraete(BattleCharacter CCharacter)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Craete(pos, FieldParent, CCharacter);
        GameManager.instance.PM.Employ(CCharacter);
    }

    public void PartyCreate()
    {
        PlayerParty temp = GameManager.instance.PM.GetPlayerParty;
        Transform  Chlid;
        FriendActor Actor;

        for (int i = 0; i < temp.PartyCount(); ++i)
        {
            if(temp.GetPartyMember(i) != null)
            {
                Chlid = Craete(temp.GetPos(i), GameManager.instance.PM.GetPartyParent().transform, FriendCreate(temp.GetPartyMember(i).Index)).transform.GetChild(0);
                Actor = Chlid.GetComponent<FriendActor>();
                temp.SetActor(i, Actor);
                Actor.SetParty(GameManager.instance.PM.GetPlayerParty);
                Actor.RegistCharacter(temp.GetPartyMember(i));
                Actor.SetFormationPos((PartyPos)i);
                Chlid.localPosition =new Vector3(0, 0,-0.3f);
                Chlid.localRotation = Quaternion.Euler(90f, 0, 0);
            }
        }
    }
}
