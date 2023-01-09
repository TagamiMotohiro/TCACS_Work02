using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    TimeManeger Timer = new TimeManeger();
    [SerializeField]
    ButtonManeger ButtonManeger;
    [SerializeField]
    TextMeshProUGUI CountText;
    [SerializeField]
    TextMeshProUGUI timer_Text;
    [SerializeField]
    int CountMax=3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountDown");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Timer.timerStart) { return; }
        Timer.TimerCount();
        timer_Text.text = Timer.time.ToString();
        
    }
    IEnumerator CountDown()
    {
        for (int i = 0; i < CountMax; i++)
        {
            CountText.text = (CountMax - i).ToString();
            yield return new WaitForSeconds(1);
        }
        Timer.SetStart();
        CountText.gameObject.SetActive(false);
        ButtonManeger.enabled = true;
        yield break;
    }
}
