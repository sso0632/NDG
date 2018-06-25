using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIWarManager : MonoBehaviour
{
    public static UIWarManager instance;
    public UIPartyButton FriendlyRoom;
    public Text Scoreview;
    public GameObject HpBarPrefab;
    public GameObject DamageTextPrefab;
    public Transform HpBarCollecter;
    public Transform DamageCollecter;
    
    List<UIHpBar> barList;
    List<UIDamageText> damageTextList;

    public delegate void ChangeBarAmount(BattleCharacter _actor);
    public static event ChangeBarAmount ChangeBarAmountEvent;

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

        for (int i =0; i< count; ++i)
        {
            if(tempParty.GetActors()[i] != null)
            {
                HpBarReceiver(tempParty.GetActors()[i]);
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
        hpBar.RemoveEvent();
        barList.Add(hpBar);
    }

    public void HpBarReceiver(Acter _actor)
    {
        if (barList.Count <= 0)
        {
            GameObject temp = Instantiate(HpBarPrefab);
            UIHpBar tempBar = temp.GetComponent<UIHpBar>();
            temp.transform.SetParent(HpBarCollecter);
            temp.SetActive(true);
            tempBar.SetBattleCharacter(_actor);
            tempBar.AddEvent();
            return;
        }
        else if (barList.Count > 0)
        {
            UIHpBar tempBar = barList[0];
            tempBar.gameObject.SetActive(true);
            tempBar.SetBattleCharacter(_actor);
            barList.Remove(tempBar);
            tempBar.AddEvent();
            return;
        }
    }

    public static void SetAmountChange(BattleCharacter character)
    {
        if(ChangeBarAmountEvent!=null)
            ChangeBarAmountEvent(character);
    }
    public void SetScore(int value)
    {
        Scoreview.text = value.ToString();
    }
}
