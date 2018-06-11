using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    bool isTime = true ;
    bool isResetTime = false;

    int m_friendlyResetminute;
    float m_friendlyResetSecond;


    public bool isResetFriendly
    {
        get { return isResetTime; }
        set { isResetTime = value; }
    }
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        RestartFriendlyTimer();
    }
    public void RestartFriendlyTimer()
    {
        isResetTime = false;
        isTime = true;
        StartCoroutine(TimerSystem());
    }
  
    IEnumerator TimerSystem()
    {
        m_friendlyResetminute = 0;
        m_friendlyResetSecond = 10.0f;

        while (isTime)
        {
            m_friendlyResetSecond -= Time.deltaTime;
            UIManager.instance.FriendlyResetTextSet(m_friendlyResetminute, m_friendlyResetSecond);

            if (m_friendlyResetSecond <= 0.0f)
            {
                --m_friendlyResetminute;
                m_friendlyResetSecond = 60.0f;
            }
            if (m_friendlyResetminute < 0)
                isTime = false;


            yield return null;
        }

        m_friendlyResetminute = 0;
        m_friendlyResetSecond = 0.0f;

        UIManager.instance.FriendlyResetTextSet(m_friendlyResetminute, m_friendlyResetSecond);
        UIManager.instance.FriendlyListPanel.RefreshOn();
        isResetTime = true;

        yield return null;
    }
}

   