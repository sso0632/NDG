using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static float Timesize = 1f*Time.deltaTime;

    void Pause()
    {
        Timesize = 0;

    }
    void Play()
    {
        Timesize = 1f;
    }
}

   