using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sang;
public class GameManager : MonoBehaviour {
    
    public static GameManager instance;
    public DataSet Data;
    public CharacterCreate CreateCharacter;
    public PlayerManager PM;    
    public SceneNum NowScene;
    public SkillManager SkillSpace;                    //스킬 공간
    public bool FirstStart=true;                       

    private void Awake()
    {
        //게임의 데이터 불러오고

        if(FirstStart==true)
        { 
            //맨처음 시작 했을 때
            FirstStart = false;
        }

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        init();
    }
    void init()
    {
        DataSet();
        SkillSpace.Init();
        NowScene = SceneNum.Home;
    }
    void DataSet()
    {
        Data = this.GetComponent<DataSet>();
        Data.Init();
    }

    public void GoWarScene()
    {
        NowScene = SceneNum.War;
        CreateCharacter.PartyCreate();
        SceneManager.LoadScene(1);
    }
}
