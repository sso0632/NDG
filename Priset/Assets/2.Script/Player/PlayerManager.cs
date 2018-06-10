using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class PlayerManager : MonoBehaviour {
    public PriestActor[] havePriestCharacter;           //가지고 있는 프리스트

    List<BattleCharacter> EmployCharacter;      //섭외한 배틀 캐릭터
    PlayerParty Party;
    PriestActor NowPriest;                      //현재 프리스트;  

    int Gold;                                   //플레이어 돈

    private void Awake()
    {
        EmployCharacter = new List<BattleCharacter>();
        Party = new PlayerParty();
        Party.PartySet();
        ChagePriest(0);
    }
    public void ChagePriest(int index)
    {
        //1. 현재 프리스트 액터 초기화후 
        if(NowPriest!=null)
        {

            NowPriest.gameObject.SetActive(false);
            //현재 프리스트의 값을 초기화
            SetPriestActor(havePriestCharacter[index]);
        }
        else
        {
            SetPriestActor(havePriestCharacter[index]);
        }

    }
    void SetPriestActor(PriestActor actor)
    {
        actor.gameObject.SetActive(true);

        if (NowPriest != null)
            actor.Pos = NowPriest.Pos;

        NowPriest = actor;
    }
}

class PlayerParty
{
    BattleCharacter[] characterParty;

    public void PartySet()
    {
        characterParty = new BattleCharacter[4];
    }

    public void SetUp(BattleCharacter character)
    {
        characterParty[(int)PartyPos.UP]= character;
    }
    public void SetRight(BattleCharacter character)
    {
        characterParty[(int)PartyPos.RIGHT] = character;
    }
    public void SetDown(BattleCharacter character)
    {
        characterParty[(int)PartyPos.DOWN] = character;
    }
    public void SetLeft(BattleCharacter character)
    {
        characterParty[(int)PartyPos.LEFT] = character;
    }
}
