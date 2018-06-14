using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class PlayerManager : MonoBehaviour {
    public PriestActor[] havePriestCharacter;           //가지고 있는 프리스트
    public SkillManager SkillSpace;                    //스킬 공간

    public List<BattleCharacter> EmployCharacter;      //섭외한 배틀 캐릭터
    PriestActor NowPriest;                              //현재 프리스트
    PlayerParty Party;

    int Gold;                                   //플레이어 돈
    
    public PlayerParty GetPlayerParty
    {
        get { return Party; }
    }


    private void Awake()
    {
        EmployCharacter = new List<BattleCharacter>();

        Party = new PlayerParty();
        Party.PartySet();
        ChagePriest(0);
    }
    private void Update()
    {
        CharacterUnlockNeed();
    }
    public void ChagePriest(int index)
    {
        //1. 현재 프리스트 액터 초기화후 
        if (NowPriest != null)
        {
            if(NowPriest!= havePriestCharacter[index])
            { 
                NowPriest.gameObject.SetActive(false);
                //현재 프리스트의 값을 초기화
                SetPriestActor(havePriestCharacter[index]);
            }
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

    public void Employ(BattleCharacter target)          //고용한 용병 삽입
    {
        EmployCharacter.Add(target);
    }

    void CharacterUnlockNeed()                          //캐릭터 언락
    {
        if (GameManager.instance.FirstStart==false)
        {
            UIManager.instance.PriestPanel.CharacterUnlock(0);
        }
    }
}

public class PlayerParty
{
    BattleCharacter[] characterParty;

    public void PartySet()
    {
        characterParty = new BattleCharacter[4];
    }

    public void SetLeftUp(BattleCharacter character)
    {
        characterParty[(int)PartyPos.LEFT_UP]= character;
    }
    public void SetRightUp(BattleCharacter character)
    {
        characterParty[(int)PartyPos.RIGHT_UP] = character;
    }
    public void SetLeftDown(BattleCharacter character)
    {
        characterParty[(int)PartyPos.LEFT_DOWN] = character;
    }
    public void SetRightDown(BattleCharacter character)
    {
        characterParty[(int)PartyPos.RIGHT_DOWN] = character;
    }
}
