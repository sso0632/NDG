using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class PlayerManager : MonoBehaviour {

    public PriestActor[] havePriestCharacter;           //가지고 있는 프리스트
    public List<BattleCharacter> EmployCharacter;      //섭외한 배틀 캐릭터
    PriestActor NowPriest;                              //현재 프리스트
    PlayerParty Party;
    GameObject PartyParent;                         //파티 부모
    int Gold;                                   //플레이어 돈
    int Score;                                  //점수


    public PlayerParty GetPlayerParty
    {
        get { return Party; }
    }

    private void Awake()
    {
        EmployCharacter = new List<BattleCharacter>();
        PartyParent = transform.GetChild(0).gameObject;
        Party = new PlayerParty();
        Party.PartySet();
        ChagePriest(0);
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        CharacterUnlockNeed();
    }

    public PriestActor GetNowPriest()
    {
        return NowPriest;
    }


    public void ChagePriest(int index)
    {
        //1. 현재 프리스트 액터 초기화후 
        if (NowPriest != null)
        {
            if(NowPriest!= havePriestCharacter[index])
            {
                NowPriest.transform.parent.gameObject.SetActive(false);
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
        actor.transform.parent.gameObject.SetActive(true);

        if (NowPriest != null)
            actor.Pos = NowPriest.Pos;
        
        NowPriest = actor;
    }

    public void Employ(BattleCharacter target)          //고용한 용병 삽입
    {
        EmployCharacter.Add(target);
    }

    public void SkillSet(Skill targetSkill)
    {
        NowPriest.havePriest.SetSkill(targetSkill);
    }
    public Skill[] NowPriestSkillGet()
    {
        return NowPriest.havePriest.GetSkill();
    }
   
    void CharacterUnlockNeed()                          //캐릭터 언락
    {
        if (GameManager.instance.FirstStart==false)
        {
            UIManager.instance.PriestPanel.CharacterUnlock(0);
        }
        UIManager.instance.PriestPanel.CharacterUnlock(1);
    }

    public GameObject GetPartyParent()
    {
        return PartyParent;
    }

    public void GoWarScene()
    {
        Party.LeaderSet(NowPriest.havePriest, NowPriest.transform);
    }
    public void GoWarscene()
    {
        NowPriest.Init();
    }
    public void HuntCountUp()
    {
        Score++;
    }
    public int SCORE
    {
        get{ return Score;  }
    }
    void ScoreReset()
    {
        Score = 0;
    }
}

public class PlayerParty
{
    BattleCharacter[] characterParty;       //파티에 속에있는 캐릭터 데이터
    Acter[] FriendActer;                    //파티에 속에있는 캐릭터 액터
    public Vector3[] Pos= {new Vector3(-1, 0, 1), new Vector3(1,0,1), new Vector3(-1,0,-1), new Vector3(1, 0,-1)};      //포메이션 값
    Transform LeaderTransform;              //리더의 transform
    Priest Leader;                          //사제의 데이터 정도
    Quaternion Direct = new Quaternion(90f, 0, 0, 0);       //warscene 상의 각도

    public Acter[] GetActors()
    {
        return FriendActer;
    }
    public void SetActor(int index, Acter _actor)
    {
        FriendActer[index] = _actor;
    }


    public void LeaderSet(Priest _Leader, Transform _LeaderTransform)
    {
        Leader = _Leader;
        LeaderTransform = _LeaderTransform;
    }
    public float LeaderSpeed()
    {
        return Leader.MoveSpeed;
    }
    public BattleCharacter GetPartyMember(int index)
    {
        return characterParty[index];
    }
    public int PartyCount()
    {
        return characterParty.Length;
    }
    public Vector3 GetPos(int index)
    {
      return Pos[index] + LeaderTransform.position;
    }
    public Quaternion GetDirect()
    {
        return Direct;
    }
    public void PartySet()
    {
        characterParty = new BattleCharacter[4];
        FriendActer = new Acter[4];
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
