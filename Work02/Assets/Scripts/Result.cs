using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    CompositeDisposable disposables=new CompositeDisposable();
    LoadRanking ranking = new LoadRanking();
    List<int> rank= new List<int>();
    [SerializeField]
    TextMeshProUGUI[] Ranking_Text=new TextMeshProUGUI[5];
    [SerializeField]
    UnityEngine.UI.Button returnTitle_Button;
    // Start is called before the first frame update
    void Start()
    {
        rank = ranking.SetRanking(Score.now_Score);
        //今回のスコアを使用してランキングをソート
        ranking.SaveRanking(rank);
        //ソート結果をローカルに保存
        for (int i = 0; i < 5; i++)
        {
            //テキストに出力
            Ranking_Text[i].text = (i + 1).ToString() + "位　:" + rank[i].ToString()+"点";
        }
        //タイトルへ戻るボタンイベント処理
        returnTitle_Button.OnClickAsObservable().Subscribe(_=> ReturnTitle()).AddTo(disposables);
    }
    void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
