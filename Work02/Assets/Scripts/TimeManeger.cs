using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManeger
{
    public bool timerStart { get; private set; } =false;
    public float time { get; private set; } = 10;
    public void TimerCount()
    {
        time -= Time.deltaTime;
    }
    public void SetStart()
    { 
        timerStart = true;
    }
    public void SetTime(float Input)
    { 
        time = Input;
    }
}
