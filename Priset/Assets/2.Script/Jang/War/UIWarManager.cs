using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWarManager : MonoBehaviour
{
    public static UIWarManager instance;
    public UIPartyButton FriendlyRoom;


    public GameObject HpBarPrefab;
    public GameObject DamageTextPrefab;
    public Transform HpBarCollecter;
    public Transform DamageCollecter;
    
    List<UIHpBar> barList;
    List<UIDamageText> damageTextList;
    

    public delegate void UIBarHealthCall(Acter actor);
    public static event UIBarHealthCall BarHealthCall;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);      
    }
    private void Start()
    {
        BarPooling();
        PartyInit();
        DamagePool();
    }
    void PartyInit()
    {
        int count = GameManager.instance.PM.GetPlayerParty.PartyCount();

        PlayerParty tempParty = GameManager.instance.PM.GetPlayerParty;
        for(int i =0; i< count; ++i)
        {
            if(tempParty.GetActors()[i] != null)
            {
                UIHpBar hpBar = PopHpBar();
                hpBar.gameObject.SetActive(true);
                hpBar.SetBattleCharacter(tempParty.GetActors()[i]);
            }
        }
    }
  
    void BarPooling()
    {
        barList = new List<UIHpBar>();

        for (int i =0; i < 10; ++i)
        {
            GameObject temp = Instantiate(HpBarPrefab);
            UIHpBar tempBar = temp.GetComponent<UIHpBar>();
            temp.transform.SetParent(HpBarCollecter);
            tempBar.EventAdd();
            temp.SetActive(false);
            barList.Add(tempBar);
        }
    }
    void DamagePool()
    {
        damageTextList = new List<UIDamageText>();
        for (int i = 0; i < 10; ++i)
        {
            GameObject temp = Instantiate(DamageTextPrefab);
            UIDamageText tempDamage = temp.GetComponent<UIDamageText>();
            temp.transform.SetParent(DamageCollecter);
            temp.SetActive(false);
            damageTextList.Add(tempDamage);
        }
    }
    
    public UIHpBar PopHpBar()
    { 
        if (barList.Count <= 0)
        {
            GameObject temp = Instantiate(HpBarPrefab);
            UIHpBar tempBar = temp.GetComponent<UIHpBar>();
            temp.transform.SetParent(HpBarCollecter);
            tempBar.EventAdd();
            temp.SetActive(false);
            return tempBar;
        }
        else if(barList.Count > 0)
        {
            UIHpBar tempBar = barList[0];
            barList.Remove(tempBar);
            return tempBar;
        }
        return null;
    }
    public void ShowDamageText(Vector3 showPoint, float damage)
    {
        if (damageTextList.Count > 0)
        { 
            UIDamageText tempText = damageTextList[0];
            tempText.SetDamageText(showPoint, damage.ToString());
            tempText.OpenTextUI();
            damageTextList.Remove(tempText);
        }
        else if (damageTextList.Count <= 0)
        {
            GameObject tempObj = Instantiate(DamageTextPrefab);
            UIDamageText tempText = tempObj.GetComponent<UIDamageText>();
            tempObj.transform.SetParent(DamageCollecter);
            tempText.SetDamageText(showPoint, damage.ToString());
            tempText.OpenTextUI();
        }
    }
    public void PushDamageText(UIDamageText damageText)
    {
        damageText.gameObject.SetActive(false);
        damageTextList.Add(damageText);
    }

    public void PushHpBar(UIHpBar hpBar)
    {
        hpBar.gameObject.SetActive(false);
        hpBar.EventRemove();
        barList.Add(hpBar);
    }
    public void HpBarViewOn(Acter _actor)
    {
        UIHpBar tempUIBar = PopHpBar();
        tempUIBar.SetBattleCharacter(_actor);
    }
    public static void HealthCallEvent(Acter _acter)
    {
        BarHealthCall(_acter);
    }
}
