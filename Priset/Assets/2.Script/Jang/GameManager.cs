using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;
    public DataSet Data;
    public CharacterCreate CreateCharacter;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        ComponentSet();
    }

    void ComponentSet()
    {
        Data = this.GetComponent<DataSet>();
    }
}
