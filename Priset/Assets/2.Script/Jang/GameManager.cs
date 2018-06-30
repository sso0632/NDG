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
    public SkillManager SkillSpace;                    //모든 스킬 저장
    public bool FirstStart=true;

    AsyncOperation loadAsync;
    bool isLoad;
    private void Awake()
    {
        //게임의 데이터 불러오고
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

        if (FirstStart == true)
        {
            //맨처음 시작 했을 때
            PM.AddMoney(100);
            FirstStart = false;
        }
    }
    void DataSet()
    {
        Data = this.GetComponent<DataSet>();
        Data.Init();
    }

    public void GoWarScene()
    {
        NowScene = SceneNum.War;
        PM.PriestInit();
        StartCoroutine(WarSceneLoadingSystem((int)NowScene));
    }
    public void GoHomeScene()
    {
        NowScene = SceneNum.Home;

        StartCoroutine(HomeSceneLoadingSystem((int)NowScene));
    }
    IEnumerator HomeSceneLoadingSystem(int mapIndex)
    {
       // UIManager.instance.LoadUI.SetActive(true);
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
                   // UIManager.instance.SliderImage.fillAmount = timer;
                    yield return null;
                    if (timer >= 0.9f)
                    {
                        loadAsync.allowSceneActivation = true;
                        break;
                    }
                }

                yield return null;
            }
            isLoad = false;
            PM.GetNowPriest().PriesHomeSceneStart();
        }
        yield return null;
    }
    IEnumerator WarSceneLoadingSystem(int mapIndex)
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
            isLoad = false;
        }

        PM.GoWarScene();
        CreateCharacter.PartyCreate();
        PM.PriestFirstSkillSet();
        UIWarManager.instance.PartyInit();

        yield return null;
    }
}
