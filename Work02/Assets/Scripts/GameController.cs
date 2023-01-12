using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    TimeManeger Timer = new TimeManeger();
    [SerializeField]
    ButtonManeger ButtonManeger;

    [SerializeField]
    TextMeshProUGUI score_Text;
    [SerializeField]
    TextMeshProUGUI count_Text;
    [SerializeField]
    TextMeshProUGUI timer_Text;
    [SerializeField]
    TextMeshProUGUI finish_Text;

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
        score_Text.text = Score.GetScore().ToString();
        if (Timer.time <= 0)
        {
            timer_Text.text = "0";
            finish_Text.gameObject.SetActive(true);
            Invoke("LoadResult", 3);
        }
    }
    IEnumerator CountDown()
    {
        for (int i = 0; i < CountMax; i++)
        {
            count_Text.text = (CountMax - i).ToString();
            yield return new WaitForSeconds(1);
        }
        Timer.SetStart();
        count_Text.gameObject.SetActive(false);
        ButtonManeger.enabled = true;
        yield break;
    }
    void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }
}
