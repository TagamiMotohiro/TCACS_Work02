using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    LoadRanking ranking = new LoadRanking();
    [SerializeField]
    TextMeshProUGUI[] Ranking_Text=new TextMeshProUGUI[5];
    List<int> rank= new List<int>();
    [SerializeField]
    UnityEngine.UI.Button returnTitle_Button;
    CompositeDisposable disposables=new CompositeDisposable();
    // Start is called before the first frame update
    void Start()
    {
        rank = ranking.SetRanking(Score.this_Score);
        for (int i = 0; i < 5; i++)
        {
            Ranking_Text[i].text = (i + 1).ToString() + "ˆÊ@:" + rank[i].ToString()+"“_";
        }
        returnTitle_Button.OnClickAsObservable().Subscribe(_ => ReturnTitle()).AddTo(disposables);
    }
    void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
