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


    AsyncOperation loadAsync;
    bool isLoad;
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

        DontDestroyOnLoad(gameObject);

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
        StartCoroutine(LoadingSystem((int)NowScene));   
    }
    IEnumerator LoadingSystem(int mapIndex)
    {
        UIManager.instance.LoadUI.SetActive(true);
        if (!isLoad)
        {
            isLoad = true;

            loadAsync = SceneManager.LoadSceneAsync(mapIndex);
            loadAsync.allowSceneActivation = false;

            float timer = 0;
            while (!loadAsync.isDone)
            {
                while (timer <= 1)
                {
                    timer += Time.deltaTime;
                    UIManager.instance.SliderImage.fillAmount = timer;
                    yield return null;
                    if (timer >= 0.9f)
                    {
                        loadAsync.allowSceneActivation = true;
                        break;
                    }
                }
                yield return null;
            }
        }

        PM.GoWarScene();
        CreateCharacter.PartyCreate();

        yield return null;
    }
}
