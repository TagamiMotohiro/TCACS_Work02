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
        //����̃X�R�A���g�p���ă����L���O���\�[�g
        ranking.SaveRanking(rank);
        //�\�[�g���ʂ����[�J���ɕۑ�
        for (int i = 0; i < 5; i++)
        {
            //�e�L�X�g�ɏo��
            Ranking_Text[i].text = (i + 1).ToString() + "�ʁ@:" + rank[i].ToString()+"�_";
        }
        //�^�C�g���֖߂�{�^���C�x���g����
        returnTitle_Button.OnClickAsObservable().Subscribe(_=> ReturnTitle()).AddTo(disposables);
    }
    void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
