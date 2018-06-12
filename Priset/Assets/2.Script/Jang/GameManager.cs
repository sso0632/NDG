using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;
public class GameManager : MonoBehaviour {
    
    public static GameManager instance;
    public DataSet Data;
    public CharacterCreate CreateCharacter;
    public PlayerManager PM;    
    public Scene NowScene;

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

        ComponentSet();
        init();
    }
    void init()
    {
        NowScene = Scene.Home;
    }
    void ComponentSet()
    {
        Data = this.GetComponent<DataSet>();
    }
}
