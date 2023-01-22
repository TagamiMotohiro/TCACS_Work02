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
        //コルーチンでカウントダウンを起動
    }

    // Update is called once per frame
    void Update()
    {
        if (!Timer.timerStart) { return; }
        Timer.TimerCount();
        //別クラスに時間をカウントさせる
        timer_Text.text = Timer.time.ToString("F3");
        //スコア表示を更新
        score_Text.text = Score.GetScore().ToString();
        if (Timer.time <= 0)
        {
            //時間切れしたらタイマーがマイナスの世界に行くので0に
            timer_Text.text = "0";
            //ゲーム終了を告知
            finish_Text.gameObject.SetActive(true);
            //3秒後にリザルトへ遷移
            Invoke("LoadResult", 3);
        }
    }
    IEnumerator CountDown()
    {
        for (int i = 0; i < CountMax; i++)
        {
            //1秒ずつ待ってカウント減少
            count_Text.text = (CountMax - i).ToString();
            yield return new WaitForSeconds(1);
        }
        //タイマーのカウントを開始
        Timer.SetStart();
        //カウント用のテキストは邪魔なので消滅
        count_Text.gameObject.SetActive(false);
        //ボタン管理のスクリプトを使用可能に
        ButtonManeger.enabled = true;
        yield break;
    }
    void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }
    public void PlusTime(float input)
    {
        Timer.PlusTime(input);
    }
}
