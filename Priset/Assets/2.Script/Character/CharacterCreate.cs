using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : MonoBehaviour {

    Transform Parent;

    Vector3 pos = new Vector3(0, -1, 0);
    private void Awake()
    {
        Parent = GameObject.Find("Friend").transform;
    }

    public void FriendCreate(int CreateIndex)          //캐릭터 생성
    {
        GameObject targetObject;
        Acter targetActer;
        BattleCharacter targetCharacter;

        string CharacterPath = string.Format("PrePab/FriendPrepab/Friend{0}", CreateIndex);
        targetCharacter = new BattleCharacter(CreateIndex);

        targetObject = (GameObject)Resources.Load(CharacterPath);
        targetActer = targetObject.GetComponent<FriendActor>();
        targetActer.RegistCharacter(targetCharacter);
        FieldCraete(targetObject);

    }

    void FieldCraete(GameObject Object)
    {
        Instantiate(Object, pos, Quaternion.identity, Parent);
    }
}
