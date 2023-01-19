using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using JetBrains.Annotations;

public class ButtonManeger : MonoBehaviour
{
    Button[,] Button_List = new Button[10, 10];
    GameObject[] Button_Allay_List=new GameObject[10];
    CompositeDisposable disposables= new CompositeDisposable();
    // Start is called before the first frame update
    void Start()
    {
        //Staticで存在するスコアを0にリセット
        Score.SetScore(0);
        for (int i = 0; i < 10; i++)
        {
            Button_Allay_List[i]=GameObject.Find("Button_Allay ("+i.ToString()+")");
        }
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Button_List[y, x] = Button_Allay_List[y].transform.GetChild(x).GetComponent<Button>();
            }
        }
        //ボタンを一覧で取得
        //どこかしらのボタンを押せる状態に
		ButtonActive(Button_List[Random.Range((int)0, (int)10), Random.Range((int)0, (int)10)]);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonActive(Button button)
    {
        //押せる状態になったら赤色になる
        Debug.Log(button.gameObject.name);
        button.gameObject.GetComponent<Image>().color = Color.red;
        //ボタンのクリックイベントを設定
        button.OnClickAsObservable().Subscribe(_ => ButtonOnclick(button)).AddTo(disposables);
    }
    void ButtonOnclick(Button button)
    {
        //赤いボタンを押したら
        Debug.Log("クリックされた");
        //スコアに1プラス
        Score.PlusScore(1);
        //ボタンの色を戻す
        button.gameObject.GetComponent<Image>().color = Color.gray;
        //クリックイベントの購読を解除
        disposables.Clear();
        //最後にどこかしらのボタンを押せる状態にすることでループさせる
        ButtonActive(Button_List[Random.Range((int)0,(int)10),Random.Range((int)0, (int)10)]);
    }
}
