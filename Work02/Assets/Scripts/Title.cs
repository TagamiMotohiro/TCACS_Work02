using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Button gameStart_button;
    CompositeDisposable disposables = new CompositeDisposable();
    // Start is called before the first frame update
    void Start()
    {
        //メインゲームへ遷移させるボタンイベント処理
		gameStart_button.OnClickAsObservable().Subscribe(_ => Gamestart()).AddTo(disposables);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    void Gamestart()
    {
        SceneManager.LoadScene("MainGame");
    }
}
