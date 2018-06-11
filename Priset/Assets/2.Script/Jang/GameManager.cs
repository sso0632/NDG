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
      
    private void Awake()
    {
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
